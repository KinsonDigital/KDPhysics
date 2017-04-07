using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDPhysics
{
    /// <summary>
    /// Provides utility methods for physics calculations.
    /// </summary>
    public static class PMath
    {
        /// <summary>
        /// Calculates the dot product of the 2 given vectors.
        /// </summary>
        /// <param name="v1">The first vector in the calculation.</param>
        /// <param name="v2">The second vector in the calculation.</param>
        /// <returns></returns>
        public static decimal CalcDotProduct(Vect2 v1, Vect2 v2)
        {
            return (v1.X * v2.X) + (v1.Y * v2.Y);
        }


        /// <summary>
        /// Calculates the magnitue(length) of the given vector.
        /// </summary>
        /// <param name="vector">The vector to get the magnitude from.</param>
        /// <returns></returns>
        public static decimal CalcMagnitude(Vect2 vector)
        {
            return (decimal)Math.Sqrt((double)(vector.X * vector.X) + (double)(vector.Y * vector.Y));
        }


        /// <summary>
        /// Calculates the square root of the given value.
        /// </summary>
        /// <param name="value">The value to get the square root of.</param>
        /// <returns></returns>
        public static decimal CalcSqrt(double value)
        {
            return (decimal)Math.Sqrt(value);
        }


        /// <summary>
        /// Calculates the square root of the given value.
        /// </summary>
        /// <param name="value">The value to get the square root of.</param>
        /// <returns></returns>
        public static decimal CalcSqrt(decimal value)
        {
            return (decimal)Math.Sqrt((double)value);
        }
    }
}
