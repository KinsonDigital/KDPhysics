using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KDPhysicsTestGame
{
    /// <summary>
    /// Represents a vertice to be drawn on the screen.
    /// </summary>
    public class VerticeTexture
    {
        private readonly Texture2D _texture;

        /// <summary>
        /// Creates a new instance of Vertice.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device for rendering the vertice.</param>
        public VerticeTexture(GraphicsDevice graphicsDevice)
        {
            //Create the vertice
            _texture = new Texture2D(graphicsDevice, 6, 6);
            _texture.SetAsSolid(6, 6, Color.Black);
        }

        /// <summary>
        /// The position of the center of the vertice texture.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Renders the vertice to the screen using the given sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for rendering.</param>
        public void Render(SpriteBatch spriteBatch)
        {
            var offSetPosition = new Vector2(Position.X - 3, Position.Y - 3);

            spriteBatch.Draw(_texture, offSetPosition, Color.White);
        }
    }
}