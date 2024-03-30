using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDemarrage.Template
{
    internal class Sprite : IActor
    {
        // Iactor
        public Vector2 Position { get; set; }
        public Rectangle BoundingBox { get; private set; }
        public float velociteX { get; set; }
        public float velociteY { get; set; }

        // sprite
        public Texture2D Texture { get; }

        public Sprite(Texture2D pTexture)
        {
            Texture = pTexture;
            velociteX = 0;
            velociteY = 0;
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(Texture,Position,Color.White);
        }

        public void Update(GameTime gameTime)
        {
            Move(velociteX, velociteY);
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void Move(float pX, float pY)
        {
            Position = new Vector2(Position.X + pX, Position.Y + pY);
        }
    }
}
