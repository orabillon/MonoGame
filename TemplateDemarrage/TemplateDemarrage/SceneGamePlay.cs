using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDemarrage.Template;

namespace TemplateDemarrage
{
    public class SceneGamePlay : Scene
    {
        private KeyboardState _OldkeyboardState;
        public SceneGamePlay(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("Scene Game Play");
        }

        public override void Load()
        {
            _OldkeyboardState = Keyboard.GetState();

            base.Load();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
            if(keyboardState.IsKeyDown(Keys.Space) && !_OldkeyboardState.IsKeyDown(Keys.Space))
            {
                Debug.WriteLine("space");
            }

            _OldkeyboardState = keyboardState;
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            MainGame.spriteBatch.Begin();

            MainGame.spriteBatch.DrawString(AssetsManager.MainFont, "Ceci est le Jeu", new Vector2(1, 1), Color.White);

            MainGame.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
