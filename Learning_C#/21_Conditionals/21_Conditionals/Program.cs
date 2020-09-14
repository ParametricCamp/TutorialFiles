using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Conditionals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Two values
            int a = 5;
            int b = 5;

            if (a > b) 
            { 
                Console.WriteLine($"{a} is greater than {b}");
            }
            else if (a < b)
            {
                Console.WriteLine($"{a} is smaller than {b}");
            }
            else
            {
                Console.WriteLine($"{a} is equal to {b}");
            }


            Console.ReadKey();
        }
    }
}
