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
            var actual = (int)vector.Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}