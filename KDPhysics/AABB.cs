using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDPhysics
{
    /// <summary>
    /// Represents an Axis Aligned Bounding Box.  Main shape used to perform broad phase collision detection.
    /// </summary>
    public struct AABB
    {
        /// <summary>
        /// Represents the top left corner of the bounding rectangle.
        /// </summary>
        public Vect2 Min { get; set; }

        /// <summary>
        /// Represents the bottom right corner of the bounding rectangle.
        /// </summary>
        public Vect2 Max { get; set; }

        /// <summary>
        /// Gets the half width of the bounding box.
        /// </summary>
        public float HalfWidth => CalcHalfWidth();

        /// <summary>
        /// Gets the half height of the bounding box.
        /// </summary>
        public float HalfHeight => CalcHalfHeight();

        /// <summary>
        /// Calculates the half width of the bounding box.
        /// </summary>
        /// <returns>The width divided in half.</returns>
        private float CalcHalfWidth()
        {
            return (Max.X - Min.X) / 2;
        }

        /// <summary>
        /// Calculates the half height of the bounding box.
        /// </summary>
        /// <returns>The height divided in half.</returns>
        private float CalcHalfHeight()
        {
            return (Max.Y - Min.Y) / 2;
        }
    }
}