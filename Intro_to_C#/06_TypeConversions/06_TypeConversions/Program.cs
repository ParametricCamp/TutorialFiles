using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_TypeConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conversions between data types
            int a = 10;
            bool isProfessor = true;
            string message = "1231293";

            // Implicit conversions
            double num = 15;
            string letter = "a";

            // Casting
            int b = (int) 23.999999;
            Console.WriteLine(b);

            // Explicit conversion
            int c = Convert.ToInt32(true);
            Console.WriteLine(c);
            double numberFromFile = Convert.ToDouble("234.2342");
            Console.WriteLine(numberFromFile);

            // Converting things to strings
            string numberAsString = 1231231.ToString();
            Console.WriteLine(numberAsString);

            Console.ReadKey();
        }
    }
}
