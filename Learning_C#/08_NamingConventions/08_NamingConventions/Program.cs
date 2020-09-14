using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_NamingConventions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable names are written in "camelCase":
            string myName = "Jose Luis";

            // Depending on the variable name and scope, 
            // try to not be too short, too ambiguous or too explicit:
            double t = 25.5;                        // probably too short
            double temp = 25.5;                     // confusing: "temperature" or "temporal"
            double temperature = 25.5;              // getting better
            double roomTemp = 25.5;                 // better: explicit about a room
            double roomTemperature = 25.5;          // perhaps too long?

            // Functions and classes are written in "PascalCase":
            Console.WriteLine("Console and WriteLine are written in PascalCase");
            Console.WriteLine("Just like ParametricCamp! :)");

            // We will see more examples in future videos! 
        }
    }
}
