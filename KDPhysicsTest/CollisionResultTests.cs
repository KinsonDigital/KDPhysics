using System;
using System.CodeDom;
using KDPhysics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UseObjectOrCollectionInitializer

namespace KDPhysicsTest
{
    [TestClass]
    public class CollisionResultTests
    {
        [TestMethod]
        public void WillIntersect_Prop_Set_Valid()
        {
            //Arrange
            var collisionResult = new CollisionResult();

            //Act
            collisionResult.WillIntersect = true;

            //Assert
            Assert.AreEqual(true, collisionResult.WillIntersect);
        }

        [TestMethod]
        public void Intersects_Prop_Set_Valid()
        {
            //Arrange
            var collisionResult = new CollisionResult();

            //Act
            collisionResult.Intersects = true;

            //Assert
            Assert.AreEqual(true, collisionResult.Intersects);
        }

        [TestMethod]
        public void MinTranslationVector_Prop_Set_Valid()
        {
            //Arrange
            var collisionResult = new CollisionResult();
            
            //Act
            collisionResult.MinTranslationVector = new Vect2(12, 45);

            //Assert
            Assert.AreEqual(new Vect2(12, 45), collisionResult.MinTranslationVector);
        }
    }
}
