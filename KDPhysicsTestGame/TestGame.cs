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
        private Texture2D _xAxis;
        private Texture2D _yAxis;
        private PhysObj _boxA;
        private Vect2 _xAxisLocation;
        private Vect2 _yAxisLocation;
        private Vect2 _rotationPoint;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _prevKeyboardState;
        private SpriteFont _font;

        public TestGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 1200;
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
            //Grid Axis Locations
            _xAxisLocation = new Vect2(10, 10);
            _yAxisLocation = new Vect2(10, 10);

            _rotationPoint = new Vect2(225, 120);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _font = Content.Load<SpriteFont>("Font/arial-36");

            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _xAxis = new Texture2D(_graphics.GraphicsDevice, _graphics.PreferredBackBufferWidth - 20, 2);
            _yAxis = new Texture2D(_graphics.GraphicsDevice, 2, _graphics.PreferredBackBufferHeight - 20);

            _xAxis.SetAsSolid(_graphics.PreferredBackBufferWidth - 20, 2, Color.Black);
            _yAxis.SetAsSolid(2, _graphics.PreferredBackBufferHeight - 20, Color.Black);

            _boxA = new PhysObj(_graphics.GraphicsDevice, 50, 50, new Vector2(200, 200), Color.MediumPurple);
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
            else if(_currentKeyboardState.IsKeyDown(Keys.Right))
            {
                _boxA.Position = new Vect2(_boxA.Position.X + 5, _boxA.Position.Y).ToVector2();
            }
            else if(_currentKeyboardState.IsKeyDown(Keys.Up))
            {
                _boxA.Position = new Vect2(_boxA.Position.X, _boxA.Position.Y - 5).ToVector2();
            }
            else if(_currentKeyboardState.IsKeyDown(Keys.Down))
            {
                _boxA.Position = new Vect2(_boxA.Position.X, _boxA.Position.Y + 5).ToVector2();
            }
            else if (_currentKeyboardState.IsKeyDown(Keys.Space))
            {
                _rotationPoint = PMath.RotateVectorAround(_rotationPoint, new Vect2(175, 175), PMath.DegreeToRadian(1) * -1);
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

            //Draw the axis lines
            _spriteBatch.Draw(_xAxis, _xAxisLocation.ToVector2(), Color.White);
            _spriteBatch.Draw(_yAxis, _yAxisLocation.ToVector2(), Color.White);

            _boxA.Render(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}