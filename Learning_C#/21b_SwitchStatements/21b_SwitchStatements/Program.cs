using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _21b_SwitchStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int posX = 0;
            int posY = 0;

            bool keepReadingKey = true;
            while (keepReadingKey)
            {
                Console.Write("Enter a key: ");
                Console.WriteLine();

                ConsoleKeyInfo input = Console.ReadKey();
                char letterInput = input.KeyChar;

                switch (letterInput)
                {
                    case 'd':
                    case 'D':
                        posX += 1;
                        break;

                    case 'a':
                    case 'A':
                        posX -= 1;
                        break;

                    case 'w':
                    case 'W':
                        posY += 1;
                        break;

                    case 's':
                    case 'S':
                        posY -= 1;
                        break;

                    case 'q':
                    case 'Q':
                        Console.WriteLine("Exiting program...");
                        keepReadingKey = false;
                        break;

                    default:
                        Console.WriteLine("I don't know what to do with key " + letterInput);
                        break;
                }

                Console.WriteLine($"Current position is ({posX}, {posY})");
            }
            

            Console.ReadKey();
        }
    }
}
