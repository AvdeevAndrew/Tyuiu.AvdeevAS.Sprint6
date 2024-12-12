using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.AvdeevAS.Sprint6.Task7.V10.Lib
{
    public class DataService : ISprint6Task7V10
    {
        public int[,] GetMatrix(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Файл не найден.", path);
            }

            var lines = new List<string>();
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            if (lines.Count == 0)
            {
                throw new InvalidOperationException("Файл пуст.");
            }

            int rows = lines.Count;
            int cols = lines[0].Split(',',';').Length;
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(',', ';');
                for (int j = 0; j < cols; j++)
                {
                    if (!int.TryParse(values[j], NumberStyles.Integer, CultureInfo.InvariantCulture, out int value))
                    {
                        throw new FormatException($"Некорректное значение в строке {i + 1}, столбце {j + 1}.");
                    }

                    matrix[i, j] = value;
                }
            }

            if (rows >= 5)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[4, j] >= 5 && matrix[4, j] < 10)
                    {
                        matrix[4, j] = 0;
                    }
                }
            }

            return matrix;
        }
    }
}