using System;
using System.Collections.Generic;
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
        private Axis _xAxis;
        private Axis _yAxis;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _prevKeyboardState;
        private SpriteFont _font;

        private PolyObject _orangePoly;
        private PolyObject _purplePoly;

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

            _refBox = new Texture2D(_graphics.GraphicsDevice, 100, 100);
            _refBox.SetAsSolid(100, 100, Color.Red);

            _xAxis = new Axis(_graphics.GraphicsDevice, Content, AxisType.XAxis, new Vector2(60, _graphics.PreferredBackBufferHeight - 40), _graphics.PreferredBackBufferWidth - 70, "X Axis", Color.Black, Color.Black);
            _yAxis = new Axis(_graphics.GraphicsDevice, Content, AxisType.YAxis, new Vector2(60, 20), _graphics.PreferredBackBufferHeight - 60, "Y Axis", Color.Black, Color.Black);

            //Create the orange poly verts
            var orangePolyVerts = new List<Vect2>
            {
                new Vect2(53, 0),
                new Vect2(99, 11),
                new Vect2(66, 99),
                new Vect2(0, 44)
            };
            _orangePoly = new PolyObject(Content, orangePolyVerts, new Vect2(0, 0), "OrangePoly")
            {
                MovementLocked = false
            };

            var purplePolyVerts = new List<Vect2>
            {
                new Vect2(25, 0),
                new Vect2(54, 3),
                new Vect2(84, 22),
                new Vect2(88, 68),
                new Vect2(70, 95),
                new Vect2(12, 99),
                new Vect2(0, 33)
            };
            //Create the purple poly verts
            _purplePoly = new PolyObject(Content, purplePolyVerts, new Vect2(0, 0), "PurplePoly")
            {
                MovementLocked = true
            };
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
            if (_currentKeyboardState.IsKeyDown(Keys.M) && _prevKeyboardState.IsKeyUp(Keys.M))
            {
                _orangePoly.MovementLocked = ! _orangePoly.MovementLocked;
                _purplePoly.MovementLocked = ! _purplePoly.MovementLocked;
            }

            _prevKeyboardState = _currentKeyboardState;

            _orangePoly.Update();
            _purplePoly.Update();
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
            
            //Draw the axis lines
            _xAxis.Render(_spriteBatch);
            _yAxis.Render(_spriteBatch);

            //Render the orange poly and related info
            _orangePoly.Render(_spriteBatch);

            //Render position
            _spriteBatch.DrawString(_font, $"Orange Pos: {_orangePoly.Position.X} : {_orangePoly.Position.Y}", new Vector2(800, 100), Color.Black);

            //Render the angle
            _spriteBatch.DrawString(_font, $"Orange Angle: {_orangePoly.Angle}", new Vector2(800, 125), Color.Black);

            //Render the purple poly and related info
            _purplePoly.Render(_spriteBatch);

            //Render position
            _spriteBatch.DrawString(_font, $"Purple Pos: {_purplePoly.Position.X} : {_purplePoly.Position.Y}", new Vector2(800, 200), Color.Black);

            //Render the angle
            _spriteBatch.DrawString(_font, $"Purple Angle: {_purplePoly.Angle}", new Vector2(800, 225), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}