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

            //BoundingBoxLeft Hand Assert
            Assert.AreEqual(expected.X, actualVectorLeftHand.X);//Assert x component
            Assert.AreEqual(expected.Y, actualVectorLeftHand.Y);//Assert x component

            //BoundingBoxRight Hand Assert
            Assert.AreEqual(expected.X, actualVectorRightHand.X);//Assert x component
            Assert.AreEqual(expected.Y, actualVectorRightHand.Y);//Assert x component
        }

        [TestMethod]
        public void Valid_Subtract_Operator_Result()
        {
            //Arrange
            var vector1 = new Vect2(6, 6);
            var vector2 = new Vect2(2, 2);
            var expected = new Vect2(4, 4);

            //Act
            var actual = vector1 - vector2;

            //Assert
            Assert.AreEqual(expected.X, actual.X);//Assert x component
            Assert.AreEqual(expected.Y, actual.Y);//Assert y component
        }

        [TestMethod]
        public void Valid_Add_Operator_Result()
        {
            //Arrange
            var vector1 = new Vect2(6, 6);
            var vector2 = new Vect2(2, 2);
            var expected = new Vect2(8, 8);

            //Act
            var actual = vector1 + vector2;

            //Assert
            Assert.AreEqual(expected.X, actual.X);//Assert x component
            Assert.AreEqual(expected.Y, actual.Y);//Assert y component
        }
    }
}