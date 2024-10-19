using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace OpenTK_Sample
{
    class ControlWindow : GameWindow
    {
        private float rotationX = 0.0f;  // Rotatia pe axa X
        private float rotationY = 0.0f;  // Rotatia pe axa Y
        private float lastMouseX;        
        private float lastMouseY;        
        private bool isMouseControlActive = false;  // Activarea mouse-ului

        public ControlWindow() : base(800, 600)
        {
            lastMouseX = Mouse.GetState().X;  // Initializeaza pozitia mouse-ului
            lastMouseY = Mouse.GetState().Y;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.1f, 0.2f, 0.3f, 1.0f);  // Culoarea de fundal
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);  // Viewport-ul

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Width / (float)Height, 1.0f, 100.0f);
            GL.LoadMatrix(ref perspective);  // Proiectia în perspectivă
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Controlul rotatiei cu tastatura
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard[Key.Escape])
            {
                Exit();  
            }

            // Tastele W si S - rotatia pe axa X (sus/jos)
            if (keyboard[Key.W])
            {
                rotationX += 1.0f;  // Roteste sus
            }                          
            if (keyboard[Key.S])       
            {                          
                rotationX -= 1.0f;  //  Roteste jos
            }

            // Tastele A si D - rotatia pe axa Y (stanga/dreapta)
            if (keyboard[Key.A])
            {
                rotationY -= 1.0f;  // Roteste stanga
            }
            if (keyboard[Key.D])
            {
                rotationY += 1.0f;  // Roteste dreapta
            }

            // Activeaza/dezactiveaza mouse-ul la click
            MouseState mouse = Mouse.GetState();
            if (mouse[MouseButton.Left])
            {
                if (!isMouseControlActive)
                {
                    isMouseControlActive = true;  // Activeaza la primul click
                }
                else
                {
                    isMouseControlActive = false;  // Dezactiveaza la al doilea click
                }
            }

            // Miscarea mouse-ului mouse-ul este activat
            if (isMouseControlActive)
            {
                float deltaX = mouse.X - lastMouseX;  // Miscarea pe axa X
                float deltaY = mouse.Y - lastMouseY;  // Miscarea pe axa Y
                rotationY += deltaX * 0.1f;  // Roteste  mouse-ul pe axa X
                rotationX += deltaY * 0.1f;  // Roteste  mouse-ul pe axa Y
            }

            lastMouseX = mouse.X;  // Actualizeaza pozitia X 
            lastMouseY = mouse.Y;  // Actualizeaza pozitia Y 
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);  // Curata ecranul

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(0.0f, 0.0f, -3.0f);  // Translatează obiectul înapoi pe axa Z

            // Aplica rotatia tastatura/mouse
            GL.Rotate(rotationX, 1.0f, 0.0f, 0.0f);  // Rotatie pe axa X
            GL.Rotate(rotationY, 0.0f, 1.0f, 0.0f);  // Rotatie pe axa Y

            // Desenează un triunghi simplu
            GL.Begin(PrimitiveType.Triangles);
            GL.Color3(1.0f, 0.0f, 0.0f);  // Rosu
            GL.Vertex3(-0.5f, -0.5f, 0.0f);
            GL.Color3(0.0f, 1.0f, 0.0f);  // Verde
            GL.Vertex3(0.5f, -0.5f, 0.0f);
            GL.Color3(0.0f, 0.0f, 1.0f);  // Albastru
            GL.Vertex3(0.0f, 0.5f, 0.0f);
            GL.End();

            SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Rotirea prin tasetele w/a/s/d.\nRotirea prin mouse la efectuarea click - de mai multe ori."); // Instructiuni utilizare
            using (ControlWindow window = new ControlWindow())
            {
                window.Run(60.0);  // Ruleaza la 60 FPS
            }
        }
    }
}
