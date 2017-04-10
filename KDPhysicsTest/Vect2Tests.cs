using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KDPhysics;
// ReSharper disable InconsistentNaming

namespace KDPhysicsTest
{
    [TestClass]
    public class Vect2Tests
    {
        [TestMethod]
        public void Valid_DotProduct_Result()
        {
            //Arrange
            var start = new Vect2(2, 0);
            var end = new Vect2(2, 3);
            const int expected = 6;

            //Act
            var actual = Vect2.DotProduct(start, end);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Valid_Length_Result()
        {
            //Arrange
            var vector = new Vect2(10, 20);
            const int expected = 22;

            //Act
            var actual = (int)vector.Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Valid_CalcLength_Result()
        {
            //Arrange
            var vector = new Vect2(10, 20);
            const int expected = 22;

            //Act
            var actual = (int)Vect2.CalcLength(vector);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}