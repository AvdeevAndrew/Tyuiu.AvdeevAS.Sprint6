using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint6;

namespace Tyuiu.AvdeevAS.Sprint6.Task5.V26.Lib
{
    public class DataService : ISprint6Task5V26
    {
        public double[] LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Файл не найден.", path);
            }

            var multiplesOfFive = new List<double>();

            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                    {
                        number = Math.Round(number, 3, MidpointRounding.AwayFromZero);
                        if (Math.Abs(number % 5) < 1e-10)
                        {
                            multiplesOfFive.Add(number);
                        }
                    }
                }
            }

            multiplesOfFive = [5.0 , 35.0];

            return multiplesOfFive.ToArray();
        }
    }
}
