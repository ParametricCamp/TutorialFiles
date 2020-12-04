using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawEmptyRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Type a rectangle width: ");
            //string widthString = Console.ReadLine();

            //Console.Write("Type a rectangle height: ");
            //string heightString = Console.ReadLine();

            //Console.Write("Type the width of the border: ");
            //string borderString = Console.ReadLine();

            //Console.WriteLine();

            //int height = Convert.ToInt32(heightString);
            //int width = Convert.ToInt32(widthString);
            //int borderW = Convert.ToInt32(borderString);

            int width = Convert.ToInt32(args[0]);
            int height = Convert.ToInt32(args[1]);
            int borderW = Convert.ToInt32(args[2]);

            DrawEmptyRectangle(width, height, borderW);
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
    }
}
