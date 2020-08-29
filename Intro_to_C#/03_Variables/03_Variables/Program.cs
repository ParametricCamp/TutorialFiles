using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main primitive data types
            int items = 10;                         // number without decimal part
            double pi = 3.14159;                    // number with decimal part (and large precision)
            bool isProfessor = true;                // true or false
            string message = "Hello World!";        // text

            // Other data types
            byte gray = 127;                        // int from -128 to 127
            float half = 0.5f;                      // number with decimal part (and little precision)
            long atoms = 1223814723432723583;       // big integer value
            char a = 'a';                           // a single character

            // Print some values to the console
            Console.WriteLine(items);
            Console.WriteLine(pi);
            Console.WriteLine(atoms);
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
