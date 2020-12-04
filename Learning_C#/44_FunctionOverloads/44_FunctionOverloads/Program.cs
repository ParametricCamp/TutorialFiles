using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _44_FunctionOverloads
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 5;
            double b = 7;
            double c = 12;
            double[] nums = { 2, 4, 6, 8, 10 };

            double sumAB = Addition(a, b);
            double sumABC = Addition(a, b, c);
            double sumArray = Addition(nums);

            Console.WriteLine(sumAB);
            Console.WriteLine(sumABC);
            Console.WriteLine(sumArray);

            Console.ReadKey();
        }

        static double Addition(double a, double b)
        {
            double sum = a + b;
            return sum;
        }

        static double Addition(double a, double b, double c)
        {
            double sum = a + b + c;
            return sum;
        }

        static double Addition(double[] values)
        {
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;
        }
    }
}
