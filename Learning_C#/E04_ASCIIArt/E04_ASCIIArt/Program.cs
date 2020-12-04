using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E04_ASCIIArt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's create some cool ASCII art!");
            Console.WriteLine();

            Console.Write("Type a rectangle width: ");
            string widthString = Console.ReadLine();

            Console.Write("Type a rectangle height: ");
            string heightString = Console.ReadLine();

            Console.WriteLine();

            int height = Convert.ToInt32(heightString);
            int width = Convert.ToInt32(widthString);

            Console.WriteLine("SOLID RECTANGLE");
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write('#');
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int borderW = 2;
            Console.WriteLine("BORDER RECTANGLE");
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (j < borderW || j > height - 1 - borderW 
                        || i < borderW || i > width - 1 - borderW)
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("CHECKER PATTERN");
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        Console.Write('█');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            Console.WriteLine("PYRAMID");
            int pyramidWidth = 2 * height - 1;
            int centerColumn = height - 1;
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < pyramidWidth; i++)
                {
                    if (i >= centerColumn - j && i <= centerColumn + j)
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


            Console.WriteLine("CIRCLE");
            double centerX = width / 2.0;
            double centerY = height / 2.0;
            double radius = 0.0;
            if (height < width)
            {
                radius = 0.5 * height;
            }
            else 
            {
                radius = 0.5 * width;
            }
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    double dx = i - centerX;
                    double dy = j - centerY;
                    double d = Math.Sqrt(dx * dx + dy * dy);

                    if (d < radius)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
