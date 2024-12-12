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
            string[] lines = File.ReadAllText(path).Replace('\n', '\r').Split('\r', StringSplitOptions.RemoveEmptyEntries);

            int rows = lines.Length;


            int cols = lines[0].Split(';').Length;
            int[,] matrix = new int[rows, cols];


            for (int i = 0; i < rows; i++)
            {
                string[] values = lines[i].Split(';');
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = Convert.ToInt32(values[j]);
                }
            }

            if (rows > 4)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[4, j] >= 5 && matrix[4, j] < 10)
                    {
                        matrix[4, j] = 0;
                    }
                }
            }//

            return matrix;
        }
    }
}