﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TemplateDemarrage.Template;

namespace TemplateDemarrage
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch spriteBatch;

        public GameState gameState;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            gameState = new GameState (this);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameState.ChangeScene(GameState.SceneType.Menu);
            IsMouseVisible = true;

            // Chargement ressource partager
            AssetsManager.Load(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (gameState != null)
            {
                gameState.CurrentScene.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (gameState != null)
            {
                gameState.CurrentScene.Draw(gameTime);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
