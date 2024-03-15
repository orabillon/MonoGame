﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDemarrage.Template;

namespace TemplateDemarrage
{
    public class SceneGamePlay : Scene
    {
        public SceneGamePlay(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("Scene Game Play");
        }

        public override void Load()
        {
            base.Load();
        }

        public override void UnLoad()
        {
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}