using System;

namespace KDPhysics
{
    /// <summary>
    /// Checks if polygons are colliding into eachother and returns information about the collision.
    /// </summary>
    public static class CollisionChecker
    {
        /// <summary>
        /// Checks if polygon A and polygon B are colliding using the given velocity of polygon A.
        /// The given velocity of polygon A will help determine if the polygons will intersect.
        /// </summary>
        /// <param name="polyA">The polygon moving and colliding into polygon B.</param>
        /// <param name="polyB">The polygon being hit by polygon A.</param>
        /// <param name="polyAVelocity">The velocity of polygon A.</param>
        /// <returns></returns>
        public static CollisionResult CheckCollision(Polygon polyA, Polygon polyB, Vect2 polyAVelocity)
        {
            /*
             * This uses the SAT thearom to check for collision between 2 polygons.
             * Website Refs:
             *  1. https://gamedevelopment.tutsplus.com/tutorials/collision-detection-using-the-separating-axis-theorem--gamedev-169
             *  2. http://www.dyn4j.org/2010/01/sat/
             *  3. http://www.metanetsoftware.com/technique/tutorialA.html
             */

            var result = new CollisionResult
            {
                Intersects = true,
                WillIntersect = true
            };

            var totalPolyAEdges = polyA.Edges.Count;
            var totalPolyBEdges = polyB.Edges.Count;
            var minIntervalDistance = float.PositiveInfinity;
            var translationAxis = new Vect2();

            // Loop through all the edges of both polygons
            //Check each edge of both polygon to check for overlapping vectors on the 
            //projection axis
            for (var edgeIndex = 0; edgeIndex < totalPolyAEdges + totalPolyBEdges; edgeIndex++)
            {
                var edge = edgeIndex < totalPolyAEdges ? polyA.Edges[edgeIndex] : polyB.Edges[edgeIndex - totalPolyAEdges];

                // ===== 1. Find if the polygons are currently intersecting =====

                // Find the axis perpendicular to the current edge
                var axis = new Vect2(-edge.Y, edge.X);
                axis = PMath.Normalize(axis);

                // Find the projection of the polygon on the current axis
                float minA = 0;
                float minB = 0;
                float maxA = 0;
                float maxB = 0;

                ProjectPolygon(axis, polyA, ref minA, ref maxA);
                ProjectPolygon(axis, polyB, ref minB, ref maxB);

                // Check if the polygon projections are currentlty intersecting
                if (IntervalDistance(minA, maxA, minB, maxB) > 0) result.Intersects = false;

                // ===== 2. Now find if the polygons *will* intersect =====

                // Project the velocity on the current axis
                var velocityProjection = PMath.DotProduct(axis, polyAVelocity);

                // Get the projection of polygon A during the movement
                if (velocityProjection < 0)
                {
                    minA += velocityProjection;
                }
                else
                {
                    maxA += velocityProjection;
                }

                // Do the same test as above for the new projection
                var intervalDistance = IntervalDistance(minA, maxA, minB, maxB);

                if (intervalDistance > 0)
                    result.WillIntersect = false;

                // If the polygons are not intersecting and won't intersect, exit the loop
                if (!result.Intersects && !result.WillIntersect)
                    break;

                // ===== 3. Find the minimum translation vector =====

                // Check if the current interval distance is the minimum one. If so store
                // the interval distance and the current distance.
                // This will be used to calculate the minimum translation vector
                intervalDistance = Math.Abs(intervalDistance);

                if (! (intervalDistance < minIntervalDistance))
                    continue;

                minIntervalDistance = intervalDistance;
                translationAxis = axis;

                var posDelta = polyA.Position - polyB.Position;

                if (PMath.DotProduct(posDelta, translationAxis) < 0)
                    translationAxis = -translationAxis;
            }

            // The minimum translation vector can be used to push the polygons appart.
            // If the polygons will intersect, the min translation vector should represent
            // the amount not only how much the polygons are penetrating/intersecting by the 
            // amount that the polygon will move next iteration.
            if (result.WillIntersect)
                result.MinTranslationVector = translationAxis * minIntervalDistance;

            return result;
        }

        /// <summary>
        /// Checks if polygonA and polygonB are colliding.
        /// </summary>
        /// <param name="polyA"></param>
        /// <param name="polyB"></param>
        /// <returns></returns>
        public static CollisionResult CheckCollision(Polygon polyA, Polygon polyB)
        {
            return CheckCollision(polyA, polyB, new Vect2(0, 0));
        }

        // Calculate the distance between [minA, maxA] and [minB, maxB]
        // The distance will be negative if the intervals overlap
        /// <summary>
        /// Calculates the distance between polygon A projection and polygon B projection.
        /// A negative number will represent the projections are overlapping and 
        /// a collision might be occurring.
        /// </summary>
        /// <param name="minA">The polygon A projection minimum.</param>
        /// <param name="maxA">The polygon A projection maximum.</param>
        /// <param name="minB">The polygon B projection minimum.</param>
        /// <param name="maxB">The polygon B projection maximum.</param>
        /// <returns></returns>
        public static float IntervalDistance(float minA, float maxA, float minB, float maxB)
        {
            return minA < minB ? minB - maxA : minA - maxB;
        }

        // Calculate the projection of a polygon on an axis and return it as a [min, max] interval
        /// <summary>
        /// Calculates the porjection of the given polygon onto the given axis.
        /// </summary>
        /// <param name="axis">The axis that the given polygon is projecting onto.</param>
        /// <param name="polygon">The polygon that is being projected onto the given axis.</param>
        /// <param name="min">The minimum of the projection result.</param>
        /// <param name="max">The maximum of the projection result.</param>
        public static void ProjectPolygon(Vect2 axis, Polygon polygon, ref float min, ref float max)
        {
            // To project a point on an axis use the dot product
            var d = PMath.DotProduct(axis, polygon.Vertices[0]);
            min = d;
            max = d;

            foreach (var vert in polygon.Vertices)
            {
                d = PMath.DotProduct(vert, axis);

                if (d < min)
                {
                    min = d;
                }
                else
                {
                    if (d > max)
                    {
                        max = d;
                    }
                }
            }
        }
    }
}