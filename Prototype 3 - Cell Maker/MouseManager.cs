using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Prototype_3___Cell_Maker
{
    class MouseManager
    {
        public bool mouseClicked { get; set; }

        public MouseManager(bool inState)
        {
            mouseClicked = inState;
        }

        public bool IsMouseDown(Rectangle position)
        {
            if(Mouse.GetState().Position.X >= position.X && Mouse.GetState().Position.X <= position.X + position.Width)
            {
                if(Mouse.GetState().Position.Y >= position.Y && Mouse.GetState().Position.Y <= position.Y + position.Height)
                {
                    if(Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {

                        mouseClicked = true;

                    }
                }
            }

            return mouseClicked;
        }

    }
}
