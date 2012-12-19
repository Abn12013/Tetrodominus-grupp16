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
        public bool follow;
        public bool free = true;
        public int step = 4;

        public Unit()
        {
            position = new Vector2(0, 0);
            follow = false;
        }

        public Unit(Vector2 position)
        {
            this.position = position;
        }

        public void Behavior(Vector2 mouseCoordinate, ref bool[,] isOccupied)
        {
            if (mouseCoordinate.X < position.X && isOccupied[(int)(position.X)-1, (int)position.Y] == false && step > 0)
            {
                isOccupied[(int)position.X, (int)position.Y] = false;
                position.X--;
                step--;
            }
            else if (mouseCoordinate.X > position.X && isOccupied[(int)(position.X) + 1, (int)position.Y] == false && step > 0)
            {
                isOccupied[(int)position.X, (int)position.Y] = false;
                position.X++;
                step--;
            }
            else if (mouseCoordinate.Y < position.Y && isOccupied[(int)position.X, (int)(position.Y) - 1] == false && step > 0)
            {
                isOccupied[(int)position.X, (int)position.Y] = false;
                position.Y--;
                step--;
            }
            else if (mouseCoordinate.Y > position.Y && isOccupied[(int)position.X, (int)(position.Y) + 1] == false && step > 0)
            {
                isOccupied[(int)position.X, (int)position.Y] = false;
                position.Y++;
                step--;
            }
            isOccupied[(int)position.X, (int)position.Y] = true;
        }
    }
}
