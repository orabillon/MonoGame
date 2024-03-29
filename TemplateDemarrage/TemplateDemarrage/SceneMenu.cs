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
    public class SceneMenu : Scene
    {
        private KeyboardState _OldkeyboardState;

        public SceneMenu(MainGame pGame) : base(pGame)
        {
            
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

            if(keyboardState.IsKeyDown(Keys.Enter) && !_OldkeyboardState.IsKeyDown(Keys.Enter)) {
                _OldkeyboardState = keyboardState;
                MainGame.gameState.ChangeScene(GameState.SceneType.Gameplay);
            }
            
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
