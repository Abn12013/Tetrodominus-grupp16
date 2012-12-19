using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tetrodominus
{
    class CombinedUnit
    {
        public Vector2 position1, position2, position3, position4;
        public bool follow;
        public bool free = false;
        public int step = 6;
        public string type = "";

        public CombinedUnit()
        {
            position1 = new Vector2(0, 0);
            position2 = new Vector2(0, 0);
            position3 = new Vector2(0, 0);
            position4 = new Vector2(0, 0);
            follow = false;
        }

        public CombinedUnit(Vector2 position1, Vector2 position2, Vector2 position3, Vector2 position4, String type)
        {
            this.position1 = position1;
            this.position2 = position2;
            this.position3 = position3;
            this.position4 = position4;
            this.type = type;
        }

        public void Behavior(Vector2 mouseCoordinate, ref bool[,] isOccupied)
        {
            switch (type)
            {
                case "bomb":
                    if (mouseCoordinate.X < position1.X && isOccupied[(int)(position1.X) - 1, (int)position1.Y] == false &&
                        isOccupied[(int)(position3.X) - 1, (int)position3.Y] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.X--;
                        position2.X--;
                        position3.X--;
                        position4.X--;
                        step--;
                    }
                    else if (mouseCoordinate.X > position2.X && isOccupied[(int)(position2.X) + 1, (int)position2.Y] == false &&
                        isOccupied[(int)(position4.X)+1,(int)position4.Y] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.X++;
                        position2.X++;
                        position3.X++;
                        position4.X++;
                        step--;
                    }
                    else if (mouseCoordinate.Y < position1.Y && isOccupied[(int)position1.X, (int)(position1.Y) - 1] == false &&
                        isOccupied[(int)position2.X, (int)(position2.Y)-1] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.Y--;
                        position2.Y--;
                        position3.Y--;
                        position4.Y--;
                        step--;
                    }
                    else if (mouseCoordinate.Y > position3.Y && isOccupied[(int)position3.X, (int)(position3.Y) + 1] == false &&
                        isOccupied[(int)position4.X, (int)(position4.Y) + 1] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.Y++;
                        position2.Y++;
                        position3.Y++;
                        position4.Y++;
                        step--;
                    }
                    isOccupied[(int)position1.X, (int)position1.Y] = true;
                    isOccupied[(int)position2.X, (int)position2.Y] = true;
                    isOccupied[(int)position3.X, (int)position3.Y] = true;
                    isOccupied[(int)position4.X, (int)position4.Y] = true;
                    break;
                case "missile":
                    if (mouseCoordinate.X < position1.X && isOccupied[(int)(position1.X) - 1, (int)position1.Y] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.X--;
                        position2.X--;
                        position3.X--;
                        position4.X--;
                        step--;
                    }
                    else if (mouseCoordinate.X > position4.X && isOccupied[(int)(position4.X) + 1, (int)position4.Y] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.X++;
                        position2.X++;
                        position3.X++;
                        position4.X++;
                        step--;
                    }
                    else if (mouseCoordinate.Y < position1.Y && isOccupied[(int)position1.X, (int)(position1.Y) - 1] == false &&
                        isOccupied[(int)position2.X, (int)(position2.Y)-1] == false &&
                        isOccupied[(int)position3.X, (int)(position3.Y) - 1] == false &&
                        isOccupied[(int)position4.X, (int)(position4.Y) - 1] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.Y--;
                        position2.Y--;
                        position3.Y--;
                        position4.Y--;
                        step--;
                    }
                    else if (mouseCoordinate.Y > position1.Y && isOccupied[(int)position1.X, (int)(position1.Y) + 1] == false &&
                        isOccupied[(int)position2.X, (int)(position2.Y) + 1] == false &&
                        isOccupied[(int)position3.X, (int)(position3.Y) - 1] == false &&
                        isOccupied[(int)position4.X, (int)(position4.Y) - 1] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.Y++;
                        position2.Y++;
                        position3.Y++;
                        position4.Y++;
                        step--;
                    }
                    isOccupied[(int)position1.X, (int)position1.Y] = true;
                    isOccupied[(int)position2.X, (int)position2.Y] = true;
                    isOccupied[(int)position3.X, (int)position3.Y] = true;
                    isOccupied[(int)position4.X, (int)position4.Y] = true;
                    break;
                case "wall":
                    if (mouseCoordinate.X < position1.X && isOccupied[(int)(position1.X) - 1, (int)position1.Y] == false &&
                        isOccupied[(int)(position2.X) - 1, (int)position2.Y] == false && 
                        isOccupied[(int)(position3.X) - 1, (int)position3.Y] == false &&
                        isOccupied[(int)(position4.X) - 1, (int)position4.Y] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.X--;
                        position2.X--;
                        position3.X--;
                        position4.X--;
                        step--;
                    }
                    else if (mouseCoordinate.X > position1.X && isOccupied[(int)(position1.X) + 1, (int)position1.Y] == false &&
                        isOccupied[(int)(position2.X) + 1, (int)position2.Y] == false &&
                        isOccupied[(int)(position3.X) + 1, (int)position3.Y] == false &&
                        isOccupied[(int)(position4.X) + 1, (int)position4.Y] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.X++;
                        position2.X++;
                        position3.X++;
                        position4.X++;
                        step--;
                    }
                    else if (mouseCoordinate.Y < position1.Y && isOccupied[(int)position1.X, (int)(position1.Y) - 1] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.Y--;
                        position2.Y--;
                        position3.Y--;
                        position4.Y--;
                        step--;
                    }
                    else if (mouseCoordinate.Y > position4.Y && isOccupied[(int)position4.X, (int)(position4.Y) + 1] == false && step > 0)
                    {
                        isOccupied[(int)position1.X, (int)position1.Y] = false;
                        isOccupied[(int)position2.X, (int)position2.Y] = false;
                        isOccupied[(int)position3.X, (int)position3.Y] = false;
                        isOccupied[(int)position4.X, (int)position4.Y] = false;
                        position1.Y++;
                        position2.Y++;
                        position3.Y++;
                        position4.Y++;
                        step--;
                    }
                    isOccupied[(int)position1.X, (int)position1.Y] = true;
                    isOccupied[(int)position2.X, (int)position2.Y] = true;
                    isOccupied[(int)position3.X, (int)position3.Y] = true;
                    isOccupied[(int)position4.X, (int)position4.Y] = true;
                    break;
            }
        }
    }
}
