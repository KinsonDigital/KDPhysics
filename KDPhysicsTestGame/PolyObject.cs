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

        public PolyObject(ContentManager contentMgr,  List<Vect2> vertices)
        {
            _texture = contentMgr.Load<Texture2D>("Graphics/Polygon");

            _poly = new Polygon(vertices);
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


        public void Render(SpriteBatch spriteBatch)
        {
            var srcRect = new Rectangle(0, 0, _texture.Width, _texture.Height);

            //Render the texture
            spriteBatch.Draw(_texture, Position.ToVector2(), srcRect, Color.White, PMath.DegreeToRadian(_poly.Angle), Vector2.Zero, 1.0f, SpriteEffects.None, 1f);
            
            //Render border to see where the physics polygon is in relation to the texture
            for (var i = 0; i < _poly.Vertices.Count; i++)
            {
                spriteBatch.DrawLine(_poly.Vertices[i].ToVector2(), _poly.Vertices[i < _poly.Vertices.Count - 1 ? i + 1 : 0].ToVector2(), Color.Green, 2f);
            }

            //Render the center
            spriteBatch.FillRectangle(new Rectangle((int)_poly.Position.X, (int)_poly.Position.Y, 5, 5), Color.Black);
        }
    }
}