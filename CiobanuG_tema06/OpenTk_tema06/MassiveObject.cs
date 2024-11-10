using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ConsoleApp3
{
    public class MassiveObject
    {
        //private const String FILENAME = "assets/soccer_ball.obj";
        //private const String FILENAME = "assets/lowpolytree.obj";
        //private const String FILENAME = "assets/bottle_cap_obj.obj";
        private const String FILENAME = "assets/slime.obj";
        //private const String FILENAME = "assets/volleyball.obj";
        private const int FACTOR_SCALARE_IMPORT = 100;

        private List<Vector3> coordsList;
        private bool visibility;
        private Color meshColor;
        private bool hasError;

        public MassiveObject(Color col)
        {


            try
            {
                coordsList = LoadFromObjFile(FILENAME);

                if (coordsList.Count == 0)
                {
                    Console.WriteLine("Crearea obiectului a esuat: obiect negasit/coordonate lipsa!");
                    return;
                }
                visibility = false;
                meshColor = col;
                hasError = false;
                Console.WriteLine("Obiect 3D încarcat - " + coordsList.Count.ToString() + " vertexuri disponibile!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: assets file <" + FILENAME + "> is missing!!!");
                hasError = true;
            }
        }

        public void ToggleVisibility()
        {
            if (hasError == false)
            {
                visibility = !visibility;
            }
        }

        public void Draw()
        {
            if (hasError == false && visibility == true)
            {
                GL.Color3(meshColor);
                GL.Begin(PrimitiveType.Triangles);
                foreach (var vert in coordsList)
                {
                    GL.Vertex3(vert);
                }
                GL.End();
            }
        }

        private List<Vector3> LoadFromObjFile(string fname)
        {
            List<Vector3> vertices = new List<Vector3>();
            if (!File.Exists(fname)) throw new FileNotFoundException();

            foreach (var line in File.ReadLines(fname))
            {
                if (line.StartsWith("v "))
                {
                    var parts = line.Split(' ');
                    if (parts.Length >= 4 &&
                        float.TryParse(parts[1], out float x) &&
                        float.TryParse(parts[2], out float y) &&
                        float.TryParse(parts[3], out float z))
                    {
                        vertices.Add(new Vector3(x * FACTOR_SCALARE_IMPORT, y * FACTOR_SCALARE_IMPORT, z * FACTOR_SCALARE_IMPORT));
                    }
                }
            }
            return vertices;
        }

    }
}
