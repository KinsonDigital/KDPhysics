using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KDPhysics;
// ReSharper disable InconsistentNaming

namespace KDPhysicsTest
{
    [TestClass]
    public class PMathTests
    {
        [TestMethod]
        public void DotProduct_Valid_Result()
        {
            //Arrange
            var vector1 = new Vect2(2, 3);
            var vector2 = new Vect2(4, 7);
            var expected = 29;

            //Act
            var actual = (int)PMath.DotProduct(vector1, vector2);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Magnitude_Valid_Result()
        {
            //Arrange
            var vector1 = new Vect2(2, 5);
            const double expected = 5.3851648071345037;

            //Act
            var actual = PMath.Magnitude(vector1);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Sqrt_Valid_Result()
        {
            //Arrange
            const double value = 4.5;
            const double expected = 2.1213203435596424;

            //Act
            var actual = PMath.Sqrt(value);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Square_Valid_Result()
        {
            //Arrange
            const double value = 4;
            const double expected = 16;

            //Act
            var actual = PMath.Square(value);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DegreeToRadian_Valid_Result()
        {
            //Arrange
            const double expected = 0.52359877559829882;

            //Act
            var actual = PMath.DegreeToRadian(30);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void RadianToDegree_Valid_Result()
        {
            //Arrange
            const double expected = 29.999999999999996;

            //Act
            var actual = PMath.RadianToDegree(0.52359877559829882);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CalcAngle_Valid_Result()
        {
            //Arrange
            var v1 = new Vect2(2,3);
            var v2 = new Vect2(0,3);
            const double expected = 33.29;

            //Act
            var actual = PMath.CalcAngle(v1, v2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
