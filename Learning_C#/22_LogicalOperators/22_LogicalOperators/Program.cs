using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_LogicalOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            // Two boolean values
            bool a = true;
            bool b = false;

            // Logical operations with boolean values
            Console.WriteLine(a);
            Console.WriteLine(!a);              // NOT operator
            Console.WriteLine(a && b);          // AND operator
            Console.WriteLine(a || b);          // OR operator

            Console.ReadKey();
        }
    }
}
