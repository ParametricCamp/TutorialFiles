using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_OperatorPrecedence
{
    class Program
    {
        static void Main(string[] args)
        {
            // Executing a compound calculation
            double calc = 5 * 3 + 9 / 3;
            Console.WriteLine(calc);

            Console.WriteLine(5 * 3 + 9 / 3);
            Console.WriteLine((5 * 3) + (9 / 3));
            Console.WriteLine(5 * (3 + 9) / 3);

            Console.ReadKey();
        }
    }
}
