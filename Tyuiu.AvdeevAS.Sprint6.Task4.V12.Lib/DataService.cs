using System;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.AvdeevAS.Sprint6.Task4.V12.Lib
{
    public class DataService : ISprint6Task4V12
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            if (startValue > stopValue)
            {
                throw new ArgumentException("Начальное значение не может быть больше конечного.");
            }

            int size = stopValue - startValue + 1;
            double[] results = new double[size];
            int index = 0;

            for (int x = startValue; x <= stopValue; x++, index++)
            {
                try
                {
                    double denominator = (3 * x) + 0.5;
                    if (Math.Abs(denominator) < 1e-10)
                    {
                        results[index] = 0; // Деление на ноль
                    }
                    else
                    {
                        double result = Math.Sin(x) + (2 / denominator) - (2 * Math.Cos(x) * 2 * x);
                        results[index] = Math.Round(result, 2, MidpointRounding.AwayFromZero);
                    }
                }
                catch
                {
                    results[index] = 0; // В случае исключения вернуть 0
                }
            }

            return results;
        }

        public string SaveToFile(double[] values, int startValue)
        {
            string filePath = Path.Combine(Path.GetTempPath(), "OutPutFileTask4V12.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    writer.WriteLine($"x = {startValue + i}, f(x) = {values[i]}");
                }
            }
            return filePath;
        }
    }
}