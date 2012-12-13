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

        MouseState mouseState = new MouseState();
        MouseState previousMouseState = new MouseState();
        KeyboardState keyboardState = new KeyboardState();
        KeyboardState previousKeyboardState = new KeyboardState();
        Vector2 mousePosition = new Vector2();
        Vector2 prevMouseCoordinate = new Vector2();
        Vector2 mouseCoordinate = new Vector2();

        Grid grid = new Grid();
        Unit unitMethod = new Unit();
        Unit[,] units = new Unit[40, 18];
        List<Unit> Orbs = new List<Unit>();
        List<Unit> Cubes = new List<Unit>();

        Texture2D background;
        SpriteFont lucidaConsole;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 750;
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
            unitMethod.initialize(units, grid.mapSize, grid.tileSize, Content, graphics);
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

            grid.loadContent(Content);

            background = Content.Load<Texture2D>("Temp_Bkg");

            lucidaConsole = Content.Load<SpriteFont>("LucidaConsole");

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
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            grid.tick(gameTime);

            // Allows the game to exit

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (keyboardState.IsKeyDown(Keys.C) && previousKeyboardState.IsKeyUp(Keys.C))
            {
                unitMethod.createUnitsCircle(units, Content, ref Orbs);
            }

            if (keyboardState.IsKeyDown(Keys.Q) && previousKeyboardState.IsKeyUp(Keys.Q))
            {
                unitMethod.createUnitsSquare(units, Content);
            }

            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && previousMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
            }

            for (int y = 4; y < grid.mapSize.Y - 4; y++)
            {
                for (int x = 4; x < grid.mapSize.X - 4; x++)
                {
                    if (mousePosition.X > units[x, y].box.Right && mousePosition.X < units[x, y].box.Left && mousePosition.Y > units[x, y].box.Bottom && mousePosition.Y < units[x, y].box.Top)
                        mouseCoordinate = units[x, y].position;
                }
            }

            // TODO: Add your update logic here

            previousMouseState = mouseState;
            previousKeyboardState = keyboardState;

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

            spriteBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            grid.draw(graphics, spriteBatch);

            unitMethod.Draw(units, graphics, spriteBatch, grid.mapSize, grid.tileSize);

            spriteBatch.DrawString(lucidaConsole, mouseCoordinate.X + ":" + mouseCoordinate.Y, new Vector2(0, 0), Color.White);

            // TODO: Add your drawing code here

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
