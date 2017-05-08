using System;
using System.Diagnostics.CodeAnalysis;

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
        public Vect2 (float x, float y)
        {
            X = x;
            Y = y;

            Name = "";
        }

        /// <summary>
        /// Creates a new instance of Vect2.
        /// </summary>
        /// <param name="vector">The vector to use to create this vector.</param>
        public Vect2(Vect2 vector)
        {
            X = vector.X;
            Y = vector.Y;

            Name = "";
        }

        /// <summary>
        /// Gets or sets a name to the vector.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the X coordinate of the vector.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the vector.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Gets the length or magnitude of the vector.
        /// </summary>
        public float Length => PMath.Magnitude(this);
        
        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">The left operand vector.</param>
        /// <param name="scalar">The right operand scalar.</param>
        /// <returns></returns>
        public static Vect2 operator *(Vect2 vector, float scalar)
        {
            return new Vect2(vector.X * scalar, vector.Y * scalar);
        }

        /// <summary>
        /// Multiplies a vector by a scalar.
        /// </summary>
        /// <param name="vector">The left operand scalar.</param>
        /// <param name="scalar">The right operand vector.</param>
        /// <returns></returns>
        public static Vect2 operator *(float scalar, Vect2 vector)
        {
            return new Vect2(vector.X * scalar, vector.Y * scalar);
        }

        /// <summary>
        /// Subtracts the left and right vector operands.
        /// </summary>
        /// <param name="v1">The first vector to subtract.</param>
        /// <param name="v2">The second vector to subtract.</param>
        /// <returns></returns>
        public static Vect2 operator -(Vect2 v1, Vect2 v2)
        {
            return new Vect2(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
        /// Returns the vector as a negative of both components.
        /// </summary>
        /// <param name="vector">The first vector to subtract.</param>
        /// <returns></returns>
        public static Vect2 operator -(Vect2 vector)
        {
            return new Vect2(-vector.X, -vector.Y);
        }

        /// <summary>
        /// Adds the left and right vector operands.
        /// </summary>
        /// <param name="v1">The first vector to add.</param>
        /// <param name="v2">The second vector to add.</param>
        /// <returns></returns>
        public static Vect2 operator +(Vect2 v1, Vect2 v2)
        {
            return new Vect2(v1.X + v2.X, v1.Y + v2.Y);
        }

        /// <summary>
        /// Returns the vector divided by the given scalar.
        /// </summary>
        /// <param name="vector">The vector being divided.</param>
        /// <param name="scalar">The scalar used to divide into the vector.</param>
        /// <returns></returns>
        public static Vect2 operator /(Vect2 vector, float scalar)
        {
            return new Vect2(vector.X / scalar, vector.Y / scalar);
        }

        /// <summary>
        /// Returns a value indicating if the 2 given vectors are equal.
        /// </summary>
        /// <param name="v1">The first vector to compare.</param>
        /// <param name="v2">The second vector to compare.</param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public static bool operator ==(Vect2 v1, Vect2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        /// <summary>
        /// Returns a value indicating if the 2 given vectors are not equal.
        /// </summary>
        /// <param name="v1">The first vector to compare.</param>
        /// <param name="v2">The second vector to compare.</param>
        /// <returns></returns>
        public static bool operator !=(Vect2 v1, Vect2 v2)
        {
            return ! (v1 == v2);
        }

        /// <summary>
        /// Returns the string representation of the Vect2.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            const char LEFT_BRACE = '{';
            const char RIGHT_BRACE = '}';

            return $"{Name}{(string.IsNullOrEmpty(Name) ? "" : ":")} {LEFT_BRACE} X: {Math.Round(X, 2)} : Y: {Math.Round(Y, 2)} {RIGHT_BRACE}";
        }
    }
}