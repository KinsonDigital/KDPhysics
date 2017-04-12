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
        private Texture2D _boxA;
        private Texture2D _boxB;
        private Vector2 _boxALocation;
        private Vector2 _boxBLocation;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _prevKeyboardState;

        public TestGame()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            _boxALocation = new Vector2(50, 50);
            _boxBLocation = new Vector2(150, 150);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _boxA = new Texture2D(_graphics.GraphicsDevice, 50, 50);
            _boxB = new Texture2D(_graphics.GraphicsDevice, 50, 50);

            _boxA.SetAsSolid(50, 50, Color.DarkSeaGreen);
            _boxB.SetAsSolid(50, 50, Color.IndianRed);
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
                _boxALocation.X -= 5;
            }
            else if(_currentKeyboardState.IsKeyDown(Keys.Right))
            { 
                _boxALocation.X += 5;
            }
            else if(_currentKeyboardState.IsKeyDown(Keys.Up))
            {
                _boxALocation.Y -= 5;
            }
            else if(_currentKeyboardState.IsKeyDown(Keys.Down))
            {
                _boxALocation.Y += 5;
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

            _spriteBatch.Draw(_boxA, _boxALocation, Color.White);
            _spriteBatch.Draw(_boxB, _boxBLocation, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
