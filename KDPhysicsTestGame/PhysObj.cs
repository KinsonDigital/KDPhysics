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
        private VerticeTexture _vert1;

        /// <summary>
        /// Creates a new instance of PhysObj.
        /// </summary>
        public PhysObj(GraphicsDevice graphicsDevice, int width, int height, Vector2 position, Color color)
        {
            _aabb = new AABB(width, height, position.ToVect2());

            _texture = new Texture2D(graphicsDevice, width, height);

            //Set the solid color of the texture
            _texture.SetAsSolid(width, height, color);

            Vertices = new VerticeTexture[4];

            for (var i = 0; i < 4; i++)
            {
                Vertices[i] = new VerticeTexture(graphicsDevice) {Position = _aabb.Vertices[i].ToVector2()};
            }
        }


        /// <summary>
        /// The name to assign to the physics object.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The four vertices of the physics object.
        /// </summary>
        public VerticeTexture[] Vertices { get; }

        /// <summary>
        /// The center position of the physics object.
        /// </summary>
        public Vector2 Position
        {
            get => _aabb.Origin.ToVector2();
            set
            {
                _aabb.Origin = value.ToVect2();

                UpdateVerticeTextures();
            }
        }

        /// <summary>
        /// The angle to set the physics object to in degrees.
        /// </summary>
        public float Angle
        {
            get => PMath.RadianToDegree(_aabb.Angle);
            set
            {
                _aabb.Angle = PMath.DegreeToRadian(value);
                UpdateVerticeTextures();
            }
        }

        /// <summary>
        /// Renders the physics object.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to render the object.</param>
        public void Render(SpriteBatch spriteBatch)
        {
            var srcRect = new Rectangle(0, 0, (int)_aabb.Width, (int)_aabb.Height);

            var origin = new Vector2(_aabb.HalfWidth, _aabb.HalfHeight);

            spriteBatch.Draw(_texture, _aabb.Origin.ToVector2(), srcRect, Color.White, _aabb.Angle, origin, 1.0f, SpriteEffects.None, 1f);

            foreach (var vert in Vertices)
            {
                vert.Render(spriteBatch);
            }
        }

        /// <summary>
        /// Updates the positions of the vertice textures.
        /// </summary>
        private void UpdateVerticeTextures()
        {
            for (var i = 0; i < 4; i++)
            {
                Vertices[i].Position = _aabb.Vertices[i].ToVector2();
            }
        }
    }
}