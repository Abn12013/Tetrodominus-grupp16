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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyboardState = new KeyboardState();
        KeyboardState prevKeyboardState = new KeyboardState();
        MouseState mouseState = new MouseState();
        MouseState prevMouseState = new MouseState();
        GameMethod gameMethod = new GameMethod();

        List<Unit> orbUnit = new List<Unit>();
        List<Unit> cubeUnit = new List<Unit>();

        Vector2 spriteSize = new Vector2(25, 25);
        Vector2 gridSize = new Vector2(40, 18);
        Vector2 resolution;
        Vector2 gameGridDisplacing;
        GameGrid gameGrid;

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
            if (keyboardState.IsKeyDown(Keys.Q) && prevKeyboardState.IsKeyUp(Keys.Q))
            {
                gameMethod.CreateUnits(orbUnit, cubeUnit, gameGrid);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            gameMethod.Draw(spriteBatch, gameGrid, orbUnit, cubeUnit, spriteSize, gameGridDisplacing, gridSize);

            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
