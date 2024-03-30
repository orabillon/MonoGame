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
        private Hero Hero; 

        public SceneGamePlay(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("Scene Game Play");
        }

        public override void Load()
        {
            _OldkeyboardState = Keyboard.GetState();

            Rectangle screen = MainGame.Window.ClientBounds;
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
            KeyboardState keyboardState = Keyboard.GetState();
            
            if(keyboardState.IsKeyDown(Keys.Space) && !_OldkeyboardState.IsKeyDown(Keys.Space))
            {
                Debug.WriteLine("space");
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                Hero.Move(1, 0);
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                Hero.Move(-1, 0);
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                Hero.Move(0, -1);
            }
            if (keyboardState.IsKeyDown(Keys.Down))
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
