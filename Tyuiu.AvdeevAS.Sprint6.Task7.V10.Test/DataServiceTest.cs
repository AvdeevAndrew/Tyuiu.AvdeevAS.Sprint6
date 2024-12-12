using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.AvdeevAS.Sprint6.Task7.V10.Lib;
using System.IO;

namespace Tyuiu.AvdeevAS.Sprint6.Task7.V10.Tests
{
    [TestClass]
    public class DataServiceTests
    {
        [TestMethod]
        public void GetMatrix_ValidFile_ModifiesFifthRowCorrectly()
        {
            // Arrange
            var service = new DataService();
            string filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, "1,2,3,4,5\n6,7,8,9,10\n11,12,13,14,15\n16,17,18,19,20\n5,6,7,8,9\n21,22,23,24,25");

            // Act
            int[,] result = service.GetMatrix(filePath);

            // Assert
            int[,] expected =
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
                { 0, 0, 0, 0, 0 },
                { 21, 22, 23, 24, 25 }
            };

            CollectionAssert.AreEqual(expected, result);

            // Cleanup
            File.Delete(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GetMatrix_FileNotFound_ThrowsFileNotFoundException()
        {
            // Arrange
            var service = new DataService();

            // Act
            service.GetMatrix("nonexistent.csv");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void GetMatrix_InvalidData_ThrowsFormatException()
        {
            // Arrange
            var service = new DataService();
            string filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, "1,2,3,4,INVALID\n6,7,8,9,10");

            // Act
            service.GetMatrix(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetMatrix_EmptyFile_ThrowsInvalidOperationException()
        {
            // Arrange
            var service = new DataService();
            string filePath = Path.GetTempFileName();
            File.WriteAllText(filePath, string.Empty);

            // Act
            service.GetMatrix(filePath);
        }
    }
}
