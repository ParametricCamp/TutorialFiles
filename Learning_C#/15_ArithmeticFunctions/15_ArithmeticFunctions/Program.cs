using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_ArithmeticFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare the tau variable! :)
            // https://tauday.com/tau-manifesto
            double tau = 2 * Math.PI;

            // Calculate some derived values from it
            double sqrt = Math.Sqrt(tau);
            double pow = Math.Pow(tau, 3);
            double abs = Math.Abs(tau);
            double rnd = Math.Round(tau);
            double sine = Math.Sin(tau);
            double cosine = Math.Cos(tau);

            Console.WriteLine(sqrt);
            Console.WriteLine(pow);
            Console.WriteLine(abs);
            Console.WriteLine(rnd);
            Console.WriteLine(sine);
            Console.WriteLine(cosine);

            Console.ReadKey();
        }
    }
}
