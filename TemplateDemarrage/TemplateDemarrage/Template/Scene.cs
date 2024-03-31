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

        protected List<IActor> listActors;

        protected Scene(MainGame pGame) {
            MainGame = pGame;
            listActors = new List<IActor>();
        }

        public virtual void Load() { }
        public virtual void UnLoad() { }
        public virtual void Update(GameTime gameTime) {
            foreach (var actor in listActors)
            {
                actor.Update(gameTime); 
            }
        }
        public virtual void Draw(GameTime gameTime) {
        
            foreach (var actor in listActors)
            {
                actor.Draw(MainGame.spriteBatch);   
            }
        }

        public void Clean()
        {
            listActors.RemoveAll(item => item.toRemove == true);
        }
        
    }
}
