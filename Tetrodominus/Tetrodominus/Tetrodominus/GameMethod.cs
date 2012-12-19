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

        public void Draw(SpriteBatch spriteBatch, GameGrid gameGrid, List<Unit> orbs, List<Unit> cubes, Vector2 spriteSize, Vector2 gameGridDisplacing, Vector2 gridSize, List<CombinedUnit> orbCombo, List<CombinedUnit> cubeCombo)
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

            foreach (CombinedUnit u in orbCombo)
            {
                spriteBatch.Draw(orbUnitTexture, new Rectangle((int)u.position1.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position1.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
                spriteBatch.Draw(orbUnitTexture, new Rectangle((int)u.position2.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position2.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
                spriteBatch.Draw(orbUnitTexture, new Rectangle((int)u.position3.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position3.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
                spriteBatch.Draw(orbUnitTexture, new Rectangle((int)u.position4.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position4.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
            }

            foreach (Unit u in cubes)
            {
                spriteBatch.Draw(cubeUnitTexture, new Rectangle((int)u.position.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
            }

            foreach (CombinedUnit u in cubeCombo)
            {
                spriteBatch.Draw(cubeUnitTexture, new Rectangle((int)u.position1.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position1.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
                spriteBatch.Draw(cubeUnitTexture, new Rectangle((int)u.position2.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position2.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
                spriteBatch.Draw(cubeUnitTexture, new Rectangle((int)u.position3.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position3.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
                spriteBatch.Draw(cubeUnitTexture, new Rectangle((int)u.position4.X * (int)spriteSize.X + (int)gameGridDisplacing.X, (int)u.position4.Y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y), Color.White);
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

        public void RemoveLine(ref GameGrid gameGrid, ref List<Unit> orbUnit, ref List<Unit> cubeUnit, ref List<CombinedUnit> orbCombo, ref List<CombinedUnit> cubeCombo)
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
                            int tempY = 0;
                            int tempX = 0;
                            int unitCount = orbCombo.Count;
                            for (int i = 0; counter < unitCount; i++)
                            {
                                counter++;
                                if (orbCombo.ElementAt(i).position1.X == column ||
                                    orbCombo.ElementAt(i).position2.X == column ||
                                    orbCombo.ElementAt(i).position3.X == column ||
                                    orbCombo.ElementAt(i).position4.X == column)
                                {
                                    orbUnit.Add(new Unit(orbCombo.ElementAt(i).position1));
                                    orbUnit.Add(new Unit(orbCombo.ElementAt(i).position2));
                                    orbUnit.Add(new Unit(orbCombo.ElementAt(i).position3));
                                    orbUnit.Add(new Unit(orbCombo.ElementAt(i).position4));
                                    orbCombo.RemoveAt(i);
                                    i--;
                                }
                            }
                            unitCount = cubeCombo.Count;
                            counter = 0;
                            for (int i = 0; counter < unitCount; i++)
                            {
                                counter++;
                                if (cubeCombo.ElementAt(i).position1.X == column ||
                                    cubeCombo.ElementAt(i).position2.X == column ||
                                    cubeCombo.ElementAt(i).position3.X == column ||
                                    cubeCombo.ElementAt(i).position4.X == column)
                                {
                                    cubeUnit.Add(new Unit(cubeCombo.ElementAt(i).position1));
                                    cubeUnit.Add(new Unit(cubeCombo.ElementAt(i).position2));
                                    cubeUnit.Add(new Unit(cubeCombo.ElementAt(i).position3));
                                    cubeUnit.Add(new Unit(cubeCombo.ElementAt(i).position4));
                                    cubeCombo.RemoveAt(i);
                                    i--;
                                }
                            }
                            unitCount = orbUnit.Count;
                            counter = 0;
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
        public void Combine(ref GameGrid gameGrid, ref List<Unit> orbUnit, ref List<Unit> cubeUnit, ref List<CombinedUnit> orbCombo, ref List<CombinedUnit> cubeCombo)
        {
            for (int i = 0; i < orbUnit.Count; i++)
            {
                int temp1 = 0, temp2 = 0, temp3 = 0, temp4 = 0;
                Vector2 position1 = new Vector2(0, 0), position2 = new Vector2(0, 0), position3 = new Vector2(0, 0), position4 = new Vector2(0, 0);
                position1 = orbUnit.ElementAt(i).position;
                int counter = 0;
                for (int a = 0; a < orbUnit.Count; a++)
                {
                    bool add = false;
                    if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y)
                    {
                        add = true;
                    }
                    else if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X + 1 &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y)
                    {
                        position2 = orbUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y + 1)
                    {
                        position3 = orbUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X + 1 &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y + 1)
                    {
                        position4 = orbUnit.ElementAt(a).position;
                        add = true;
                    }
                    if (add == true)
                        if (counter == 0)
                        {
                            temp1 = a;
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            temp2 = a;
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            temp3 = a;
                            counter++;
                        }
                        else
                        {
                            temp4 = a;
                            counter++;
                        }
                        
                }
                if (counter == 4)
                {
                    orbCombo.Add(new CombinedUnit(position1, position2, position3, position4, "bomb"));
                    orbUnit.RemoveAt(temp4);
                    orbUnit.RemoveAt(temp3);
                    orbUnit.RemoveAt(temp2);
                    orbUnit.RemoveAt(temp1);
                }
                counter = 0;
                for (int a = 0; a < orbUnit.Count; a++)
                {
                    bool add = false;
                    if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y)
                    {
                        add = true;
                    }
                    else if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y + 1)
                    {
                        position2 = orbUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y + 2)
                    {
                        position3 = orbUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y + 3)
                    {
                        position4 = orbUnit.ElementAt(a).position;
                        add = true;
                    }
                    if (add == true)
                        if (counter == 0)
                        {
                            temp1 = a;
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            temp2 = a;
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            temp3 = a;
                            counter++;
                        }
                        else
                        {
                            temp4 = a;
                            counter++;
                        }

                }
                if (counter == 4)
                {
                    orbCombo.Add(new CombinedUnit(position1, position2, position3, position4, "wall"));
                    orbUnit.RemoveAt(temp4);
                    orbUnit.RemoveAt(temp3);
                    orbUnit.RemoveAt(temp2);
                    orbUnit.RemoveAt(temp1);
                    break;
                }
                counter = 0;
                for (int a = 0; a < orbUnit.Count; a++)
                {
                    bool add = false;
                    if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y)
                    {
                        add = true;
                    }
                    else if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X + 1 &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y)
                    {
                        position2 = orbUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X + 2 &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y)
                    {
                        position3 = orbUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (orbUnit.ElementAt(a).position.X == orbUnit.ElementAt(i).position.X + 3 &&
                        orbUnit.ElementAt(a).position.Y == orbUnit.ElementAt(i).position.Y)
                    {
                        position4 = orbUnit.ElementAt(a).position;
                        add = true;
                    }
                    if (add == true)
                        if (counter == 0)
                        {
                            temp1 = a;
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            temp2 = a;
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            temp3 = a;
                            counter++;
                        }
                        else
                        {
                            temp4 = a;
                            counter++;
                        }

                }
                if (counter == 4)
                {
                    orbCombo.Add(new CombinedUnit(position1, position2, position3, position4, "missile"));
                    orbUnit.RemoveAt(temp4);
                    orbUnit.RemoveAt(temp3);
                    orbUnit.RemoveAt(temp2);
                    orbUnit.RemoveAt(temp1);
                    break;
                }
                counter = 0;
            }
            for (int i = 0; i < cubeUnit.Count; i++)
            {
                int temp1 = 0, temp2 = 0, temp3 = 0, temp4 = 0;
                Vector2 position1 = new Vector2(0, 0), position2 = new Vector2(0, 0), position3 = new Vector2(0, 0), position4 = new Vector2(0, 0);
                position1 = cubeUnit.ElementAt(i).position;
                int counter = 0;
                for (int a = 0; a < cubeUnit.Count; a++)
                {
                    bool add = false;
                    if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y)
                    {
                        add = true;
                    }
                    else if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X + 1 &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y)
                    {
                        position2 = cubeUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y + 1)
                    {
                        position3 = cubeUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X + 1 &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y + 1)
                    {
                        position4 = cubeUnit.ElementAt(a).position;
                        add = true;
                    }
                    if (add == true)
                        if (counter == 0)
                        {
                            temp1 = a;
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            temp2 = a;
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            temp3 = a;
                            counter++;
                        }
                        else
                        {
                            temp4 = a;
                            counter++;
                        }

                }
                if (counter == 4)
                {
                    cubeCombo.Add(new CombinedUnit(position1, position2, position3, position4, "bomb"));
                    cubeUnit.RemoveAt(temp4);
                    cubeUnit.RemoveAt(temp3);
                    cubeUnit.RemoveAt(temp2);
                    cubeUnit.RemoveAt(temp1);
                    break;
                }
                counter = 0;
                for (int a = 0; a < cubeUnit.Count; a++)
                {
                    bool add = false;
                    if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y)
                    {
                        add = true;
                    }
                    else if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y + 1)
                    {
                        position2 = cubeUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y + 2)
                    {
                        position3 = cubeUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y + 3)
                    {
                        position4 = cubeUnit.ElementAt(a).position;
                        add = true;
                    }
                    if (add == true)
                        if (counter == 0)
                        {
                            temp1 = a;
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            temp2 = a;
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            temp3 = a;
                            counter++;
                        }
                        else
                        {
                            temp4 = a;
                            counter++;
                        }

                }
                if (counter == 4)
                {
                    cubeCombo.Add(new CombinedUnit(position1, position2, position3, position4, "wall"));
                    cubeUnit.RemoveAt(temp4);
                    cubeUnit.RemoveAt(temp3);
                    cubeUnit.RemoveAt(temp2);
                    cubeUnit.RemoveAt(temp1);
                    break;
                }
                counter = 0;
                for (int a = 0; a < cubeUnit.Count; a++)
                {
                    bool add = false;
                    if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y)
                    {
                        add = true;
                    }
                    else if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X + 1 &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y)
                    {
                        position2 = cubeUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X + 2 &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y)
                    {
                        position3 = cubeUnit.ElementAt(a).position;
                        add = true;
                    }
                    else if (cubeUnit.ElementAt(a).position.X == cubeUnit.ElementAt(i).position.X + 3 &&
                        cubeUnit.ElementAt(a).position.Y == cubeUnit.ElementAt(i).position.Y)
                    {
                        position4 = cubeUnit.ElementAt(a).position;
                        add = true;
                    }
                    if (add == true)
                        if (counter == 0)
                        {
                            temp1 = a;
                            counter++;
                        }
                        else if (counter == 1)
                        {
                            temp2 = a;
                            counter++;
                        }
                        else if (counter == 2)
                        {
                            temp3 = a;
                            counter++;
                        }
                        else
                        {
                            temp4 = a;
                            counter++;
                        }

                }
                if (counter == 4)
                {
                    cubeCombo.Add(new CombinedUnit(position1, position2, position3, position4, "missile"));
                    cubeUnit.RemoveAt(temp4);
                    cubeUnit.RemoveAt(temp3);
                    cubeUnit.RemoveAt(temp2);
                    cubeUnit.RemoveAt(temp1);
                    break;
                }
                counter = 0;
            }
        }
    }
}
