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
    class GameGrid
    {
        public bool [,] isOccupied;
        public GameGrid(Vector2 gridSize)
        {
            isOccupied = new bool[(int)gridSize.X, (int)gridSize.Y];
        }
        public void Initialize(Vector2 gridSize)
        {
            for (int y = 0; y < gridSize.Y; y++)
            {
                for (int x = 0; x < gridSize.X; x++)
                {
                    if (x < 4 || x > 36 || y < 4 || y > 14)
                    {
                        isOccupied[x, y] = true;
                    }
                    else 
                    {
                        isOccupied[x, y] = false;
                    }
                }
            }
        }
    }
}
