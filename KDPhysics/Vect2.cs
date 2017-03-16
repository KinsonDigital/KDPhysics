﻿using System;
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
        /// Gets or sets the X coordinate of the vector.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the vector.
        /// </summary>
        public int Y { get; set; }
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
    }
}