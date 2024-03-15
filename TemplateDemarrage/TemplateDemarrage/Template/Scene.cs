using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDemarrage.Template
{
    public abstract class Scene
    {
        protected MainGame MainGame {  get; set; }

        protected Scene(MainGame pGame) {
            MainGame = pGame;
        }

        public virtual void Load() { }
        public virtual void UnLoad() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(GameTime gameTime) { }
        
    }
}
