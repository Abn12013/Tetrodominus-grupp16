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
    class GameMethod
    {
        private Texture2D orbUnitTexture;
        private Texture2D cubeUnitTexture;
        private Texture2D gameGridTexture;
        int animationTimer;
        int frame;
        public bool orbWin = false;
        public bool cubeWin = false;

        public GameMethod()
        {
            orbUnitTexture = null;
            cubeUnitTexture = null;
            gameGridTexture = null;
            animationTimer = 0;
        }
        public void Load(ContentManager content)
        {
            this.orbUnitTexture = content.Load<Texture2D>("Orb");
            this.cubeUnitTexture = content.Load<Texture2D>("Cube");
            this.gameGridTexture = content.Load<Texture2D>("GameGridUnit");
        }

        public void Tick()
        {
            if (animationTimer == 32)
            {
                if (frame == 3)
                {
                    frame = 0;
                }
                else
                {
                    frame++;
                }
                animationTimer = 0;
            }
            animationTimer++;
        }

        public void Draw(SpriteBatch spriteBatch, GameGrid gameGrid, List<Unit> orbs, List<Unit> cubes, Vector2 spriteSize, Vector2 gameGridDisplacing, Vector2 gridSize)
        {
            for (int y = 4; y < gridSize.Y-4; y++)
            {
                for (int x = 4; x < gridSize.X - 4; x++)
                {
                    
                    spriteBatch.Draw(gameGridTexture, new Rectangle(x * (int)spriteSize.X + (int)gameGridDisplacing.X, y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), new Rectangle (frame*(int)spriteSize.X,0,(int)spriteSize.X,(int)spriteSize.Y), Color.White);
                
                }
            }
            foreach (Unit u in orbs)
            {
                spriteBatch.Draw(orbUnitTexture, new Rectangle((int)u.position.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
            }

            foreach (Unit u in cubes)
            {
                spriteBatch.Draw(cubeUnitTexture, new Rectangle((int)u.position.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
            }
        }

        public void CreateOrbs(List<Unit> orbs, ref GameGrid gameGrid)
        {
            if (!gameGrid.isOccupied[5, 5])
            {
                orbs.Add(new Unit(new Vector2(5, 5)));
                gameGrid.isOccupied[5, 5] = true;
            }
            if (!gameGrid.isOccupied[5, 7])
            {
                orbs.Add(new Unit(new Vector2(5, 7)));
                gameGrid.isOccupied[5, 7] = true;
            }
            if (!gameGrid.isOccupied[5, 10])
            {
                orbs.Add(new Unit(new Vector2(5, 10)));
                gameGrid.isOccupied[5, 10] = true;
            }
            if (!gameGrid.isOccupied[5, 12])
            {
                orbs.Add(new Unit(new Vector2(5, 12)));
                gameGrid.isOccupied[5, 12] = true;
            }
        }

        public void CreateCubes(List<Unit> cubes, ref GameGrid gameGrid)
        {
            if (!gameGrid.isOccupied[34, 5])
            {
                cubes.Add(new Unit(new Vector2(34, 5)));
                gameGrid.isOccupied[34, 5] = true;
            }
            if (!gameGrid.isOccupied[34, 7])
            {
                cubes.Add(new Unit(new Vector2(34, 7)));
                gameGrid.isOccupied[34, 7] = true;
            }
            if (!gameGrid.isOccupied[34, 10])
            {
                cubes.Add(new Unit(new Vector2(34, 10)));
                gameGrid.isOccupied[34, 10] = true;
            }
            if (!gameGrid.isOccupied[34, 12])
            {
                cubes.Add(new Unit(new Vector2(34, 12)));
                gameGrid.isOccupied[34, 12] = true;
            }
        }

        public void RemoveLine(ref GameGrid gameGrid, ref List<Unit> orbUnit, ref List<Unit> cubeUnit)
        {
            int count = 0;
            int column = 0;
            for (int x = 4; x <= 36; x++)
            {
                count = 0;
                for (int y = 4; y <= 14; y++)
                {
                    if (gameGrid.isOccupied[x, y] == true)
                    {
                        count++;
                        if (count == 10)
                        {
                            if (x == 4)
                                cubeWin = true;
                            if (x == 35)
                                orbWin = true;
                            column = x;
                            int counter = 0;
                            int unitCount = orbUnit.Count;
                            int tempY = 0;
                            int tempX = 0;
                            for (int i = 0; counter < unitCount; i++)
                            {
                                counter++;
                                if (orbUnit.ElementAt(i).position.X == column)
                                {
                                    tempY = (int)orbUnit.ElementAt(i).position.Y;
                                    tempX = (int)orbUnit.ElementAt(i).position.X;
                                    if (gameGrid.isOccupied[tempX, tempY] == true)
                                    {
                                        gameGrid.isOccupied[tempX, tempY] = false;
                                    }
                                    orbUnit.RemoveAt(i);
                                    i--;
                                }
                                
                            }
                            counter = 0;
                            unitCount = cubeUnit.Count;
                            for (int i = 0; counter < unitCount; i++)
                            {
                                counter++;
                                if (cubeUnit.ElementAt(i).position.X == column)
                                {
                                    tempY = (int)cubeUnit.ElementAt(i).position.Y;
                                    tempX = (int)cubeUnit.ElementAt(i).position.X;
                                    if (gameGrid.isOccupied[tempX, tempY] == true)
                                    {
                                        gameGrid.isOccupied[tempX, tempY] = false;
                                    }
                                    cubeUnit.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
