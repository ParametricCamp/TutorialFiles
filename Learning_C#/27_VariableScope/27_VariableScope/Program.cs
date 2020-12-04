using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_VariableScope
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 5;

            string message;
            if (a > b)
            {
                message = "Greater";
            }
            else
            {
                message = "Not Greater";
            }
            Console.WriteLine(message);

            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);


            Console.ReadKey();
        }
    }
}
