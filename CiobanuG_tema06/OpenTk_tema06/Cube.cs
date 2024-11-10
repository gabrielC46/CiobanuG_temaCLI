using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace ConsoleApp3
{
    // New class Cube.cs added
    class Cube
    {
        private Vector3 position;
        private const float CUBE_SIZE = 10.0f;
        private bool isMoving;
        private Color color;

        public Cube(Vector3 startPosition, Color color)
        {
            position = startPosition;
            this.color = color;
            isMoving = true;
        }

        public void Draw()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color);
            DrawCube();
            GL.End();
        }

        public void Update()
        {
            if (isMoving)
            {
                position.Y -= 1.0f;  // Move down
                if (position.Y <= 0)  // Stop at Oxz plane
                {
                    position.Y = 0;
                    isMoving = false;
                }
            }
        }

        private void DrawCube()
        {
            float halfSize = CUBE_SIZE / 2;
            Vector3[] vertices = {
                new Vector3(position.X - halfSize, position.Y - halfSize, position.Z - halfSize),
                new Vector3(position.X + halfSize, position.Y - halfSize, position.Z - halfSize),
                new Vector3(position.X + halfSize, position.Y + halfSize, position.Z - halfSize),
                new Vector3(position.X - halfSize, position.Y + halfSize, position.Z - halfSize),
                new Vector3(position.X - halfSize, position.Y - halfSize, position.Z + halfSize),
                new Vector3(position.X + halfSize, position.Y - halfSize, position.Z + halfSize),
                new Vector3(position.X + halfSize, position.Y + halfSize, position.Z + halfSize),
                new Vector3(position.X - halfSize, position.Y + halfSize, position.Z + halfSize),
            };

            // Define faces using the vertices
            int[][] faces = {
                new[] {0, 1, 2, 3}, new[] {4, 5, 6, 7},
                new[] {0, 3, 7, 4}, new[] {1, 2, 6, 5},
                new[] {0, 1, 5, 4}, new[] {3, 2, 6, 7},
            };

            foreach (var face in faces)
            {
                foreach (var index in face)
                {
                    GL.Vertex3(vertices[index]);
                }
            }
        }
    }
}
