using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDPhysics;

namespace KDPhysicsTestGame
{
    public static class Collision
    {
        public static PolygonCollisionResult PolygonCollision(AABB polyA, AABB polyB, Vect2 velocity)
        {
            PolygonCollisionResult result = new PolygonCollisionResult();
            result.Intersect = true;
            result.WillIntersect = true;

            //Get the total number of edges for both polygons
            int totalEdgesA = polyA.Edges.Length;
            int totalEdgesB = polyB.Edges.Length;

            float minIntervalDistance = float.PositiveInfinity;
            Vect2 translationAxis = new Vect2();
            Vect2 edge;

            // Loop through all the edges of both polygons
            for (int edgeIndex = 0; edgeIndex < totalEdgesA + totalEdgesB; edgeIndex++)
            {
                if (edgeIndex < totalEdgesA)
                {
                    edge = polyA.Edges[edgeIndex];
                }
                else
                {
                    edge = polyB.Edges[edgeIndex - totalEdgesA];
                }

                // ===== 1. Find if the polygons are currently intersecting =====

                // Find the axis perpendicular to the current edge
                Vect2 axis = new Vect2(-edge.Y, edge.X);
                axis = PMath.Normalize(axis);

                // Find the projection of the polygon on the current axis
                float minA = 0; float minB = 0; float maxA = 0; float maxB = 0;
                ProjectPolygon(axis, polyA, ref minA, ref maxA);
                ProjectPolygon(axis, polyB, ref minB, ref maxB);

                // Check if the polygon projections are currentlty intersecting
                if (IntervalDistance(minA, maxA, minB, maxB) > 0) result.Intersect = false;

                // ===== 2. Now find if the polygons *will* intersect =====

                // Project the velocity on the current axis
                float velocityProjection = PMath.DotProduct(axis, velocity);

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
                float intervalDistance = IntervalDistance(minA, maxA, minB, maxB);
                if (intervalDistance > 0)
                    result.WillIntersect = false;

                // If the polygons are not intersecting and won't intersect, exit the loop
                if (!result.Intersect && !result.WillIntersect)
                    break;

                // Check if the current interval distance is the minimum one. If so store
                // the interval distance and the current distance.
                // This will be used to calculate the minimum translation vector
                intervalDistance = Math.Abs(intervalDistance);
                if (intervalDistance < minIntervalDistance)
                {
                    minIntervalDistance = intervalDistance;
                    translationAxis = axis;

                    Vect2 d = polyA.Origin - polyB.Origin;

                    if (PMath.DotProduct(d, translationAxis) < 0) translationAxis = -translationAxis;
                }
            }

            // The minimum translation vector can be used to push the polygons appart.
            // First moves the polygons by their velocity
            // then move polyA by MinimumTranslationVector.
            if (result.WillIntersect) result.MinimumTranslationVector = translationAxis * minIntervalDistance;

            return result;
        }

        // Calculate the distance between [minA, maxA] and [minB, maxB]
        // The distance will be negative if the intervals overlap
        public static float IntervalDistance(float minA, float maxA, float minB, float maxB)
        {
            if (minA < minB)
            {
                return minB - maxA;
            }
            else
            {
                return minA - maxB;
            }
        }

        // Calculate the projection of a polygon on an axis and returns it as a [min, max] interval
        public static void ProjectPolygon(Vect2 axis, AABB polygon, ref float min, ref float max)
        {
            // To project a point on an axis use the dot product
            var d = PMath.DotProduct(axis, polygon.Vertices[0]);
            min = d;
            max = d;
            for (var i = 0; i < polygon.Vertices.Length; i++)
            {
                d = PMath.DotProduct(polygon.Vertices[i], axis);

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
