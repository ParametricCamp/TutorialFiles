using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_FunctionScope
{
    class Program
    {
        static double TAU = 2 * Math.PI;

        static void Main(string[] args)
        {
            double r = 1;

            double circLen = CircleLength(r);
            Console.WriteLine(circLen);

            Console.ReadKey();
        }

        static double CircleLength(double radius)
        {
            double len = TAU * radius;
            return len;
        }
    }
}
