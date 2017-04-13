using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDPhysics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KDPhysicsTestGame
{
    public class PhysObj
    {
        private AABB _aabb;//The axis aligned bounding box of the physics object
        private Texture2D _texture;


        /// <summary>
        /// Creates a new instance of PhysObj.
        /// </summary>
        public PhysObj(GraphicsDevice graphicsDevice, int width, int height, Color color)
        {
            _texture = new Texture2D(graphicsDevice, width, height);

            //Set the solid color of the texture
            _texture.SetAsSolid(width, height, color);
        }

        /// <summary>
        /// The center position of the physics object.
        /// </summary>
        public Vector2 Position
        {
            get => _aabb.Center.ToVector2();
            set => _aabb.Center = value.ToVect2();
        }


        /// <summary>
        /// Renders the physics object.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to render the object.</param>
        public void Render(SpriteBatch spriteBatch)
        {
            var renderPosition = new Vector2(_aabb.Min.X - _aabb.HalfWidth, _aabb.Min.Y - _aabb.HalfHeight);
            spriteBatch.Draw(_texture, renderPosition, Color.White);
        }
    }
}