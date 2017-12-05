using KDPhysics;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace KDPhysicsTest
{
    [TestFixture]
    public class PerfTests
    {
        private Polygon _polyA;
        private Polygon _polyB;

        [SetUp]
        public void Initialize()
        {
            //Create the polygons and set the positions so they are colliding

            var polyAVerts = new List<Vect2>
            {
                new Vect2(53, 0),
                new Vect2(99, 11),
                new Vect2(66, 99),
                new Vect2(0, 44)
            };

            _polyA = new Polygon(polyAVerts, new Vect2(100, 100));

            var polyBVerts = new List<Vect2>
            {
                new Vect2(25, 0),
                new Vect2(54, 3),
                new Vect2(84, 22),
                new Vect2(88, 68),
                new Vect2(70, 95),
                new Vect2(12, 99),
                new Vect2(0, 33)
            };

            //Create the purple poly verts
            _polyB = new Polygon(polyBVerts, new Vect2(150, 100));
        }

        [TearDown]
        public void Cleanup()
        {
            _polyA = null;
            _polyB = null;
        }

        [Test]
        public void SimplePerfTests()
        {

            var results = PerfRunner.BenchmarkCode(() =>
            {
                CollisionChecker.CheckCollision(_polyA, _polyB);
            }, 500000, 3).Average();


            var stop = true;
        }
    }
}
