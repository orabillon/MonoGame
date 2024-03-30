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

        // sprite
        public Texture2D Texture { get; }

        public Sprite(Texture2D pTexture, Vector2 pPosition)
        {
            Texture = pTexture;
            Position = pPosition;
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(Texture,Position,Color.White);
        }

        public void Update(GameTime gameTime)
        {
            BoundingBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        public void Move(float pX, float pY)
        {
            Position = new Vector2(Position.X + pX, Position.Y + pY);
        }
    }
}
