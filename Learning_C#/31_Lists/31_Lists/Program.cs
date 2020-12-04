using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            // An empty list of int numbers
            List<int> numbers = new List<int>();

            int elements = 25;

            // Add elements
            for (int i = 0; i < elements; i++)
            {
                numbers.Add(10 * i);
            }

            // Manually override values on a list
            numbers[0] = 23;

            // Print all elements to the console
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            //// Lists can also be iterated with the foreach loop!
            //foreach (int num in numbers)
            //{
            //    Console.WriteLine(num);
            //}

            Console.ReadKey();
        }
    }
}
