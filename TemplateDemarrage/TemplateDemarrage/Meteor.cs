using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDemarrage.Template;

namespace TemplateDemarrage
{
    internal class Meteor : Sprite
    {
        public Meteor(Texture2D pTexture, int pX = 0, int pY = 0) : base(pTexture)
        {
            do { velociteX = Utils.getInt(-3, 3) / 5.0f;} while(velociteX==0);

            do { velociteY = Utils.getInt(-3, 3) / 5.0f; } while(velociteY==0);
        }
    }
}
