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
        public void Valid_CalcDotProduct_Result()
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
        public void Valid_CalcMagnitude_Result()
        {
            //Arrange
            var vector1 = new Vect2(2, 5);
            var expected = 5.3851648071345M;

            //Act
            var actual = PMath.Magnitude(vector1);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Valid_CalcSqrt_Result_With_Double_Param()
        {
            //Arrange
            const double value = 4.5;
            const decimal expected = 2.12132034355964M;

            //Act
            var actual = PMath.Sqrt(value);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Valid_CalcSqrt_Result_With_Decimal_Param()
        {
            //Arrange
            const decimal value = 4.5M;
            const decimal expected = 2.12132034355964M;

            //Act
            var actual = PMath.Sqrt(value);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Valid_CalcSquare_Result()
        {
            //Arrange
            const decimal value = 4M;
            const decimal expected = 16M;

            //Act
            var actual = PMath.Square(value);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
