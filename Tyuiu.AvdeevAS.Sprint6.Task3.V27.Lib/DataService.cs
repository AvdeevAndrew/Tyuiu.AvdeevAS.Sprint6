// Library Code
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

            // Извлекаем 4-й столбец в отдельный массив
            int[] fourthColumn = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                fourthColumn[i] = matrix[i, 3];
            }

            // Сортируем 4-й столбец по возрастанию
            Array.Sort(fourthColumn);

            // Заменяем значения в 4-м столбце матрицы отсортированными данными
            for (int i = 0; i < rows; i++)
            {
                matrix[i, 3] = fourthColumn[i];
            }

            return matrix;
        }
    }
}