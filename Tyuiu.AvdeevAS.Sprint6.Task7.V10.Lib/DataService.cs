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
            string fileData = File.ReadAllText(path);
            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            int rows = lines.Length;
            int cols = lines[0].Split(';').Length;
            int[,] mtrx = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string[] line_r = lines[r].Split(';');
                for (int c = 0; c < cols; c++)
                {
                    mtrx[r, c] = Convert.ToInt32(line_r[c]);
                }
            }
                       

            if (rows >= 5)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (mtrx[4, j] >= 5 && mtrx[4, j] <= 10)
                    {
                        mtrx[4, j] = 0;
                    }
                }
            }

            return mtrx;
        }
    }
}