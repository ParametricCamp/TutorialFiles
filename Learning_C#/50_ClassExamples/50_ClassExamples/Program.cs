using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_ClassExamples
{
    class Program
    {`
        static void Main(string[] args)
        {
            // Use the function WriteLine inside the Console class
            Console.WriteLine("Hello World!");
            
            // Read the BackgroundColor property of the Console class
            ConsoleColor cc = Console.BackgroundColor;
            Console.WriteLine(cc);

            // Use the functions and properties of the Math class
            Console.WriteLine(Math.Sqrt(25));
            Console.WriteLine(Math.PI);

            Console.ReadKey();
        }
    }
}
