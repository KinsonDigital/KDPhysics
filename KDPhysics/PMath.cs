using System;
using System.Collections.Generic;

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
        /// Returns the scalar projection of vector v1 onto vector v2.
        /// </summary>
        /// <param name="v1">The vector to project.</param>
        /// <param name="v2">The vector to project v1 onto.</param>
        /// <returns></returns>
        public static float ScalarProjection(Vect2 v1, Vect2 v2)
        {
            return DotProduct(v1, v2) / Magnitude(v1);
        }

        /// <summary>
        /// Returns the vector projection of vector v1 onto vector v2.
        /// </summary>
        /// <param name="v1">The vector to project.</param>
        /// <param name="v2">The vector to project v1 onto.</param>
        /// <returns></returns>
        public static Vect2 VectorProjection(Vect2 v1, Vect2 v2)
        {
            /* Resource Links
             * Calculator and math step breakdown
             * https://www.symbolab.com/solver/vector-projection-calculator/projection%20%5Cleft(5%2C5%5Cright)%2C%5Cleft(10%2C0%5Cright
             * 
             * Simple calculation explanation of scalar and vector projections as well as dot product
             * https://math.oregonstate.edu/home/programs/undergrad/CalculusQuestStudyGuides/vcalc/dotprod/dotprod.html
             */

            var dotProduct = DotProduct(v1, v2);
            var magnitude = (float)Math.Pow(Magnitude(v2), 2);
            var scalarResult = dotProduct / magnitude;

            return new Vect2(v2.X * scalarResult, v2.Y * scalarResult);
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
        /// Rotates vector v1 around the given origin.
        /// </summary>
        /// <param name="v1">The vector to rotate around origin.</param>
        /// <param name="origin">The origin vector for v1 to rotate around.</param>
        /// <param name="radians">The degrees to rotate v1 from its current location to its new location around origin.
        /// Use positive number to rotate clockwise and negative number to rotate counter clockwise.</param>
        /// <returns></returns>
        public static Vect2 RotateVectorAround(Vect2 v1, Vect2 origin, float radians)
        {
            var cos = (float)Math.Cos(radians);
            var sin = (float)Math.Sin(radians);
            var dx = v1.X - origin.X;
            var dy = v1.Y - origin.Y;

            var tempX = dx * cos - dy * sin;
            var tempY = dx * sin + dy * cos;

            var x = tempX + origin.X;
            var y = tempY + origin.Y;

            return new Vect2(x, y);
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

        /// <summary>
        /// Normalizes the given vector.
        /// </summary>
        /// <param name="vector">The vector to normalize.</param>
        /// <returns></returns>
        public static Vect2 Normalize(Vect2 vector)
        {
            var mag = Magnitude(vector);

            return new Vect2(vector.X / mag, vector.Y / mag);
        }

        /// <summary>
        /// Calculates the center of the polygon described by the given directionalVertices.
        /// </summary>
        /// <param name="vertices">The directionalVertices that describe the polygon's shape.</param>
        /// <returns></returns>
        public static Vect2 CalcPolyCenter(List<Vect2> vertices)
        {
            float totalX = 0;
            float totalY = 0;

            foreach (var p in vertices)
            {
                totalX += p.X;
                totalY += p.Y;
            }

            return new Vect2(totalX / vertices.Count, totalY / vertices.Count);
        }

        /// <summary>
        /// Calculates the center of the polygon described by the given vertices.
        /// </summary>
        /// <param name="directionalVertices">The vertices that describe the polygon's shape.</param>
        /// <param name="worldPosition">The position in 2D world space.</param>
        /// <returns></returns>
        public static List<Vect2> CalcWorldVertices(List<Vect2> directionalVertices, Vect2 worldPosition)
        {
            var result = new List<Vect2>();

            foreach (var vert in directionalVertices)
            {
                result.Add(new Vect2(vert.X + worldPosition.X, vert.Y + worldPosition.Y));
            }

            return result;
        }
    }
}