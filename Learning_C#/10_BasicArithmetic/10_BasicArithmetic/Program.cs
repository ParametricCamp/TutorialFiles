using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_BasicArithmetic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare two integer variables 
            int a = 8;
            int b = 3;
            
            // Basic arithmetic operations
            int sum = a + b;
            int sub = a - b;
            int mult = a * b;
            int div = a / b;            // beware of integer division!!!!
            Console.WriteLine(sum);
            Console.WriteLine(sub);
            Console.WriteLine(mult);
            Console.WriteLine(div);

            // To avoid integer division, just cast one of the
            // variables to a double. 
            double realDiv = a / (double) b;
            Console.WriteLine(realDiv);

            Console.ReadKey();
        }
    }
}
