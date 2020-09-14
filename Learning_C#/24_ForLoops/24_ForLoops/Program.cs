using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_ForLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print first ten digits
            // The structure of a for loop is (initialization; continuity check; update)
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
