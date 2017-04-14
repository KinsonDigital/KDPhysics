using System;
using KDPhysics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KDPhysicsTestGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TestGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _refBox;
        private PhysObj _boxA;
        private Axis _xAxis;
        private Axis _yAxis;
        private Vector2 _refBoxLocation;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _prevKeyboardState;
        private SpriteFont _font;
        private Stats _objStats;

        public TestGame()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1200,
                PreferredBackBufferHeight = 900
            };

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            IsMouseVisible = true;

            _refBoxLocation = new Vector2(400, 400);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _font = Content.Load<SpriteFont>("Font/arial-36");
            _objStats = new Stats(Content, new Vector2(_graphics.PreferredBackBufferWidth - 220,50));

            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _refBox = new Texture2D(_graphics.GraphicsDevice, 100, 100);
            _refBox.SetAsSolid(100, 100, Color.Red);

            _boxA = new PhysObj(_graphics.GraphicsDevice, 150, 50, new Vector2(200, 200), Color.MediumPurple);
            _boxA.Name = "Box-A";

            _xAxis = new Axis(_graphics.GraphicsDevice, Content, AxisType.XAxis, new Vector2(60, _graphics.PreferredBackBufferHeight - 40), _graphics.PreferredBackBufferWidth - 70, "X Axis", Color.Black, Color.Black);
            _yAxis = new Axis(_graphics.GraphicsDevice, Content, AxisType.YAxis, new Vector2(60, 20), _graphics.PreferredBackBufferHeight - 60, "Y Axis", Color.Black, Color.Black);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            _currentKeyboardState = Keyboard.GetState();

            //If the left key has been pressed
            if (_currentKeyboardState.IsKeyDown(Keys.Left))
            {
                _boxA.Position = new Vect2(_boxA.Position.X - 5, _boxA.Position.Y).ToVector2();
            }

            if (_currentKeyboardState.IsKeyDown(Keys.Right))
            {
                _boxA.Position = new Vect2(_boxA.Position.X + 5, _boxA.Position.Y).ToVector2();
            }

            if (_currentKeyboardState.IsKeyDown(Keys.Up))
            {
                _boxA.Position = new Vect2(_boxA.Position.X, _boxA.Position.Y - 5).ToVector2();
            }

            if (_currentKeyboardState.IsKeyDown(Keys.Down))
            {
                _boxA.Position = new Vect2(_boxA.Position.X, _boxA.Position.Y + 5).ToVector2();
            }

            if (_currentKeyboardState.IsKeyDown(Keys.Space))
            {
                _boxA.Angle += 1;
            }

            _prevKeyboardState = _currentKeyboardState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            
            _spriteBatch.DrawString(_font, "Hello World", new Vector2(200,200), Color.Black);

            //Draw reference box
            _spriteBatch.Draw(_refBox, _refBoxLocation, Color.White);

            //Draw the axis lines
            _xAxis.Render(_spriteBatch);
            _yAxis.Render(_spriteBatch);

            _boxA.Render(_spriteBatch);

            _objStats.Render(_spriteBatch, new [] {_boxA}, new []{Color.Black});

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}