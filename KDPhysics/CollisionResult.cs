namespace KDPhysics
{
    /// <summary>
    /// Holds information about a collision between 2 polygons.
    /// </summary>
    public struct CollisionResult
    {
        /// <summary>
        /// Gets or sets a value indicating if 2 polygons are going to collide in the next frame.
        /// </summary>
        public bool WillIntersect { get; set; }

        /// <summary>
        /// Represents a value indicating if 2 polygons are colliding.
        /// </summary>
        public bool Intersects { get; set; }

        /// <summary>
        /// The translation vector of 2 polygons that are colliding.  This represents the total amount that
        /// a polygon is penetrating another polygon.
        /// </summary>
        public Vect2 MinTranslationVector { get; set; }
    }
}
