using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace KDPhysics
{
    /// <summary>
    /// Represents an Axis Aligned Bounding Box.  Main shape used to perform broad phase collision detection.
    /// </summary>
    public struct AABB
    {
        private Vect2 _origin;

        public AABB(float width, float height, Vect2 origin)
        {
            _origin = origin;
            Width = width;
            Height = height;
            var halfWidth = width / 2;
            var halfHeight = height / 2;

            Vertices = new Vect2[4];

            Vertices[0] = new Vect2(origin.X - halfWidth, origin.Y - halfHeight);
            Vertices[1] = new Vect2(origin.X + halfWidth, origin.Y - halfHeight);
            Vertices[2] = new Vect2(origin.X + halfWidth, origin.Y + halfHeight);
            Vertices[3] = new Vect2(origin.X - halfWidth, origin.Y + halfHeight);
        }

        public Vect2[] Vertices { get; }

        /// <summary>
        /// Represents the center location of the AABB rectangle.
        /// </summary>
        public Vect2 Origin
        {
            get => _origin;
            set
            {
                _origin = value;

                //TODO: THIS WILL NOT WORK WHEN ROTATING THE AABB.  
                //Update the vertices
                Vertices[0] = new Vect2(_origin.X - HalfWidth, _origin.Y - HalfHeight);
                Vertices[1] = new Vect2(_origin.X + HalfWidth, _origin.Y - HalfHeight);
                Vertices[2] = new Vect2(_origin.X + HalfWidth, _origin.Y + HalfHeight);
                Vertices[3] = new Vect2(_origin.X - HalfWidth, _origin.Y + HalfHeight);
            }
        }

        public float Width { get; }

        public float Height { get; }

        /// <summary>
        /// Gets the half width of the bounding box.
        /// </summary>
        public float HalfWidth => Width / 2;

        /// <summary>
        /// Gets the half height of the bounding box.
        /// </summary>
        public float HalfHeight => Height / 2;
    }
}