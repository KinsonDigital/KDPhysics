using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KDPhysics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KDPhysicsTest
{
    [TestClass]
    public class AABBTests
    {
        [TestMethod]
        public void Center_Valid_Result()
        {
            //Arrange
            var aabb = new AABB
            {
                Origin = new Vect2(100, 100)
            };

            var expected = new Vect2(100, 100);

            //Act
            var actual = aabb.Origin;

            //Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void Width_Valid_Result()
        {
            //Arrange
            var aabb = new AABB(100, 100, new Vect2(100, 100));

            const float expected = 100f;

            //Act
            var actual = aabb.Width;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Height_Valid_Result()
        {
            //Arrange
            var aabb = new AABB(100, 200, new Vect2(100, 100));

            const float expected = 200f;

            //Act
            var actual = aabb.Height;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HalfWidth_Valid_Result()
        {
            //Arrange
            var aabb = new AABB(100, 100, new Vect2(100, 100));

            const float expected = 50f;

            //Act
            var actual = aabb.HalfWidth;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HalfHeight_Valid_Result()
        {
            //Arrange
            var aabb = new AABB(100, 200, new Vect2(100, 100));

            const float expected = 100f;

            //Act
            var actual = aabb.HalfHeight;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Vertices_Valid_Result()
        {
            //Arrange
            var aabb = new AABB(50, 50, new Vect2(100, 100));

            var expected = new Vect2[4];

            expected[0] = new Vect2(75,75);
            expected[1] = new Vect2(125, 75);
            expected[2] = new Vect2(125, 125);
            expected[3] = new Vect2(75, 125);

            //Act
            var actual = aabb.Vertices;

            //Assert
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreEqual(expected[1], actual[1]);
            Assert.AreEqual(expected[2], actual[2]);
            Assert.AreEqual(expected[3], actual[3]);
        }
    }
}