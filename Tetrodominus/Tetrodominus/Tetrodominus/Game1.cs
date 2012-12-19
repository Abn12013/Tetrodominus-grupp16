using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Tetrodominus
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        enum GameState {orbTransition, orbTurn, cubeTransition, cubeTurn, orbWin, cubeWin};
        GameState currentGameState = GameState.orbTransition;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyboardState = new KeyboardState();
        KeyboardState prevKeyboardState = new KeyboardState();
        MouseState mouseState = new MouseState();
        MouseState prevMouseState = new MouseState();
        GameMethod gameMethod = new GameMethod();

        List<Unit> orbUnit = new List<Unit>();
        List<Unit> cubeUnit = new List<Unit>();
        List<Rectangle> clickBox = new List<Rectangle>();

        Vector2 spriteSize = new Vector2(25, 25);
        Vector2 gridSize = new Vector2(40, 18);
        Vector2 resolution;
        Vector2 gameGridDisplacing;
        Vector2 mouseCoordinate;
        GameGrid gameGrid;
        SpriteFont segoe;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 880;
            graphics.PreferredBackBufferHeight = 660;
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            resolution = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            gameGrid = new GameGrid(gridSize);
            gameGridDisplacing = new Vector2((resolution.X - spriteSize.X * gridSize.X) / 2, (resolution.Y - spriteSize.Y * gridSize.Y) / 2);
            gameGrid.Initialize(gridSize);
            for (int y = 4; y < 14; y++)
            {
                for (int x = 4; x < 36; x++)
                {
                    clickBox.Add(new Rectangle(x * (int)spriteSize.X + (int)gameGridDisplacing.X, y * (int)spriteSize.Y + (int)gameGridDisplacing.Y, (int)spriteSize.X, (int)spriteSize.Y));
                }
            }
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameMethod.Load(Content);
            segoe = Content.Load<SpriteFont>("segoe");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
                this.Exit();
            for (int i = 0; i < 320; i++)
            {
                if (mouseState.X < clickBox.ElementAt(i).Right && mouseState.X > clickBox.ElementAt(i).Left &&
                    mouseState.Y < clickBox.ElementAt(i).Bottom && mouseState.Y > clickBox.ElementAt(i).Top)
                {
                    mouseCoordinate = new Vector2((i % 32)+4, (i / 32)+4);
                }
                    
            }

            switch (currentGameState)
            {
                case GameState.orbTransition:
                    gameMethod.CreateOrbs(orbUnit, ref gameGrid);
                    foreach (Unit orb in orbUnit)
                    {
                        orb.step = 4;
                        orb.free = true;
                    }
                    currentGameState = GameState.orbTurn;
                    break;
                case GameState.cubeTransition:
                    gameMethod.CreateCubes(cubeUnit, ref gameGrid);
                    foreach (Unit cube in cubeUnit)
                    {
                        cube.step = 4;
                        cube.free = true;
                    }
                    currentGameState = GameState.cubeTurn;
                    break;
                case GameState.orbWin:
                    if (keyboardState.IsKeyDown(Keys.Enter) && prevKeyboardState.IsKeyUp(Keys.Enter))
                    {
                        orbUnit.Clear();
                        cubeUnit.Clear();
                        for (int x = 4; x <= 36; x++)
                        {
                            for (int y = 4; y <= 14; y++)
                            {
                                gameGrid.isOccupied[x, y] = false;
                            }
                        }
                        gameMethod.orbWin = false;
                        currentGameState = GameState.orbTransition;
                    }
                    break;
                case GameState.cubeWin:
                    if (keyboardState.IsKeyDown(Keys.Enter) && prevKeyboardState.IsKeyUp(Keys.Enter))
                    {
                        orbUnit.Clear();
                        cubeUnit.Clear();
                        for (int x = 4; x <= 36; x++)
                        {
                            for (int y = 4; y <= 14; y++)
                            {
                                gameGrid.isOccupied[x, y] = false;
                            }
                        }
                        gameMethod.cubeWin = false;
                        currentGameState = GameState.orbTransition;
                    }
                    break;
                case GameState.orbTurn:
                    if (keyboardState.IsKeyDown(Keys.Enter) && prevKeyboardState.IsKeyUp(Keys.Enter))
                        currentGameState = GameState.cubeTransition;

                    if (mouseState.LeftButton == (Microsoft.Xna.Framework.Input.ButtonState.Pressed) &&
                        prevMouseState.LeftButton == (Microsoft.Xna.Framework.Input.ButtonState.Released))
                        foreach (Unit orb in orbUnit)
                            if (orb.position == mouseCoordinate)
                                if (orb.free)
                                    orb.follow = true;
                    
                    foreach (Unit orb in orbUnit)
                        if (orb.follow == true)
                            orb.Behavior(mouseCoordinate, ref gameGrid.isOccupied);
                    break;
                case GameState.cubeTurn:
                    if (keyboardState.IsKeyDown(Keys.Enter) && prevKeyboardState.IsKeyUp(Keys.Enter))
                        currentGameState = GameState.orbTransition;
                    if (mouseState.LeftButton == (Microsoft.Xna.Framework.Input.ButtonState.Pressed) &&
                        prevMouseState.LeftButton == (Microsoft.Xna.Framework.Input.ButtonState.Released))
                        foreach (Unit cube in cubeUnit)
                            if (cube.position == mouseCoordinate)
                                if (cube.free)
                                    cube.follow = true;
                            
                    foreach (Unit cube in cubeUnit)
                        if (cube.follow == true)
                            cube.Behavior(mouseCoordinate, ref gameGrid.isOccupied);

                    break;
            }
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                        prevMouseState.LeftButton == (Microsoft.Xna.Framework.Input.ButtonState.Pressed))
            {
                foreach (Unit orb in orbUnit)
                {
                    if (orb.follow == true)
                        orb.free = false;
                    orb.follow = false;
                }
                foreach (Unit cube in cubeUnit)
                {
                    if (cube.follow == true)
                        cube.free = false;
                    cube.follow = false;
                }
                gameMethod.RemoveLine(ref gameGrid, ref orbUnit, ref cubeUnit);
                if (gameMethod.orbWin)
                    currentGameState = GameState.orbWin;
                if (gameMethod.cubeWin)
                    currentGameState = GameState.cubeWin;
            }

            gameMethod.Tick();

            // TODO: Add your update logic here
            prevKeyboardState = keyboardState;
            prevMouseState = mouseState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            switch (currentGameState)
            {
                case GameState.cubeWin:
                    spriteBatch.DrawString(segoe, "BLUE WINS", new Vector2(200, 10), Color.White);
                    break;
                case GameState.orbWin:
                    spriteBatch.DrawString(segoe, "RED WINS", new Vector2(200, 10), Color.White);
                    break;
            }

            spriteBatch.DrawString(segoe, mouseCoordinate.X + ":" + mouseCoordinate.Y, new Vector2(0, 0), Color.White);
            gameMethod.Draw(spriteBatch, gameGrid, orbUnit, cubeUnit, spriteSize, gameGridDisplacing, gridSize);

            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
