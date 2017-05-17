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
        /// Gets or sets the name of the vector.
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
        /// Gets the (magnitude length) of the vector.
        /// </summary>
        public float Length => PMath.Magnitude(this);

        #region Operators
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
        /// Subtracts the left vector by the right vector.
        /// </summary>
        /// <param name="v1">The left operand.</param>
        /// <param name="v2">The right operand.</param>
        /// <returns></returns>
        public static Vect2 operator -(Vect2 v1, Vect2 v2)
        {
            return new Vect2(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
        /// Returns this vector negated.
        /// </summary>
        /// <param name="vector">The vector to negate.</param>
        /// <returns></returns>
        public static Vect2 operator -(Vect2 vector)
        {
            return new Vect2(-vector.X, -vector.Y);
        }

        /// <summary>
        /// Returns a vector with the given scalar amount subtracted.
        /// </summary>
        /// <param name="vector">The left operand.</param>
        /// <param name="scalar">The right operand.</param>
        /// <returns></returns>
        public static Vect2 operator -(Vect2 vector, float scalar)
        {
            return new Vect2(vector.X - scalar, vector.Y - scalar);
        }

        /// <summary>
        /// Adds the left and right vector operands.
        /// </summary>
        /// <param name="v1">The left operand.</param>
        /// <param name="v2">The right operand.</param>
        /// <returns></returns>
        public static Vect2 operator +(Vect2 v1, Vect2 v2)
        {
            return new Vect2(v1.X + v2.X, v1.Y + v2.Y);
        }

        /// <summary>
        /// Returns a vector with the given scalar amount added.
        /// </summary>
        /// <param name="vector">The left operand.</param>
        /// <param name="scalar">The right operand.</param>
        /// <returns></returns>
        public static Vect2 operator +(Vect2 vector, float scalar)
        {
            return new Vect2(vector.X + scalar, vector.Y + scalar);
        }

        /// <summary>
        /// Returns the vector divided by the given scalar.
        /// </summary>
        /// <param name="vector">The left operand.</param>
        /// <param name="scalar">The right operand.</param>
        /// <returns></returns>
        public static Vect2 operator /(Vect2 vector, float scalar)
        {
            return new Vect2(vector.X / scalar, vector.Y / scalar);
        }

        /// <summary>
        /// Returns a value indicating if the 2 given vectors numerically equal.
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
        /// Returns a value indicating if the 2 given vectors are not numerically equal.
        /// </summary>
        /// <param name="v1">The first vector to compare.</param>
        /// <param name="v2">The second vector to compare.</param>
        /// <returns></returns>
        public static bool operator !=(Vect2 v1, Vect2 v2)
        {
            return ! (v1 == v2);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Checks if the this vector and the given vector are equal.
        /// </summary>
        /// <param name="other">The other vector to check.</param>
        /// <returns></returns>
        public bool Equals(Vect2 other)
        {
            return string.Equals(Name, other.Name) && X.Equals(other.X) && Y.Equals(other.Y);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to check against this object.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            return obj is Vect2 && Equals((Vect2)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Returns the string representation of the Vect2.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            const char LEFT_BRACE = '{';
            const char RIGHT_BRACE = '}';

            return $"{Name}{(string.IsNullOrEmpty(Name) ? "" : ": ")}({X}, {Y})";
        }
        #endregion
    }
}