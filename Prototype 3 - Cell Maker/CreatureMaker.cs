using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Prototype_3___Cell_Maker
{
    class CreatureMaker
{
        public Rectangle cellSize { get; set; }
        public Texture2D cellTexture { get; set; }

        public CreatureMaker(Rectangle inCellSize, Texture2D inTexture)
        {
            cellSize = inCellSize;
            cellTexture = inTexture;
        }

}
}
