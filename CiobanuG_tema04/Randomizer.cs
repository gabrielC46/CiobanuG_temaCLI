﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace OpenTk_tema04
{
    internal class Randomizer
    {
        private Random r;

        private const int LOW_INT_VAL = -25;
        private const int HIGH_INT_VAL = 25;
        private const int LOW_COORD_VAL = -50;
        private const int HIGH_COORD_VAL = 50;

        public Randomizer()
        {
            r = new Random();
        }

        public Color RandomColor()
        {
            int genR = r.Next(0, 255);
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);

            Color col = Color.FromArgb(genR, genG, genB);

            return col;
        }

        public Vector3 Random3DPoint()
        {
            int a = r.Next(LOW_COORD_VAL, HIGH_COORD_VAL);
            int b = r.Next(LOW_COORD_VAL, HIGH_COORD_VAL);
            int c = r.Next(LOW_COORD_VAL, HIGH_COORD_VAL);

            Vector3 vec = new Vector3(a, b, c);

            return vec;
        }

        public int RandomInt()
        {
            int i = r.Next(LOW_INT_VAL, HIGH_INT_VAL);

            return i;
        }

        public int RandomInt(int minVal, int maxVal)
        {
            int i = r.Next(minVal, maxVal);

            return i;
        }

        public int RandomInt(int maxval)
        {
            int i = r.Next(maxval);

            return i;
        }
    }
}
