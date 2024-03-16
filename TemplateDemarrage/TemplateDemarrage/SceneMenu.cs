using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDemarrage.Template;

namespace TemplateDemarrage
{
    public class SceneMenu : Scene
    {
        public SceneMenu(MainGame pGame) : base(pGame)
        {
            
        }

        public override void Load()
        {
            base.Load();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            MainGame.spriteBatch.Begin();

            MainGame.spriteBatch.DrawString(AssetsManager.MainFont, "Ceci est le Menu", new Vector2(1,1), Color.White);

            MainGame.spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
