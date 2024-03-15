using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDemarrage.Template
{
    public class GameState
    {
        public enum SceneType
        {
            Menu,
            Gameplay,
            Gameover
        }

        protected MainGame MainGame { get; set; }
        public Scene CurrentScene { get; set; }

        public GameState(MainGame pGame)
        {
            MainGame = pGame;
        }

        public void ChangeScene(SceneType pSceneType)
        {
            if (CurrentScene != null)
            {
                CurrentScene.UnLoad();
                CurrentScene = null;
            }

            switch (pSceneType)
            {
                case SceneType.Menu:
                    CurrentScene = new SceneMenu(MainGame);
                    break;
                case SceneType.Gameplay:
                    CurrentScene = new SceneGamePlay(MainGame);
                    break;
                case SceneType.Gameover:
                    CurrentScene = new SceneGameOver(MainGame);
                    break;
            }

            CurrentScene.Load();
        }
    }
}
