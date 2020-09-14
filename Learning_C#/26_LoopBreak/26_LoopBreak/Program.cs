using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_LoopBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            int threshold = 500;

            int firstValue = 0;
            int firstSquare = 0;
            for (int i = 0; i < 50; i++)
            {
                if (i * i >= threshold)
                {
                    firstValue = i;
                    firstSquare = i * i;
                    break;
                }
            }

            Console.WriteLine($"The first square number over {threshold} is {firstSquare}");


            Console.ReadKey();
        }
    }
}
