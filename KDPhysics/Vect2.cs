using System;

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

        public static Vect2 operator -(Vect2 v1, Vect2 v2)
        {
            return new Vect2(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
        /// Returns the string representation of the Vect2.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            const char LEFT_BRACE = '{';
            const char RIGHT_BRACE = '}';

            return $"{Name}: {LEFT_BRACE} X: {Math.Round(X, 1)} : Y: {Math.Round(Y, 1)} {RIGHT_BRACE}";
        }
    }
}