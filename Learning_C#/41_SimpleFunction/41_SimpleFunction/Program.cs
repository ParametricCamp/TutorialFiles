using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _41_SimpleFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 23;

            double sum = Addition(a, b);
            Console.WriteLine(sum);

            string msg = Greet("Jose Luis");
            Console.WriteLine(msg);

            Console.ReadKey();
        }

        /// <summary>
        /// Creates a greeting message for a name
        /// </summary>
        /// <param name="name">Target name</param>
        /// <returns>The greeting message</returns>
        static string Greet(string name)
        {
            string msg = $"Hello {name}!";
            return msg;
        }

        /// <summary>
        /// Adds two numbers together.
        /// </summary>
        /// <param name="valueA">The first value</param>
        /// <param name="valueB">The second value</param>
        /// <returns>The added result</returns>
        static double Addition(double valueA, double valueB)
        {
            double added = valueA + valueB;
            return added;
        }
    }
}
