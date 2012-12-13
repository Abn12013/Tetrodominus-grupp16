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
    class Grid
    {
        public Texture2D gridUnitTexture;
        public Vector2 mapSize;
        public Vector2 tileSize;
        private int frame;
        private int tickSpace;
        public Grid()
        {
            gridUnitTexture = null;
            mapSize = new Vector2(40, 18);
            tileSize = new Vector2(25, 25);
            frame = 0;
        }

        public void loadContent(ContentManager content)
        {
            gridUnitTexture = content.Load<Texture2D>("tile");
        }

        public void tick(GameTime gameTime)
        {
            if (tickSpace == 32)
            {
                if (frame == 3)
                {
                    frame = 0;
                }
                else
                {
                    frame++;
                }
                tickSpace = 0;
            }
            tickSpace++;
        }

        
        public void draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            for (int y = 0 + 4; y < mapSize.Y - 4; y++)
            {
                for (int x = 0 + 4; x < mapSize.X - 4; x++)
                {
                    switch (frame)
                    {
                        case (0):
                            {
                                spriteBatch.Draw(gridUnitTexture, new Rectangle((x * (int)tileSize.X) + (graphics.PreferredBackBufferWidth - (int)mapSize.X * (int)tileSize.X) / 2, (y * (int)tileSize.Y) + (graphics.PreferredBackBufferHeight - (int)mapSize.Y * (int)tileSize.Y) / 2, (int)tileSize.X, (int)tileSize.Y), new Rectangle(frame * 25, 0, (int)tileSize.X, (int)tileSize.Y), Color.White);
                                break;
                            }

                        case (1):
                            {
                                spriteBatch.Draw(gridUnitTexture, new Rectangle((x * (int)tileSize.X) + (graphics.PreferredBackBufferWidth - (int)mapSize.X * (int)tileSize.X) / 2, (y * (int)tileSize.Y) + (graphics.PreferredBackBufferHeight - (int)mapSize.Y * (int)tileSize.Y) / 2, (int)tileSize.X, (int)tileSize.Y), new Rectangle(frame * 25, 0, (int)tileSize.X, (int)tileSize.Y), Color.White);
                                break;
                            }

                        case (2):
                            {
                                spriteBatch.Draw(gridUnitTexture, new Rectangle((x * (int)tileSize.X) + (graphics.PreferredBackBufferWidth - (int)mapSize.X * (int)tileSize.X) / 2, (y * (int)tileSize.Y) + (graphics.PreferredBackBufferHeight - (int)mapSize.Y * (int)tileSize.Y) / 2, (int)tileSize.X, (int)tileSize.Y), new Rectangle(frame * 25, 0, (int)tileSize.X, (int)tileSize.Y), Color.White);
                                break;
                            }

                        case (3):
                            {
                                spriteBatch.Draw(gridUnitTexture, new Rectangle((x * (int)tileSize.X) + (graphics.PreferredBackBufferWidth - (int)mapSize.X * (int)tileSize.X) / 2, (y * (int)tileSize.Y) + (graphics.PreferredBackBufferHeight - (int)mapSize.Y * (int)tileSize.Y) / 2, (int)tileSize.X, (int)tileSize.Y), new Rectangle(25, 0, (int)tileSize.X, (int)tileSize.Y), Color.White);
                                break;
                            }
                    }
                }
            }
        }
    }
}
