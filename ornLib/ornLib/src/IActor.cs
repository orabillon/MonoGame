using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ornLib.src
{
    public interface IActor
    {
        Vector2 Position { get; }
        Rectangle BoundingBox { get; }

        bool toRemove { get; set; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch pSpriteBatch);

        void TouchedBy(IActor pBy);
    }
}
