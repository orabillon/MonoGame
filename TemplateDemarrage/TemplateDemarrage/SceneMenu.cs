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
        private KeyboardState _OldKeyboardState;
        private GamePadState _OldGamePadState;


        public SceneMenu(MainGame pGame) : base(pGame)
        {
            
        }

        public override void Load()
        {
            _OldKeyboardState = Keyboard.GetState();
            _OldGamePadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);


            base.Load();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {

            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            GamePadState gamePadState;

            bool ButA = false; // X



            if (capabilities.IsConnected)
            {
                gamePadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);

                if (gamePadState.IsButtonDown(Buttons.A) && !_OldGamePadState.IsButtonDown(Buttons.A))
                {
                   ButA = true;
                }

                _OldGamePadState = gamePadState;

            }

            KeyboardState keyboardState = Keyboard.GetState();

            if((keyboardState.IsKeyDown(Keys.Enter) && !_OldKeyboardState.IsKeyDown(Keys.Enter)) || ButA) {           
                MainGame.gameState.ChangeScene(GameState.SceneType.Gameplay);
            }

            _OldKeyboardState = keyboardState;

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
