using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.AvdeevAS.Sprint6.Task1.V14.Lib
{
    public class DataService : ISprint6Task1V14
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            if (startValue > stopValue)
            {
                throw new ArgumentException("Начальное значение не может быть больше конечного.");
            }

            List<double> results = new List<double>();
            for (int x = startValue; x <= stopValue; x++)
            {
                double denominator = Math.Cos(x) + x;
                double value = denominator == 0 ? 0 : Math.Round(((2 * x + 6) / denominator) - 3, 2, MidpointRounding.AwayFromZero);
                results.Add(value);
            }

            return results.ToArray();
        }
    }
}
