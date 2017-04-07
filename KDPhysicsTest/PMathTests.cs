using Microsoft.VisualStudio.TestTools.UnitTesting;
using KDPhysics;

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
            var actual = (int)PMath.CalcDotProduct(vector1, vector2);

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
            var actual = PMath.CalcMagnitude(vector1);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
