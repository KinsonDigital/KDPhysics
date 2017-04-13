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
        private readonly Texture2D _texture;
        private Vertice _vert1;

        /// <summary>
        /// Creates a new instance of PhysObj.
        /// </summary>
        public PhysObj(GraphicsDevice graphicsDevice, int width, int height, Vector2 position, Color color)
        {
            _aabb = new AABB(width, height, position.ToVect2());

            _texture = new Texture2D(graphicsDevice, width, height);

            //Set the solid color of the texture
            _texture.SetAsSolid(width, height, color);

            _vert1 = new Vertice(graphicsDevice);
            _vert1.Position = _aabb.Vertices[0].ToVector2();
        }

        /// <summary>
        /// The center position of the physics object.
        /// </summary>
        public Vector2 Position
        {
            get => _aabb.Origin.ToVector2();
            set => _aabb.Origin = value.ToVect2();
        }

        /// <summary>
        /// Renders the physics object.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to render the object.</param>
        public void Render(SpriteBatch spriteBatch)
        {
            var renderPosition = new Vector2(_aabb.Origin.X - _aabb.HalfWidth, _aabb.Origin.Y - _aabb.HalfHeight);

            spriteBatch.Draw(_texture, renderPosition, Color.White);
            _vert1.Render(spriteBatch);
        }
    }
}