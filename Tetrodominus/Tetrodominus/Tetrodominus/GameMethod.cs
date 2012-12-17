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

        public void CreateUnits(List<Unit> orbs, List<Unit> cubes, ref GameGrid gameGrid)
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
    }
}
