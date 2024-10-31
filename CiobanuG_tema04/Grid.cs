using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;

namespace OpenTk_tema04
{
    internal class Grid
    {
        private readonly Color colorisation;
        private bool visibility;

        private readonly Color GRIDCOLOR = Color.WhiteSmoke;
        private const int GRIDSTEP = 10;
        private const int UNITS = 50;
        private const int POOINT_OFFSET = GRIDSTEP * UNITS;

        private const int MICRO_OFFSET = 0;

        public Grid()
        {
            colorisation = GRIDCOLOR;
            visibility = true;
        }

        public void Show() { visibility = true; }

        public void Hide() { visibility = false; }

        public void ToggleVisibility() { visibility = !visibility; }

        public void Draw()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(colorisation);
                for (int i = -1 * GRIDSTEP * UNITS; i <= GRIDSTEP * UNITS; i += GRIDSTEP)
                {
                    GL.Vertex3(i + MICRO_OFFSET, 0, POOINT_OFFSET);
                    GL.Vertex3(i + MICRO_OFFSET, 0, -1 * POOINT_OFFSET);

                    GL.Vertex3(POOINT_OFFSET, 0, i + MICRO_OFFSET);
                    GL.Vertex3(-1 * POOINT_OFFSET, 0, i + MICRO_OFFSET);
                }
            }
        }
    }
}
