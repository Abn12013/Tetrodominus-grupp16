using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tetrodominus
{
    class Unit
    {
        public Vector2 position;

        public Unit()
        {
            position = new Vector2(0, 0);;
        }

        public Unit(Vector2 position)
        {
            this.position = position;
        }
    }
}
