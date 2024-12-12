using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.AvdeevAS.Sprint6.Task0.V29.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task0.V29.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void Calculate_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            var service = new DataService();
            int input = 3;
            double expected = 2.222;

            // Act
            double actual = service.Calculate(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Calculate_ZeroInput_ThrowsDivideByZeroException()
        {
            // Arrange
            var service = new DataService();

            // Act
            service.Calculate(0);
        }
    }
}