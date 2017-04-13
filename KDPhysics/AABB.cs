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
        public AABB(float width, float height, Vect2 origin)
        {
            Origin = origin;
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
        public Vect2 Origin { get; set; }

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