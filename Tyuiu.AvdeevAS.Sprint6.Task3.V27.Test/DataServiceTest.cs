using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.AvdeevAS.Sprint6.Task3.V27.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task3.V27.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void Calculate_ValidMatrix_ReturnsSortedMatrix()
        {
            // Arrange
            var service = new DataService();
            int[,] inputMatrix =
            {
                { 9, 13, -14, 23, 1 },
                { 15, -17, 21, 25, 23 },
                { -4, 29, -20, -10, 14 },
                { 27, 33, 12, 33, -12 },
                { 18, -9, -5, 6, 3 }
            };
            int[,] expectedMatrix =
            {
                { -4, 29, -20, -10, 14 },
                { 18, -9, -5, 6, 3 },
                { 9, 13, -14, 23, 1 },
                { 15, -17, 21, 25, 23 },
                { 27, 33, 12, 33, -12 }
            };

            // Act
            int[,] actualMatrix = service.Calculate(inputMatrix);

            // Assert
            CollectionAssert.AreEqual(expectedMatrix, actualMatrix);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Calculate_InvalidMatrix_ThrowsArgumentException()
        {
            // Arrange
            var service = new DataService();
            int[,] inputMatrix =
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            };

            // Act
            service.Calculate(inputMatrix);
        }
    }
}
