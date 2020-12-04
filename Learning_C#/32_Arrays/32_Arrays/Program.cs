using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrays of data
            int[] numbers = new int[25];

            // Iterating over the array to populate it with data
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = 5 * i;
            }

            // Iterate to print each element to the console
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            //// Arrays can also be iterated with the foreach loop!
            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num);
            //}
            
            Console.ReadKey();
        }
    }
}
