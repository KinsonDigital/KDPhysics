using System.Collections.Generic;
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
            const float expected = 5.3851648071345037f;

            //Act
            var actual = PMath.Magnitude(vector1);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sqrt_Valid_Result()
        {
            //Arrange
            const float value = 4.5f;
            const float expected = 2.1213203435596424f;

            //Act
            var actual = PMath.Sqrt(value);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Square_Valid_Result()
        {
            //Arrange
            const float value = 4;
            const float expected = 16;

            //Act
            var actual = PMath.Square(value);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DegreeToRadian_Valid_Result()
        {
            //Arrange
            const float expected = 0.52359877559829882f;

            //Act
            var actual = PMath.DegreeToRadian(30);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RadianToDegree_Valid_Result()
        {
            //Arrange
            const float expected = 29.999999999999996f;

            //Act
            var actual = PMath.RadianToDegree(0.52359877559829882f);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalcAngle_Valid_Result()
        {
            //Arrange
            var v1 = new Vect2(2,3);
            var v2 = new Vect2(0,3);
            const float expected = 33.6900635f;

            //Act
            var actual = PMath.CalcAngle(v1, v2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScalarProjection_Valid_Result()
        {
            //Arrange
            var v1 = new Vect2(5, 5);
            var v2 = new Vect2(10,0);
            const float expected = 7.071068f;

            //Act
            var actual = PMath.ScalarProjection(v1, v2);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void VectorProjection_Valid_Result()
        {
            //Arrange
            var v1 = new Vect2(5, 5);
            var v2 = new Vect2(10, 0);
            var expected = new Vect2(5, 0);

            //Act
            var actual = PMath.VectorProjection(v1, v2);
            
            //Assert
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void RotateVectorAround_Valid_Result()
        {
            var v1 = new Vect2(2, 0);
            var v2 = new Vect2(2, 3);
            var v3 = new Vect2(4, 0);

            var org = new Vect2(2, -2);

            var result1 = PMath.RotateVectorAround(v1, org, PMath.DegreeToRadian(90));
            var result2 = PMath.RotateVectorAround(v2, org, PMath.DegreeToRadian(90));
            var result3 = PMath.RotateVectorAround(v3, org, PMath.DegreeToRadian(90));

            ///////////////
            //Arrange
            var vector = new Vect2(3, 4);
            var origin = new Vect2(0, 0);
            var expected = new Vect2(0.598076165f, 4.964102f);

            //Act
            var actual = PMath.RotateVectorAround(vector, origin, PMath.DegreeToRadian(30));
          
            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void TranslateToOrigin_Valid_Result()
        {
            //Arrange
            var vector = new Vect2(150, 150);
            var origin = new Vect2(100, 100);
            var expected = new Vect2(50, 50);

            //Act
            var actual = PMath.TranslateToOrigin(vector, origin);

            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void CalcNormal_Valid_Result()
        {
            //Arrange
            var vector = new Vect2(2, 6);
            var expected = new Vect2(6, -2);

            //Act
            var actual = PMath.CalcNormal(vector);

            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void Normalize_Valid_Result()
        {
            //Arrange
            var vector = new Vect2(3, 4);
            var expected = new Vect2(0.6f, 0.8f);

            //Act
            var actual = PMath.Normalize(vector);

            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void CalcPolyCenter_Valid_Result()
        {
            //Arrange
            var vertices = new List<Vect2>
            {
                new Vect2(0, 0),
                new Vect2(10, 0),
                new Vect2(10, 10),
                new Vect2(0, 10)
            };

            var poly = new Polygon(vertices, new Vect2(10, 10));
            var expected = new Vect2(10f, 10f);

            //Act
            var actual = poly.Position;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}