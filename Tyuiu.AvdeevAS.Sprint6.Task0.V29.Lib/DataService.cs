using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.AvdeevAS.Sprint6.Task0.V29.Lib

{
    public class DataService : ISprint6Task0V29
    {
        public double Calculate(int x)
        {
            if (x == 0)
            {
                throw new DivideByZeroException("Division by zero occurred in the denominator.");
            }

            double numerator = Math.Pow(x, 3) - 1;
            double denominator = 4 * Math.Pow(x, 2);
            double result = numerator / denominator;

            return Math.Round(result, 3, MidpointRounding.AwayFromZero);
        }
    }
}
