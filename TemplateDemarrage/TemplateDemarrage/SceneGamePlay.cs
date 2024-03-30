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
    public class SceneGamePlay : Scene
    {
        private KeyboardState _OldkeyboardState;
        private GamePadState _OldGamePadState;
        private Hero Hero;
        private Rectangle screen;

        public SceneGamePlay(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("Scene Game Play");
        }

        public override void Load()
        {
            _OldkeyboardState = Keyboard.GetState();
            _OldGamePadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);

            screen = MainGame.Window.ClientBounds;

            Texture2D texMeteor = MainGame.Content.Load<Texture2D>("meteor");

            for (int i = 0; i < 20; i++)
            {
                Meteor m = new Meteor(texMeteor);
                m.Position = new Vector2(Utils.getInt(0,screen.Width - texMeteor.Width), Utils.getInt(0, screen.Height - texMeteor.Height));
                listActors.Add(m);
            }

            Texture2D text = MainGame.Content.Load<Texture2D>("Ship");
            Hero = new Hero(text, (screen.Width / 2) - text.Width / 2, (screen.Height / 2) - text.Height / 2);
            listActors.Add(Hero);

            base.Load();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var actor in listActors)
            {
                if(actor is Meteor m) {
                    if (m.Position.X < 0)
                    {
                        m.Position = new Vector2(0, m.Position.Y);
                        m.velociteX *= -1;
                    }
                    if(m.Position.X + m.BoundingBox.Width > screen.Width) {
                        m.velociteX *= -1;
                        m.Position = new Vector2(screen.Width - m.BoundingBox.Width, m.Position.Y);
                    }
                    if (m.Position.Y < 0)
                    {
                        m.Position = new Vector2(m.Position.X, 0);
                        m.velociteY *= -1;
                    }
                    if (m.Position.Y + m.BoundingBox.Height > screen.Height)
                    {
                        m.velociteY *= -1;
                        m.Position = new Vector2(m.Position.X, screen.Height - m.BoundingBox.Height);

                    }
                }
                
            }

            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            GamePadState gamePadState;

            bool bButA = false; // X
            bool bStickLeftUp = false;
            bool bStickLeftDown = false;
            bool bStickLeftRight = false;
            bool bStickLeftLeft = false;

            if (capabilities.IsConnected)
            {
                gamePadState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);

                if (gamePadState.IsButtonDown(Buttons.A) && !_OldGamePadState.IsButtonDown(Buttons.A))
                {
                    bButA = true;
                }

                if (gamePadState.ThumbSticks.Left.X < -0.5f)
                {
                    bStickLeftLeft = true; 
                }
                if (gamePadState.ThumbSticks.Left.X > 0.5f)
                {
                    bStickLeftRight = true;
                }
                if (gamePadState.ThumbSticks.Left.Y < -0.5f)
                {
                    bStickLeftDown = true;
                }
                if (gamePadState.ThumbSticks.Left.Y > 0.5f)
                {
                    bStickLeftUp = true;
                }


                _OldGamePadState = gamePadState;

            }

            KeyboardState keyboardState = Keyboard.GetState();
            
            if(keyboardState.IsKeyDown(Keys.Space) && !_OldkeyboardState.IsKeyDown(Keys.Space))
            {
                Debug.WriteLine("space");
            }

            if (keyboardState.IsKeyDown(Keys.Right) || bStickLeftRight)
            {
                Hero.Move(1, 0);
            }
            if (keyboardState.IsKeyDown(Keys.Left) || bStickLeftLeft)
            {
                Hero.Move(-1, 0);
            }
            if (keyboardState.IsKeyDown(Keys.Up) || bStickLeftUp)
            {
                Hero.Move(0, -1);
            }
            if (keyboardState.IsKeyDown(Keys.Down) || bStickLeftDown)
            {
                Hero.Move(0, 1);
            }

            _OldkeyboardState = keyboardState;
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            MainGame.spriteBatch.DrawString(AssetsManager.MainFont, "Ceci est le Jeu", new Vector2(1, 1), Color.White);

            base.Draw(gameTime);
        }
    }
}
