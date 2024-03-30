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
    public class SceneGameOver : Scene
    {
        public SceneGameOver(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("Scene Game Over");
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
            MainGame.spriteBatch.DrawString(AssetsManager.MainFont, "Perdu", new Vector2(1, 1), Color.White);

            base.Draw(gameTime);
        }
    }
}
