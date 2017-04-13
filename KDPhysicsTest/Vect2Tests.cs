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


        [TestMethod]
        public void Valid_Mult_Operator_Result()
        {
            //Arrange
            var vector = new Vect2(2, 3);
            var expected = new Vect2(4,6);

            //Act
            var actualVectorLeftHand = vector * 2;
            var actualVectorRightHand = 2 *vector;

            //Left Hand Assert
            Assert.AreEqual(expected.X, actualVectorLeftHand.X);//Assert x component
            Assert.AreEqual(expected.Y, actualVectorLeftHand.Y);//Assert x component

            //Right Hand Assert
            Assert.AreEqual(expected.X, actualVectorRightHand.X);//Assert x component
            Assert.AreEqual(expected.Y, actualVectorRightHand.Y);//Assert x component
        }
    }
}