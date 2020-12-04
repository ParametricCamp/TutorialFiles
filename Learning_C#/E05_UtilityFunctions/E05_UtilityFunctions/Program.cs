using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E05_UtilityFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's create some utility functions!");

            //double a = 5;
            //double b = 5;

            //double sum = Addition(a, b);
            //Print(sum);

            //double mult = Multiplication(a, b);
            //Print(mult);

            //double pow = Pow(a, b);
            //Print(pow);

            //Print($"Is {a} greater than {b}? {IsGreaterThan(a, b)}");

            //double dist = DistanceBetweenPoints(0, 0, 4, 3);
            //Print("Distance between points: " + dist);

            //double radius = 1;
            //Print("Circle length: " + CircleLength(radius));
            //Print("Circle Area: " + CircleArea(radius));

            //bool insideCircle = IsInsideCircle(1, 1, 5, 4, 1);
            //Print("Is inside circle? " + insideCircle);

            double[] nums = NumericalRange(4, 2, 4);
            Print(nums);
            Print("Mass addition: " + Addition(nums));
            Print("Average: " + Average(nums));

            DrawEmptyRectangle(50, 20, 4);

            Console.ReadKey();
        }

        static void DrawEmptyRectangle(int width, int height, int borderWidth)
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (j < borderWidth || j > height - 1 - borderWidth
                        || i < borderWidth || i > width - 1 - borderWidth)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        } 



        static double[] NumericalRange(double start, double end, int steps)
        {
            double step = (end - start) / steps;

            //double[] list = new double[steps + 1];
            //for (int i = 0; i < steps + 1; i++)
            //{
            //    list[i] = start + i * step;
            //}
            //return list;

            return NumericalSeries(start, step, steps + 1);
        }

        static double[] NumericalSeries(double start, double step, int count)
        {
            double[] list = new double[count];
            for (int i = 0; i < count; i++)
            {
                list[i] = start + i * step;
            }
            return list;
        }

        static double Addition(double[] values)
        {
            double sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }
            return sum;
        }

        static double Average(double[] values)
        {
            double total = Addition(values);
            double avg = total / values.Length;
            return avg;
        }


        static void Print(double[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                Console.WriteLine(vals[i]);
            }
        }

        static void Print(double val)
        {
            Console.WriteLine(val);
        }

        static void Print(string str)
        {
            Console.WriteLine(str);
        }


        static double Addition(double a, double b)
        {
            double sum = a + b;
            return sum;
        }

        static double Multiplication(double a, double b)
        {
            return a * b;
        }

        static double Pow(double baseValue, double exponent)
        {
            if (exponent == 0)
            {
                return 1;
            }

            double val = baseValue;
            for (int i = 0; i < exponent - 1; i++)
            {
                val *= baseValue;
            }
            return val;
        }

        static bool IsGreaterThan(double a, double b)
        {
            bool greater = a > b;
            return greater;
        }

        static double CircleLength(double radius) => 2 * Math.PI * radius;
        static double CircleArea(double radius) => Math.PI * radius * radius;

        static double DistanceBetweenPoints(double x0, double y0, double x1, double y1)
        {
            double dx = x1 - x0;
            double dy = y1 - y0;
            double d = Math.Sqrt(dx * dx + dy * dy);
            return d;
        }

        static bool IsInsideCircle(double cx, double cy, double r, double x, double y)
        {
            double dist = DistanceBetweenPoints(cx, cy, x, y);
            bool isInside = dist < r;
            return isInside;
        }

    }
}
