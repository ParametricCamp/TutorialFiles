using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _62_2DArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parameters of our building
            int floors = 7;
            int aptsPerFloor = 5;

            // 2D arrays defining apartment names and whether if they have mail or not
            string[,] apartments = new string[floors, aptsPerFloor];
            bool[,] hasMail = new bool[floors, aptsPerFloor];

            // Initialize values with a nested for loop
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < aptsPerFloor; j++)
                {
                    apartments[i, j] = $"Apartment {i}-{j}";
                    hasMail[i, j] = false;
                }
            }

            // Some algorithm that tracks mail and updates `hasMail`...
            hasMail[2, 3] = true;
            hasMail[6, 0] = true;

            // Check mail in all apartments
            for (int i = 0; i < floors; i++)
            {
                for (int j = 0; j < aptsPerFloor; j++)
                {
                    Console.WriteLine(apartments[i, j] + " has mail: " + hasMail[i, j]);
                }
            }

            Console.ReadKey();
        }
    }
}
