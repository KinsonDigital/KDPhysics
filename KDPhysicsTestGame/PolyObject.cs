using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDPhysics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KDPhysicsTestGame
{
    public class PolyObject
    {
        private readonly Polygon _poly;
        private readonly Texture2D _texture;
        private readonly Vector2 _originOffset;

        public PolyObject(ContentManager contentMgr, List<Vect2> vertices, Vect2 worldPosition)
        {
            _texture = contentMgr.Load<Texture2D>("Graphics/Polygon");

            _poly = new Polygon(vertices, worldPosition);

            //Create the origin offset
            _originOffset = new Vector2()
            {
                X = Math.Abs((_poly.Right - Position.X) - (Position.X - _poly.Left)) / 2f,
                Y = Math.Abs((_poly.Bottom - Position.Y) - (Position.Y - _poly.Top)) / 2f
            };
        }

        /// <summary>
        /// The angle of the polygon in degrees.
        /// </summary>
        public float Angle
        {
            get => PMath.RadianToDegree(_poly.Angle);
            set
            {
                value = value > 360 ? value - 360 : value;

                _poly.Angle = PMath.DegreeToRadian(value);
            } 
        }

        /// <summary>
        /// Gets or sets the position of the poly object.
        /// </summary>
        public Vect2 Position
        {
            get => _poly.Position;
            set => _poly.Position = value;
        }

        /// <summary>
        /// Renders the polygon object.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the polygon.</param>
        public void Render(SpriteBatch spriteBatch)
        {
            var srcRect = new Rectangle(0, 0, _texture.Width, _texture.Height);

            var origin = new Vector2(_texture.Width / 2f, _texture.Height / 2f);

            origin.X += _originOffset.X;
            origin.Y -= _originOffset.Y;

            //Render the texture
            spriteBatch.Draw(_texture, Position.ToVector2(), srcRect, Color.White, _poly.Angle, origin, 1.0f, SpriteEffects.None, 1f);

            //Render border to see where the physics polygon is in relation to the texture
            for (var i = 0; i < _poly.Vertices.Count; i++)
            {
                spriteBatch.DrawLine(_poly.Vertices[i].ToVector2(), _poly.Vertices[i < _poly.Vertices.Count - 1 ? i + 1 : 0].ToVector2(), Color.Green, 2f);
            }

            //Render the center
            spriteBatch.FillRectangle(new Rectangle((int)(_poly.Position.X - 2.5f), (int)(_poly.Position.Y - 2.5f), 5, 5), Color.Black);
        }
    }
}