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
        public string owner;
        public bool isOccupied;
        public Vector2 position;
        public Texture2D texture;
        public Rectangle box;
        public Unit()
        {
            isOccupied = false;
            owner = "";
            position = new Vector2(0, 0);
            texture = null;
        }

        public Unit(bool isOccupied, string owner, Vector2 position, ContentManager content)
        {
            this.isOccupied = isOccupied;
            this.owner = owner;
            this.position = position;
            switch (owner)
            {
                case ("Circle"):
                    {
                        this.texture = content.Load<Texture2D>("Circle");
                        break;
                    }
                case ("Square"):
                    {
                        this.texture = content.Load<Texture2D>("Square");
                        break;
                    }
            }
        }

        public void initialize(Unit[,] units, Vector2 mapSize, Vector2 tileSize, ContentManager content, GraphicsDeviceManager graphics)
        {
            for (int y = 0; y < mapSize.Y; y++)
            {
                for (int x = 0; x < mapSize.X; x++)
                {
                    if (y < 4 || y > 14 || x < 4 || x > 36)
                    {
                        units[x, y] = new Unit(true, "", new Vector2(x, y), content);
                    }
                    else
                    {
                        units[x, y] = new Unit(false, "", new Vector2(x, y), content);
                    }
                    units[x, y].box = new Rectangle((x * (int)tileSize.X) + (graphics.PreferredBackBufferWidth - (int)mapSize.X * (int)tileSize.X) / 2, (y * (int)tileSize.Y) + (graphics.PreferredBackBufferHeight - (int)mapSize.Y * (int)tileSize.Y) / 2, (int)tileSize.X, (int)tileSize.Y);
                }
            }
        }

        public void Draw(Unit[,] units, GraphicsDeviceManager graphics, SpriteBatch spriteBatch, Vector2 mapSize, Vector2 tileSize)
        {
            for (int y = 0 + 4; y < mapSize.Y - 4; y++)
            {
                for (int x = 0 + 4; x < mapSize.X - 4; x++)
                {
                    if (units[x, y].isOccupied)
                    {
                        spriteBatch.Draw(units[x, y].texture, new Rectangle((x * (int)tileSize.X) + (graphics.PreferredBackBufferWidth - (int)mapSize.X * (int)tileSize.X) / 2, (y * (int)tileSize.Y) + (graphics.PreferredBackBufferHeight - (int)mapSize.Y * (int)tileSize.Y) / 2, (int)tileSize.X, (int)tileSize.Y), Color.White);
                    }
                }
            }
        }
        public void createUnitsCircle(Unit[,] units, ContentManager content, ref List<Unit> orbs)
        {
            units[5, 5] = new Unit(true, "Circle", new Vector2(5, 5), content);
            units[5, 7] = new Unit(true, "Circle", new Vector2(5, 7), content);
            units[5, 10] = new Unit(true, "Circle", new Vector2(5, 10), content);
            units[6, 12] = new Unit(true, "Circle", new Vector2(5, 12), content);
        }
        public void createUnitsSquare(Unit[,] units, ContentManager content)
        {
            units[34, 5] = new Unit(true, "Square", new Vector2(34, 5), content);
            units[34, 7] = new Unit(true, "Square", new Vector2(34, 7), content);
            units[34, 10] = new Unit(true, "Square", new Vector2(34, 10), content);
            units[34, 12] = new Unit(true, "Square", new Vector2(34, 12), content);
        }
    }
}
