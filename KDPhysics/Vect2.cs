using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDPhysics
{
    /// <summary>
    /// Represents direction and magnitude in 2D space.
    /// </summary>
    public struct Vect2
    {
        /// <summary>
        /// Creates a new instance of Vect2.
        /// </summary>
        /// <param name="x">The default X value of the vector.</param>
        /// <param name="y">The default Y value of the vector.</param>
        public Vect2 (int x, int y)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// Gets or sets the X coordinate of the vector.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the vector.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets the length or magnitude of the vector.
        /// </summary>
        public int Length
        {
            get
            {
                return Vect2.CalcLength(this);
            }
        }

        /// <summary>
        /// Calculates the dot product of the given vectors.
        /// </summary>
        /// <param name="start">The starting vector.</param>
        /// <param name="end">The ending vector.</param>
        /// <returns>The scalar dot product value of the start and end vectors.</returns>
        public static int DotProduct (Vect2 start, Vect2 end)
        {
            //Dot Product Ref: https://www.mathsisfun.com/algebra/vectors-dot-product.html

            return (start.X * end.X) + (start.Y * end.Y);
        }

        /// <summary>
        /// Calculates the length or magnitude of the given vector.
        /// </summary>
        /// <param name="vector">The vector to calculate the length from.</param>
        /// <returns>The length of the given vector.</returns>
        public static int CalcLength(Vect2 vector)
        {
            return (int)Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y));
        }
    }
}