using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E01_GreetingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask for user name
            Console.WriteLine("What's your name?");

            // Capture user's name
            string name = Console.ReadLine();
            
            // Greet the user
            Console.WriteLine("Hello " + name + ", how are you doing?");

            // Stop the program
            Console.ReadKey();
        }
    }
}
