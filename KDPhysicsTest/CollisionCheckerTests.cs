using System;
using System.Collections.Generic;
using KDPhysics;
using System.Diagnostics;
using NUnit.Framework;

namespace KDPhysicsTest
{
    [TestFixture]
    public class CollisionCheckerTests
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
        public void CheckCollision_Valid_Result_Does_Intersect_True()
        {
            //Arrange
            var expected = new CollisionResult
            {
                Intersects = true
            };

            //Act
            var actual = CollisionChecker.CheckCollision(_polyA, _polyB);

            //Assert
            Assert.AreEqual(expected.Intersects, actual.Intersects);
        }

        [Test]
        public void CheckCollision_Valid_Result_Does_Intersect_False()
        {
            //Arrange
            var expected = new CollisionResult
            {
                Intersects = false
            };
            
            //Move polygon B away so it is not touching polygon A.
            _polyB.Position += 50;

            //Act
            var actual = CollisionChecker.CheckCollision(_polyA, _polyB);

            //Assert
            Assert.AreEqual(expected.Intersects, actual.Intersects);
        }

        [Test]
        public void CheckCollision_Valid_Result_Does_WillIntersect()
        {
            //Arrange
            var expected = new CollisionResult
            {
                Intersects = false,//Does not intersect
                WillIntersect = true//Will intersect next time polygon A moves
            };

            //Move polygon B close to polygon B but do not have them touch.
            _polyB.Position += 50;

            //Act
            //Set the velocity of polygon A. This would cause polygon A to intersect next time
            //movement occurs.
            var actual = CollisionChecker.CheckCollision(_polyA, _polyB, new Vect2(50,0));

            //Assert
            Assert.AreEqual(expected.Intersects, actual.Intersects);
            Assert.AreEqual(expected.WillIntersect, actual.WillIntersect);
        }
    }
}