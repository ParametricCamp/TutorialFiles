using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14b_StringInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Two variables
            int a = 10;
            int b = 5;
            
            // String interpolation
            string message = $"{a} + {b} = {a + b}";

            Console.WriteLine(message);

            Console.ReadKey();
        }
    }
}
