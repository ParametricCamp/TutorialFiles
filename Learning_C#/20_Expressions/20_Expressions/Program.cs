using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Two values
            int a = 10;
            int b = 10;

            // We can also save these expressions as boolean variables
            bool isGreater = a > b;

            // Examples of comparisons with expressions
            Console.WriteLine($"Is {a} greater than {b}? {isGreater}");
            Console.WriteLine($"Is {a} greater or equal to {b}? {a >= b}");
            Console.WriteLine($"Is {a} smaller than {b}? {a < b}");
            Console.WriteLine($"Is {a} smaller or equal to {b}? {a <= b}");
            Console.WriteLine($"Is {a} equal to {b}? {a == b}");
            Console.WriteLine($"Is {a} not equal to {b}? {a != b}");

            Console.ReadKey();
        }
    }
}
