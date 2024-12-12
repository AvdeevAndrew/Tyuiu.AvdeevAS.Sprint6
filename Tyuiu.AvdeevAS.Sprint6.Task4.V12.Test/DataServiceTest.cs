using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.AvdeevAS.Sprint6.Task4.V12.Lib;

namespace Tyuiu.AvdeevAS.Sprint6.Task4.V12.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void GetMassFunction_ValidRange_ReturnsCorrectValues()
        {
            // Arrange
            var service = new DataService();
            int startValue = -5;
            int stopValue = 5;

            // Act
            double[] results = service.GetMassFunction(startValue, stopValue);

            // Assert
            Assert.AreEqual(11, results.Length);
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

        [TestMethod]
        public void SaveToFile_ValidData_CreatesFile()
        {
            // Arrange
            var service = new DataService();
            double[] data = { 1.23, 4.56, 7.89 };
            int startValue = -5;

            // Act
            string filePath = service.SaveToFile(data, startValue);

            // Assert
            Assert.IsTrue(File.Exists(filePath));
            File.Delete(filePath); // Cleanup
        }
    }
}
