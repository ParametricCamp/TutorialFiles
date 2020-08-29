using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_VariableState
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare two variables
            int a = 2;
            int b = 3;

            // Let's create a third variable as the addition of a + b
            int c = a + b;
            Console.WriteLine(c);

            // Update the value of b
            b = 10;
            Console.WriteLine(c);   // still prints 5!! XD

            // We need to manually update the value of c
            c = a + b;
            Console.WriteLine(c);   // prints 12


            Console.ReadKey();
        }
    }
}
