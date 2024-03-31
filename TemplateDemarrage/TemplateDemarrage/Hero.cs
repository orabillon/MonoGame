using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TemplateDemarrage.Template;

namespace TemplateDemarrage
{
    internal class Hero : Sprite
    {
        public float Energy { get; set; }

        public Hero(Texture2D pTexture, int pX = 0, int pY = 0) : base(pTexture)
        {
            Energy = 100;
            Position = new Vector2(pX, pY);
        }

        public override void TouchedBy(IActor pBy)
        {
            if (pBy != null)
            {
                if(pBy is Meteor m){
                    Energy -= 0.1f;
                }
            }
        }


    }
}
