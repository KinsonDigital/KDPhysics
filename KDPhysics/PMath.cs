﻿using System;
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
        // ReSharper disable once InconsistentNaming
        public static float PI = 3.1415926535897931f;

        /// <summary>
        /// Calculates the dot product of the 2 given vectors.
        /// </summary>
        /// <param name="v1">The first vector in the calculation.</param>
        /// <param name="v2">The second vector in the calculation.</param>
        /// <returns></returns>
        public static float DotProduct(Vect2 v1, Vect2 v2)
        {
            //Dot Product Ref: https://www.mathsisfun.com/algebra/vectors-dot-product.html

            return (v1.X * v2.X) + (v1.Y * v2.Y);
        }


        /// <summary>
        /// Calculates the magnitue(length) of the given vector.
        /// </summary>
        /// <param name="vector">The vector to get the magnitude from.</param>
        /// <returns></returns>
        public static float Magnitude(Vect2 vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }


        /// <summary>
        /// Calculates the square root of the given value.
        /// </summary>
        /// <param name="value">The value to get the square root of.</param>
        /// <returns></returns>
        public static float Sqrt(float value)
        {
            return (float)Math.Sqrt(value);
        }


        /// <summary>
        /// Squares the given value.
        /// </summary>
        /// <param name="value">The value to square.</param>
        /// <returns></returns>
        public static float Square(float value)
        {
            return value * value;
        }


        /// <summary>
        /// Calculates the angle between the given vectors.
        /// </summary>
        /// <param name="v1">The vector that shares a vertice with vector v2.</param>
        /// <param name="v2">The vector that shares a vertice with vector v1.</param>
        /// <returns></returns>
        public static float CalcAngle(Vect2 v1, Vect2 v2)
        {
            return RadianToDegree((float)Math.Acos(DotProduct(v1, v2) / (v1.Length * v2.Length)));
        }


        /// <summary>
        /// Converts the given angle in degrees to radians.
        /// </summary>
        /// <param name="angle">The angle to convert.</param>
        /// <returns></returns>
        public static float DegreeToRadian(float angle)
        {
            return PI * angle / 180.0f;
        }


        /// <summary>
        /// Converts the given angle in radians to degrees.
        /// </summary>
        /// <param name="angle">The angle to convert.</param>
        /// <returns></returns>
        public static float RadianToDegree(float angle)
        {
            return angle * (180.0f / PI);
        }



        public static Vect2 ProjectVector(Vect2 v1, Vect2 v2)
        {
            return new Vect2(v2 * (DotProduct(v1, v2) / (float)Math.Pow(Magnitude(v2), 2)));
        }
    }
}