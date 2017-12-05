using System;
using System.CodeDom;
using KDPhysics;
using NUnit.Framework;
// ReSharper disable UseObjectOrCollectionInitializer

namespace KDPhysicsTest
{
    [TestFixture]
    public class CollisionResultTests
    {
        [Test]
        public void WillIntersect_Prop_Set_Valid()
        {
            //Arrange
            var collisionResult = new CollisionResult();

            //Act
            collisionResult.WillIntersect = true;

            //Assert
            Assert.AreEqual(true, collisionResult.WillIntersect);
        }

        [Test]
        public void Intersects_Prop_Set_Valid()
        {
            //Arrange
            var collisionResult = new CollisionResult();

            //Act
            collisionResult.Intersects = true;

            //Assert
            Assert.AreEqual(true, collisionResult.Intersects);
        }

        [Test]
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
