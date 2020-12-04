using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _43_VoidFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Greet("Jose Luis");

            Log("hi there");

            Console.ReadKey();
        }


        static void Log(string str)
        {
            Console.WriteLine(str);
        }

        static void Greet(string name)
        {
            string msg = $"Hello {name}!";
            Console.WriteLine(msg);
        }
    }
}
