using System.Data.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace casseBrique;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Scene MaSceneCourante;
    SceneMenu MaSceneMenu;
    SceneJeu MaSceneJeu;
        

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
       

        MaSceneMenu = new SceneMenu(this);
        MaSceneJeu = new SceneJeu(this);

        MaSceneCourante = MaSceneMenu;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
         if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                MaSceneCourante = MaSceneJeu;
            }

        
        MaSceneCourante.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        MaSceneCourante.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
