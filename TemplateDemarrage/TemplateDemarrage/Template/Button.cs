using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDemarrage.Template
{
    public delegate void OnClick(Button pSender);

    public class Button : Sprite
    {
        public bool isHover {  get; private set; }
        public OnClick onClick { get; set; }

        public MouseState _OldMouseState {  get; private set; }
        

        public Button(Texture2D pTexture) : base(pTexture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            MouseState MouseState = Mouse.GetState();
            Point MousePos = MouseState.Position;

            if(BoundingBox.Contains(MousePos))
            {
                if (!isHover)
                {
                    isHover = true;
                    Debug.WriteLine("Entrer dans le boutton"); 
                }
            }
            else
            {
                if (isHover) {    
                    Debug.WriteLine("Sortie du boutton");
                }
                isHover = false;
            }

            if(isHover)
            {
                if (MouseState.LeftButton == ButtonState.Pressed && _OldMouseState.LeftButton != ButtonState.Pressed)
                {
                  
                    if(onClick != null) {  onClick(this); }
                    Debug.WriteLine("Click");
                }
            }

            _OldMouseState = MouseState;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch)
        {
            base.Draw(pSpriteBatch);
        }
    }
}
