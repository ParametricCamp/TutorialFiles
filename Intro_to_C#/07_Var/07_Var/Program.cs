using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Var
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring variables with `var` as "implicit" type
            var a = 10;
            var pi = 3.1415;
            var name = "ParametricCamp";
            var amazing = true;

            Console.WriteLine(a);

            // // This will not work because a was implicitly assigned the type `int`
            //a = 1231.43;

            Console.ReadKey();
        }
    }
}
