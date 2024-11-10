using System;
using System.Drawing;
using System.IO;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Main
{
    internal class Cube
    {
        private Vector3[] vertices;
        private Color[] faceColors;
        private readonly Random random = new Random();

        public Cube(string vertexFilePath)
        {
            LoadVertices(vertexFilePath);
            InitializeColors();
        }

        private void LoadVertices(string filePath)
        {
            var vertexList = new System.Collections.Generic.List<Vector3>();

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length >= 3 && float.TryParse(parts[0], out float x) &&
                    float.TryParse(parts[1], out float y) &&
                    float.TryParse(parts[2], out float z))
                {
                    vertexList.Add(new Vector3(x, y, z));
                }
            }

            vertices = vertexList.ToArray();
        }

        private void InitializeColors()
        {
            faceColors = new Color[FaceCount];
            for (int i = 0; i < faceColors.Length; i++)
            {
                faceColors[i] = Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256));
            }
        }

        // Add the FaceCount property
        public int FaceCount => vertices.Length / 3;

        public void ChangeFaceColor(int faceIndex, Color color)
        {
            if (faceIndex >= 0 && faceIndex < faceColors.Length)
            {
                faceColors[faceIndex] = color;
            }
        }

        public void RandomizeColors()
        {
            for (int i = 0; i < faceColors.Length; i++)
            {
                faceColors[i] = Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256));
            }
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < vertices.Length; i += 3)
            {
                Color color = faceColors[i / 3];
                GL.Color4(color);
               // Console.WriteLine($"Face {i / 3} Color: R={color.R}, G={color.G}, B={color.B}, A={color.A}");
                GL.Vertex3(vertices[i]);
                GL.Vertex3(vertices[i + 1]);
                GL.Vertex3(vertices[i + 2]);
            }
            GL.End();
        }
    }

    

    

    internal class Window3D : GameWindow
    {
        private Cube cube;
        private KeyboardState lastKeyPress;
        private readonly Random random = new Random();

        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8)) {
            Console.WriteLine("R - Modifica culoarea unei fete a cubului.\nP - Modifica culoarea triunghiurilor unul cate unul a cubului.");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            cube = new Cube("cube_vertices.txt");
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            double aspectRatio = Width / (double)Height;
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, (float)aspectRatio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            Matrix4 lookat = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard[Key.Escape]) Exit();

            // Randomize colors for all faces
            if (keyboard[Key.R] && !keyboard.Equals(lastKeyPress))
            {
                cube.RandomizeColors();
            }

            // Change color of a random face
            if (keyboard[Key.P] && !keyboard.Equals(lastKeyPress))
            {
                int faceIndex = random.Next(0, cube.FaceCount);
                Color newColor = Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256));
                cube.ChangeFaceColor(faceIndex, newColor);
            }

            lastKeyPress = keyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            cube.Draw();
            SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (Window3D example = new Window3D())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
