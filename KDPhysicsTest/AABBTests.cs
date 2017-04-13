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
                Min = new Vect2(0, 0),
                Max = new Vect2(10, 10)
            };
            
            var expected = new Vect2(5,5);

            //Act
            var actual = aabb.Center;

            //Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void Min_Valid_Result()
        {
            //Arrange
            var aabb = new AABB
            {
                Min = new Vect2(2, 3),
                Max = new Vect2(22, 33)
            };

            var expected = new Vect2(2, 3);

            //Act
            var actual = aabb.Min;

            //Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void Max_Valid_Result()
        {
            //Arrange
            var aabb = new AABB
            {
                Min = new Vect2(5, 15),
                Max = new Vect2(50, 150)
            };

            var expected = new Vect2(50, 150);

            //Act
            var actual = aabb.Max;

            //Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void HalfWidth_Valid_Result()
        {
            //Arrange
            var aabb = new AABB
            {
                Min = new Vect2(0, 0),
                Max = new Vect2(50, 100)
            };

            const int expected = 25;

            //Act
            var actual = aabb.HalfWidth;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HalfHeight_Valid_Result()
        {
            //Arrange
            var aabb = new AABB
            {
                Min = new Vect2(0, 0),
                Max = new Vect2(50, 100)
            };

            const int expected = 50;

            //Act
            var actual = aabb.HalfHeight;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
