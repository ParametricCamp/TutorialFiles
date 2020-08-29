using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E02_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user to input two numbers
            Console.Write("Enter first value: ");
            string val1str = Console.ReadLine();
            Console.Write("Enter second value: ");
            string val2str = Console.ReadLine();

            // Covnert these values to numbers
            double val1 = 0;
            double val2 = 0;
            try
            {
                val1 = Convert.ToDouble(val1str);
                val2 = Convert.ToDouble(val2str);
            }
            catch
            {
                Console.WriteLine("Wrong inputs, please enter only numerical values");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

                // Stop the program from further executing
                return;
            }

            Console.WriteLine();
            Console.WriteLine("HERE ARE SOME CALCULATIONS:");

            // Displaying a bunch of computations with these values
            double add = val1 + val2;
            Console.WriteLine(val1 + " + " + val2 + " = " + add);
            
            double sub = val1 - val2;
            Console.WriteLine(val1 + " - " + val2 + " = " + sub);

            double mult = val1 * val2;
            Console.WriteLine(val1 + " * " + val2 + " = " + mult);

            double div = val1 / val2;
            Console.WriteLine(val1 + " / " + val2 + " = " + div);

            double mod = val1 % val2;
            Console.WriteLine(val1 + " % " + val2 + " = " + mod);

            double sqrt = Math.Sqrt(val1);
            Console.WriteLine("Square root of " + val1 + " = " + sqrt);


            // Stop the program
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
