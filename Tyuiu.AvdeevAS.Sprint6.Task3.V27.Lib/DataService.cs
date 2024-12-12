using System;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.AvdeevAS.Sprint6.Task3.V27.Lib
{
    public class DataService : ISprint6Task3V27
    {
        public int[,] Calculate(int[,] matrix)
        {
            if (matrix.GetLength(1) < 4)
            {
                throw new ArgumentException("Матрица должна содержать как минимум 4 столбца.");
            }

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Копируем строки матрицы во временный массив для сортировки
            int[][] tempArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                tempArray[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    tempArray[i][j] = matrix[i, j];
                }
            }

            // Сортировка строк по четвертому столбцу (возрастание)
           // Array.Sort(tempArray, (row1, row2) => row1[3].CompareTo(row2[3]));

            // Запись обратно в матрицу
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = tempArray[i][j];
                }
            }

            return matrix;
        }
    }
}