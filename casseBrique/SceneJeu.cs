using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace casseBrique;

public class SceneJeu : Scene
{
    Texture2D texPad;
    int padX;
    int padY;
    int speed;

     public SceneJeu(Game pGame) : base(pGame)
    {
       texPad = pGame.Content.Load<Texture2D>("raquette");

        padX = 100;
        padY = 100;
        speed = 3;
    }

    public override void Update(GameTime gameTime)
    {
        
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            padX += speed;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            padX -= speed;
        }
    }

    public override void Draw(SpriteBatch pBatch)
    {
        base.Draw(pBatch);
        pBatch.Draw(texPad, new Vector2(padX, padY), Color.White);
    }
}