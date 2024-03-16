using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDemarrage.Template
{
    public static class AssetsManager
    {
        public static SpriteFont MainFont { get; private set; }

        public static void Load(ContentManager pContentManager) {
            MainFont = pContentManager.Load<SpriteFont>("PixelMaster");
        }
    }
}
