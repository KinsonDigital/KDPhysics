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
        public Vect2 (decimal x, decimal y)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// Gets or sets the X coordinate of the vector.
        /// </summary>
        public decimal X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the vector.
        /// </summary>
        public decimal Y { get; set; }

        /// <summary>
        /// Gets the length or magnitude of the vector.
        /// </summary>
        public decimal Length => PMath.Magnitude(this);


        /// <summary>
        /// Calculates the dot product of the given vectors.
        /// </summary>
        /// <param name="start">The starting vector.</param>
        /// <param name="end">The ending vector.</param>
        /// <returns>The scalar dot product value of the start and end vectors.</returns>
        public static decimal DotProduct (Vect2 start, Vect2 end)
        {
            //Dot Product Ref: https://www.mathsisfun.com/algebra/vectors-dot-product.html

            return PMath.DotProduct(start, end);
        }
    }
}