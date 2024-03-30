using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TemplateDemarrage.Template;

namespace TemplateDemarrage
{
    internal class Hero : Sprite
    {
        public int Energy { get; set; }

        public Hero(Texture2D pTexture, int pX = 0, int pY = 0) : base(pTexture, new Vector2(pX, pY))
        {
            Energy = 100;
        }

        
    }
}
