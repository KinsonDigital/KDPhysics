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

        /// <summary>
        /// Creates a new instance of PhysObj.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device to use to render the PhysObj.</param>
        /// <param name="width">The width of the PhysObj.</param>
        /// <param name="height">The height of the PhysObj.</param>
        /// <param name="position">The position to render the PhysObj.</param>
        /// <param name="color">The color to render the PhysObj.</param>
        public PhysObj(GraphicsDevice graphicsDevice, int width, int height, Vector2 position, Color color)
        {
            _aabb = new AABB(width, height, position.ToVect2());

            _texture = new Texture2D(graphicsDevice, width, height);

            //Set the solid color of the texture
            _texture.SetAsSolid(width, height, color);

            Vertices = new VerticeTexture[4];

            var colors = new Color[4];

            colors[0] = Color.Red;
            colors[1] = Color.LimeGreen;
            colors[2] = Color.White;
            colors[3] = Color.Black;

            for (var i = 0; i < 4; i++)
            {
                Vertices[i] = new VerticeTexture(graphicsDevice, colors[i])
                {
                    Position = _aabb.Vertices[i].ToVector2(),
                };
            }

            //Override the names of the private _aabb vertice members
            _aabb.Vertices[0].Name = "Red Vertice 1";
            _aabb.Vertices[1].Name = "Green Vertice 2";
            _aabb.Vertices[2].Name = "White Vertice 3";
            _aabb.Vertices[3].Name = "Black Vertice 4";
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
        /// Gets the vertice that is farthest to the right then the rest of the vertices.
        /// </summary>
        public Vector2 FarthestRightVertice => _aabb.FarthestRightVertice.ToVector2();

        /// <summary>
        /// Gets the vertice that is farthest to the left then the rest of the vertices.
        /// </summary>
        public Vector2 FarthestLeftVertice => _aabb.FarthestLeftVertice.ToVector2();

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
        /// Gets the ToString() representation of the vertice with the given index.
        /// </summary>
        /// <param name="index">The index of the vertice to get.</param>
        /// <returns></returns>
        public string GetVerticeToString(int index)
        {
            return _aabb.Vertices[index].ToString();
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