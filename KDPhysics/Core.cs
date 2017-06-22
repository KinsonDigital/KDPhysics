using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDPhysics
{
    public class Core
    {
        private readonly List<Polygon> _polygons = new List<Polygon>();

        /// <summary>
        /// Gets or sets a polygon in the engine to process.
        /// </summary>
        /// <param name="index">The index of the item to get or set.</param>
        /// <returns></returns>
        Polygon this[int index]
        {
            get
            {
                return index >= 0 && index <= _polygons.Count - 1 
                    ? _polygons[index]
                    : null;
            }
            set
            {
                if (index >= _polygons.Count && index <= _polygons.Count - 1)
                {
                    _polygons[index] = value;
                }
            }
        }

        public void Update(float elapsedMilliseconds)
        {
            //Check each polygon agains another to see if they are colliding
            for (var i = 0; i < _polygons.Count; i++)
            {
                for (var k = i + 1; k < _polygons.Count - i; k++)
                {
                    //Check if the 2 polygons are colliding
                    var result = CollisionChecker.CheckCollision(_polygons[i], _polygons[k]);

                    if (result.Intersects)
                        Debugger.Break();
                }
            }
        }
    }
}