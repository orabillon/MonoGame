using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ornLib.src
{
    public abstract class Scene
    {
        protected Engine MainGame { get; set; }

        protected List<IActor> listActors;

        protected Scene(Engine pGame)
        {
            MainGame = pGame;
            listActors = new List<IActor>();
        }

        public virtual void Load() { }
        public virtual void UnLoad() { }
        public virtual void Update(GameTime gameTime)
        {
            foreach (var actor in listActors)
            {
                actor.Update(gameTime);
            }
        }
        public virtual void Draw(GameTime gameTime)
        {

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
