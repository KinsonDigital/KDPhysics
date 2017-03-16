using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KDPhysics;

namespace KDPhysicsTest
{
    [TestClass]
    public class Vect2Tests
    {
        [TestMethod]
        public void Valid_DotProduct_Result()
        {
            //Arrange
            var start = new Vect2(41, 14);
            var end = new Vect2(63, 99);
            var actual = 0;
            var expected = 3969;

            //Act
            actual = Vect2.DotProduct(start, end);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Valid_Length_Result()
        {
            //Arrange
            var vector = new Vect2(10, 20);
            var expected = 22;

            //Act
            var actual = vector.Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}