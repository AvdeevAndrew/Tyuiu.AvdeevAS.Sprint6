using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.AvdeevAS.Sprint6.Task5.V26.Lib;
using System.IO;

namespace Tyuiu.AvdeevAS.Sprint6.Task5.V26.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void LoadFromDataFile_ValidFile_ReturnsCorrectData()
        {
            // Arrange
            var service = new DataService();
            string filePath = Path.GetTempFileName();
            File.WriteAllLines(filePath, new[] { "5.123", "10", "15.456", "-20.5" });

            // Act
            double[] result = service.LoadFromDataFile(filePath);

            // Assert
            CollectionAssert.AreEqual(new[] { 5.123, 10, 15.456, -20.5 }, result);

            // Cleanup
            File.Delete(filePath);
        }

        [TestMethod]
        public void FilterMultiplesOfFive_ValidData_ReturnsCorrectFilteredData()
        {
            // Arrange
            var service = new DataService();
            double[] input = { 5, 10.123, 15, 7.5, -20 };

            // Act
            double[] result = service.FilterMultiplesOfFive(input);

            // Assert
            CollectionAssert.AreEqual(new[] { 5, 15, -20 }, result);
        }
    }
}