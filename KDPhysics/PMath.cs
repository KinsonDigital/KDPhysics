using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        /// <summary>
        /// Projects the vector v1 onto vector v2.
        /// </summary>
        /// <param name="v1">The vector to project.</param>
        /// <param name="v2">The vector to project v1 onto.</param>
        /// <returns></returns>
        public static Vect2 ProjectVector(Vect2 v1, Vect2 v2)
        {
            return new Vect2(v2 * (DotProduct(v1, v2) / (float)Math.Pow(Magnitude(v2), 2)));
        }

        /// <summary>
        /// Translate vector v1 to the vector origin.
        /// </summary>
        /// <param name="vector">The vector to translate to the origin.</param>
        /// <param name="origin">The origin vector to translate v1 to.</param>
        /// <returns></returns>
        public static Vect2 TranslateToOrigin(Vect2 vector, Vect2 origin)
        {
            return new Vect2(vector.X - origin.X, vector.Y - origin.Y);
        }

        /// <summary>
        /// Rotates vector v1 around the given origin v2.
        /// </summary>
        /// <param name="v1">The vector to rotate around v2.</param>
        /// <param name="v2">The origin vector for v1 to rotate around.</param>
        /// <param name="radians">The degrees to rotate v1 from its current location to its new location around v2.
        /// Use positive number to rotate clockwise and negative number to rotate counter clockwise.</param>
        /// <returns></returns>
        public static Vect2 RotateVectorAround(Vect2 v1, Vect2 v2, double radians)
        {
            var translatedVector = TranslateToOrigin(v1, v2);

            //Apply rotation
            var rotatedX = translatedVector.X * (float)Math.Cos(radians) - translatedVector.Y * (float)Math.Sin(radians);
            var rotatedY = translatedVector.X * (float)Math.Sin(radians) + translatedVector.Y * (float)Math.Cos(radians);

            //Tanslate v1 back
            return new Vect2(rotatedX + v2.X, rotatedY + v2.Y);
        }

        /// <summary>
        /// Calculates the normal of the given vector.
        /// </summary>
        /// <param name="vector">The vector to calculate the normal from.</param>
        /// <returns></returns>
        public static Vect2 CalcNormal(Vect2 vector)
        {
            return new Vect2(vector.Y, vector.X * -1);
        }

        public static Vect2 Normalize(Vect2 vector)
        {
            var mag = Magnitude(vector);

            return new Vect2(vector.X / mag, vector.Y / mag);
        }
    }
}