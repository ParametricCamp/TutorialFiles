using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22b_LogicalOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Some values I want to compare
            int value = 5;
            int min = 0;
            int max = 5;

            // Let's see where `value` falls in the [`min`,`max`] interval
            if (value > max || value < min)
            {
                Console.WriteLine($"{value} is outside the [{min},{max}] interval");
            }
            else if (value > min && value < max)
            {
                Console.WriteLine($"{value} is inside the [{min},{max}] interval");
            } 
            else if (value == min || value == max)
            {
                Console.WriteLine($"{value} is on the boundary of the [{min},{max}] interval");
            }


            Console.ReadKey();
        }
    }
}
