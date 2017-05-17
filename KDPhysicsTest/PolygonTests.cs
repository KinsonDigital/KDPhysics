using System;
using System.Collections.Generic;
using System.Diagnostics;
using KDPhysics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InconsistentNaming

namespace KDPhysicsTest
{
    [TestClass]
    public class PolygonTests
    {
        private Polygon _polygon;

        [TestInitialize]
        public void Initialize()
        {
            //Based off of a position/center of 0,0
            var worldVertices = new List<Vect2>()
            {
                new Vect2(53, 0),
                new Vect2(99, 11),
                new Vect2(66, 99),
                new Vect2(0, 44)
            };

            _polygon = new Polygon(worldVertices, new Vect2(100, 100));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _polygon = null;
        }

        [TestMethod]
        public void Polygon_Constructor_Valid_Creation()
        {
            //Arrange
            var expectedWorldPosition = new Vect2(100, 100);
            var expectedWorldVertices = new List<Vect2>
            {
                new Vect2(98.5f, 61.5f),
                new Vect2(144.5f, 72.5f),
                new Vect2(111.5f, 160.5f),
                new Vect2(45.5f, 105.5f)
            };

            //Assert world vertices
            for (var i = 0; i < expectedWorldVertices.Count; i++)
            {
                Assert.AreEqual(expectedWorldVertices[i], _polygon.Vertices[i]);
            }

            //Assert world position
            Assert.AreEqual(expectedWorldPosition, _polygon.Position);
        }

        [TestMethod]
        public void CalcPolyCenter_Valid_Result()
        {
            //Arrange
            var expected = new Vect2(100f, 100f);

            //Act
            var actual = _polygon.Position;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Position_Prop_Set_Valid_Result()
        {
            //Arrange
            var expected = new Vect2(10, 10);

            //Act
            _polygon.Position = new Vect2(10, 10);

            //Assert
            Assert.AreEqual(expected, _polygon.Position);
        }

        [TestMethod]
        public void ToString_Valid_Result()
        {
            //Arrange
            const string expected = "(98.5, 61.5) (144.5, 72.5) (111.5, 160.5) (45.5, 105.5)";

            //Act
            var actual = _polygon.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Angle_Prop_GetSet_Valid_Result()
        {
            //Arrange
            const float expected = 1.57079637f;

            //Act
            _polygon.Angle = 1.57079637f;

            var actual = _polygon.Angle;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoundingBoxLeft_Valid_Result()
        {
            //Arrange
            const float expected = 45.5f;

            //Act
            var actual = _polygon.BoundingBoxLeft;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoundingBoxRight_Valid_Result()
        {
            //Arrange
            const float expected = 144.5f;

            //Act
            var actual = _polygon.BoundingBoxRight;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoundingBoxTop_Valid_Result()
        {
            //Arrange
            const float expected = 61.5f;

            //Act
            var actual = _polygon.BoundingBoxTop;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BoundingBoxBottom_Valid_Result()
        {
            //Arrange
            const float expected = 160.5f;

            //Act
            var actual = _polygon.BoundingBoxBottom;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
