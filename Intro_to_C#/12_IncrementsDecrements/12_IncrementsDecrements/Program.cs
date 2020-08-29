using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_IncrementsDecrements
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare a variable
            int a = 7;
            Console.WriteLine(a);

            // Increase its value by any value
            a = a + 3;
            Console.WriteLine(a);

            a += 4;  // increase by
            Console.WriteLine(a);

            a -= 3;  // decrease by
            Console.WriteLine(a);

            a *= 2;  // multiply by
            Console.WriteLine(a);

            a /= 2;  // divide by
            Console.WriteLine(a);

            a++;  // increase by one
            Console.WriteLine(a);

            a--;  // decrease by one
            Console.WriteLine(a);


            Console.ReadKey();
        }
    }
}
