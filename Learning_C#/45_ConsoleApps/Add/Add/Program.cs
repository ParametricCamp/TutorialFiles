using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            for (int i = 0; i < args.Length; i++)
            {
                double val = Convert.ToDouble(args[i]);
                sum += val;
            }
            Console.WriteLine("Your total is: " + sum);
        }

        
    }
}
