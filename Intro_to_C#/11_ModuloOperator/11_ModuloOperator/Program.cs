using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ModuloOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare two numbers
            int a = 3;
            int b = 2;

            // The modulo operator returns the remainder
            // of the division operation.
            int mod = a % b;
            Console.WriteLine(mod);

            Console.ReadKey();
        }
    }
}
