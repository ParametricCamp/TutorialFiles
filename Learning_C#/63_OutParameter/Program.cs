using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _63_OutParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create variables first and use them as data receivers through `out` function args
            //double diff;
            //string msg;
            //bool greater = Compare(3, 4, out diff, out msg);

            // Same thing, but inline
            bool greater = Compare(3, 4, out double diff, out string msg);

            Console.WriteLine("Is a greater than b? " + greater);
            Console.WriteLine(msg);
            Console.WriteLine("Difference is: " + diff);

            Console.ReadKey();
        }

        /// <summary>
        /// A function that takes two numbers, returns whether if one is greater than the other,
        /// and other data through its `out` arguments.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="difference"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        static bool Compare(double a, double b, out double difference, out string msg)
        {
            if (a > b)
            {
                msg = a + " is greater than " + b;
            }
            else if (a < b)
            {
                msg = a + " is smaller than " + b;
            }
            else
            {
                msg = a + " is equal to " + b;
            }
            difference = a - b;
            return a > b;
        }
    }
}
