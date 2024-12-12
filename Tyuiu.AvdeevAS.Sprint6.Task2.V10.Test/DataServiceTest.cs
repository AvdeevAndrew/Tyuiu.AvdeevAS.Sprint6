using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.AvdeevAS.Sprint6.Task2.V10.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task2.V10.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void GetMassFunction_ValidInput_ReturnsCorrectResults()
        {
            // Arrange
            var service = new DataService();
            int startValue = -5;
            int stopValue = 5;
            double[] expected = { /* expected values */ };

            // Act
            double[] actual = service.GetMassFunction(startValue, stopValue);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMassFunction_InvalidRange_ThrowsArgumentException()
        {
            // Arrange
            var service = new DataService();

            // Act
            service.GetMassFunction(5, -5);
        }
    }
}