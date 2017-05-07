using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDPhysics;

namespace KDPhysicsTestGame
{
    // Structure that stores the results of the PolygonCollision function
    public struct PolygonCollisionResult
    {
        public bool WillIntersect; // Are the polygons going to intersect forward in time?
        public bool Intersect; // Are the polygons currently intersecting
        public Vect2 MinimumTranslationVector; // The translation to apply to polygon A to push the polygons appart.
    }
}
