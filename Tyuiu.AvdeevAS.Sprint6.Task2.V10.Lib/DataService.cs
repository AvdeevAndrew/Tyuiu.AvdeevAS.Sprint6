using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.AvdeevAS.Sprint6.Task2.V10.Lib
{
    public class DataService : ISprint6Task2V10
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
                    double denominator = Math.Sin(x) + 1;
                    if (Math.Abs(denominator) < 1e-10)
                    {
                        results[index] = 0; // Деление на ноль, вернуть 0
                    }
                    else
                    {
                        double result = (2 * x - 4) + ((2 * x - 1) / denominator);
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
    }
}
