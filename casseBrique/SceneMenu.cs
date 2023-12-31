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

public class SceneMenu : Scene
{

    SpriteFont FontMenu; 

     public SceneMenu(Game pGame) : base(pGame)
    {
        FontMenu = pGame.Content.Load<SpriteFont>("PixelFont");
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(SpriteBatch pBatch)
    {
        base.Draw(pBatch);

        pBatch.DrawString(FontMenu,"Menu",new Vector2(10,10), Color.White);
    }
}