using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StringOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Two string variables
            string greet = "Hello";
            string name = "Jose Luis";

            // Strings can be concatenated with the `+` symbol
            string message = greet + " " + name + "!";
            Console.WriteLine(message);

            Console.ReadKey();
        }
    }
}
