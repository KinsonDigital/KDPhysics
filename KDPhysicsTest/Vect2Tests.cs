using System;
using KDPhysics;
using NUnit.Framework;
// ReSharper disable InconsistentNaming
// ReSharper disable EqualExpressionComparison

namespace KDPhysicsTest
{
    [TestFixture]
    public class Vect2Tests
    {
        [Test]
        public void Length_Valid_Result()
        {
            //Arrange
            var vector = new Vect2(10, 20);
            const int expected = 22;

            //Act
            var actual = (int)vector.Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalcLength_Valid_Result()
        {
            //Arrange
            var vector = new Vect2(10, 20);
            const int expected = 22;

            //Act
            var actual = (int)vector.Length;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Constructor_Valid_Result()
        {
            //Arrange
            var vector1 = new Vect2(10, 20);
            var vector2 = new Vect2(new Vect2(110, 120));

            var expected1 = new Vect2(10, 20);
            var expected2 = new Vect2(110, 120);

            //Assert
            Assert.AreEqual(expected1, vector1);
            Assert.AreEqual(expected2, vector2);
        }

        [Test]
        public void Mult_Operator_Valid_Result()
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

        [Test]
        public void Subtract_VectorFromVector_Operator_Valid_Result()
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

        [Test]
        public void Subract_ScalarFromVector_Operator_Valid_Result()
        {
            //Arrange
            var expected = new Vect2(10, 20);

            //Act
            var actual = new Vect2(20, 30) - 10;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Negate_Operator_Valid_Result()
        {
            //Arrange
            var expected = new Vect2(-10, -20);

            //Act
            var actual = -new Vect2(10, 20);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_VectorToVector_Operator_Valid_Result()
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

        [Test]
        public void Add_VectorToScalar_Operator_Valid_Result()
        {
            //Arrange
            var vector = new Vect2(10, 20);
            const int scalar = 10;

            var expected = new Vect2(20, 30);

            //Act
            var actual = vector + scalar;

            //Assert
            Assert.AreEqual(expected, actual);//Assert x component
        }

        [Test]
        public void Divide_VectorByScalar_Operator_Valid_Result()
        {
            //Arrange
            var expected = new Vect2(10, 20);

            //Act
            var actual = new Vect2(100, 200) / 10;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equal_Operator_Validd_Result()
        {
            //Arrange
            //Arranged in Initialize()

            //Act
            var actualTrue = new Vect2(10, 20) == new Vect2(10, 20);
            var actualFalse = new Vect2(10, 20) == new Vect2(100, 200);

            //Assert
            Assert.AreEqual(true, actualTrue);
            Assert.AreEqual(false, actualFalse);
        }

        [Test]
        public void NotEqual_Operator_Valid_Result()
        {
            //Arrange
            //Arranged in Initalize()

            //Act
            var actualTrue = new Vect2(100, 200) != new Vect2(10, 20);
            var actualFalse = new Vect2(100, 200) != new Vect2(100, 200);

            //Assert
            Assert.AreEqual(true, actualTrue);
            Assert.AreEqual(false, actualFalse);
        }

        [Test]
        public void GetHashCode_Valid_Result()
        {
            //Arrange
            var vector = new Vect2(36, 43);
            const int expected = 531586990;

            //Act
            var actual = vector.GetHashCode();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_Valid_True_Result()
        {
            //Arrange
            var vector = new Vect2(36, 43);
            const bool expected = true;

            //Act
            var actual = vector.Equals(new Vect2(36, 43));

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Equals_Valid_False_Result()
        {
            //Arrange
            var vector = new Vect2(36, 43);
            const bool expected = false;

            //Act
            var actualWithNull = vector.Equals(null);
            var actualWithoutNull = vector.Equals(new Vect2(23, 100));

            //Assert
            Assert.AreEqual(expected, actualWithNull);
            Assert.AreEqual(expected, actualWithoutNull);
        }

        [Test]
        public void ToString_Valid_Result()
        {
            //Arrange
            const string expectedWithName = "MyVector: (10, 20)";
            const string expectedWithoutName = "(10, 20)";

            //Act
            var actualWithName = new Vect2(10, 20) {Name = "MyVector"}.ToString();
            var actualWithoutName = new Vect2(10, 20).ToString();

            //Assert
            Assert.AreEqual(expectedWithName, actualWithName);
            Assert.AreEqual(expectedWithoutName, actualWithoutName);
        }
    }
}