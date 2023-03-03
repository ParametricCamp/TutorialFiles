using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64_bitwsie_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int bitAND = 128 & 64;  // 0
            Console.WriteLine("128 & 64: " + bitAND);
            bitAND = 110 & 53;
            Console.WriteLine("110 & 53: " + bitAND);
            Console.WriteLine();

            int bitOR = 128 | 64;   // 192
            Console.WriteLine("128 | 64: " + bitOR);
            bitOR = 110 | 53;
            Console.WriteLine("110 | 53: " + bitOR);
            Console.WriteLine();

            int bitSHIFT = 1 << 7;  // 128
            Console.WriteLine("1   << 7: " + bitSHIFT);
            bitSHIFT >>= 4;
            Console.WriteLine("128 >> 4: " + bitSHIFT);

            bitSHIFT = 5 << 3;
            Console.WriteLine("5   << 3: " + bitSHIFT);
            bitSHIFT >>= 1;
            Console.WriteLine("40  >> 1: " + bitSHIFT);

            Console.ReadKey();
        }
    }
}
