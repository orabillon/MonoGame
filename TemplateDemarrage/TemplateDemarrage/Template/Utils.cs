﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDemarrage.Template
{
    public static class Utils
    {
        static Random RandomGen = new Random();

        public static void setRandomSeed(int pSeed)
        {
            RandomGen = new Random(pSeed);
        }

        public static int getInt(int pMin, int pMax)
        {
            return RandomGen.Next(pMin, pMax + 1);
        }

        public static bool CollideByBox(IActor pActor1, IActor pActor2)
        {
              return pActor1.BoundingBox.Intersects(pActor2.BoundingBox);
        }
    }
}
