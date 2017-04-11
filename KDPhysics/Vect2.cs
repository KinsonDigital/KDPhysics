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
        public Vect2 (double x, double y)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// Gets or sets the X coordinate of the vector.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the vector.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets the length or magnitude of the vector.
        /// </summary>
        public double Length => PMath.Magnitude(this);



        public static Vect2 operator *(Vect2 vector, double scalar)
        {
            return new Vect2(vector.X * scalar, vector.Y * scalar);
        }
    }
}