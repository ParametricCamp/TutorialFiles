using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23_WhileLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print first ten digits

            // Initialize a reference value
            int i = 0; 

            // Loop while that value is less than another one
            while (i < 10)
            {
                // Print that value to console
                Console.WriteLine(i);

                // Don't forget to update the value to meet the end criteria!
                // Otherwise, you might get stuck on an infinite loop!
                i++;  
            }

            Console.ReadKey();
        }
    }
}
