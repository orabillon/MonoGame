using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private MouseState _OldMouseState;

        private Button Button;

        private Rectangle screen;


        public SceneMenu(MainGame pGame) : base(pGame)
        {
            
        }

        public override void Load()
        {
            _OldKeyboardState = Keyboard.GetState();
            _OldGamePadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
            _OldMouseState = Mouse.GetState();

            screen = MainGame.Window.ClientBounds;

            Button = new Button(MainGame.Content.Load<Texture2D>("button"));
            Button.Position = new Vector2(
                    screen.Width / 2 - Button.Texture.Width / 2, 
                    screen.Height / 2 -  Button.Texture.Height /2
                );

            Button.onClick = onClikPlay;

            listActors.Add( Button );

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

            MouseState mouseState = Mouse.GetState();

            // Debug.WriteLine($"Position de la souris : X {mouseState.X} - Y {mouseState.Y}");

           // if (mouseState.LeftButton == ButtonState.Pressed && _OldMouseState.LeftButton != ButtonState.Pressed) {
           //     Debug.WriteLine("Bouton enffonce");
           // }

            _OldMouseState = mouseState;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            MainGame.spriteBatch.DrawString(AssetsManager.MainFont, "Ceci est le Menu", new Vector2(1,1), Color.White);

            base.Draw(gameTime);
        }

        public void onClikPlay(Button pSender)
        {
            MainGame.gameState.ChangeScene(GameState.SceneType.Gameplay);
        }
    }
}
