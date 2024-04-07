using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ornLib.src
{
    public delegate void OnClick(Button pSender);
    public delegate void OnEnter(Button pSender);
    public delegate void OnExit(Button pSender);


    public class Button : Sprite
    {
        public bool isHover { get; protected set; }
        public OnClick onClick { get; set; }
        public OnEnter onEnter { get; set; }
        public OnExit onExit { get; set; }


        public MouseState _OldMouseState { get; protected set; }


        public Button(Texture2D pTexture) : base(pTexture)
        {
        }

        public override void Update(GameTime gameTime)
        {
            MouseState MouseState = Mouse.GetState();
            Point MousePos = MouseState.Position;

            if (BoundingBox.Contains(MousePos))
            {
                if (!isHover)
                {
                    isHover = true;
                    if (onEnter != null) { onEnter(this); }
                }
            }
            else
            {
                if (isHover)
                {
                    if(onExit != null) { onExit(this); }  
                }
                isHover = false;
            }

            if (isHover)
            {
                if (MouseState.LeftButton == ButtonState.Pressed && _OldMouseState.LeftButton != ButtonState.Pressed)
                {
                    if (onClick != null) { onClick(this); }
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
