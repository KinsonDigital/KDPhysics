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
    }
}
