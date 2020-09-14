using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E03_NumericalSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            // Examples of numerical series!

            Console.WriteLine("First ten numbers:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();


            Console.WriteLine("First ten negative numbers:");
            for (int i = 0; i > -10; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();


            Console.WriteLine("First ten square numbers:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i * i);
            }
            Console.WriteLine();


            Console.WriteLine("First ten even numbers:");
            for (int i = 0; i < 20; i += 2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //Console.WriteLine("First ten even numbers:");
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(2 * i);
            //}
            //Console.WriteLine();

            //Console.WriteLine("First ten even numbers:");
            //int found = 0;
            //for (int i = 0; i < 100; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Console.WriteLine(i);
            //        found++;
            //        if (found >= 10)
            //        {
            //            break;
            //        }
            //    }
            //}
            //Console.WriteLine();

            //Console.WriteLine("First ten odd numbers:");
            //for (int i = 1; i < 20; i += 2)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine();

            Console.WriteLine("First ten odd numbers:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(2 * i + 1);
            }
            Console.WriteLine();

            //Console.WriteLine("First ten odd numbers:");
            //int found = 0;
            //for (int i = 0; i < 100; i++)
            //{
            //    if (i % 2 == 1)
            //    {
            //        Console.WriteLine(i);
            //        found++;
            //        if (found >= 10)
            //        {
            //            break;
            //        }
            //    }
            //}
            //Console.WriteLine();


            int multValue = 23453;
            Console.WriteLine($"The multiplication table for number {multValue}:");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{multValue} x {i} = {multValue * i}");
            }
            Console.WriteLine();


            Console.WriteLine("An ascending geometric series:");
            for (double v = 1; v < 100; v *= 1.5)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine();

            Console.WriteLine("An asymptotic geometric series:");
            for (double v = 1; v > 0.0001; v *= 0.5)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine();


            Console.WriteLine("The alphabet:");
            string alphabet = "";
            for (int i = 0; i < 26; i++)
            {
                alphabet += (char) (97 + i);
                //Console.WriteLine($"{i}: {alphabet}");
            }
            Console.WriteLine(alphabet);
            Console.WriteLine();

            Console.WriteLine("The addition of the first ten numbers:");
            int massAddition = 0;
            for (int i = 0; i < 10; i++)
            {
                massAddition += i;
            }
            Console.WriteLine(massAddition);
            Console.WriteLine();

            Console.WriteLine("Fibonacci sequence:");
            int prev1 = 1;
            int prev2 = 1;
            Console.WriteLine(prev1);
            Console.WriteLine(prev2);
            for (int i = 0; i < 10; i++)
            {
                int sum = prev1 + prev2;
                Console.WriteLine(sum);

                prev1 = prev2;
                prev2 = sum;
            }
            Console.WriteLine();


            Console.WriteLine("Prime numbers:");
            for (int i = 2; i < 100; i++)
            {
                bool isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime == true)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine();

            
            




            Console.ReadKey();
        }
    }
}
