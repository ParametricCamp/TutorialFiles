using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E08_BitwiseOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Even/odd calculation
            int value = 190;
            //bool isEven = value % 2 == 0;
            bool isEven = (value & 1) == 0;
            Console.WriteLine("Is " + value + " even? " + isEven);


            // RGB extraction from a color
            Color clr = Color.FromArgb(255, 191, 127, 63);
            //int A = clr.A;
            //int R = clr.R;
            //int G = clr.G;
            //int B = clr.B;
            //Console.WriteLine(String.Format(
            //    "A:{0}, R:{1}, G:{2}, B:{3}",
            //    A, R, G, B));

            int clrInt = clr.ToArgb();
            //Console.WriteLine(clrInt);
            int B = clrInt & 255;
            int G = (clrInt >> 8) & 255;
            int R = (clrInt >> 16) & 255;
            int A = (clrInt >> 24) & 255;
            //Console.WriteLine(B);
            //Console.WriteLine(G);
            //Console.WriteLine(R);
            //Console.WriteLine(A);
            Console.WriteLine(String.Format(
                "A:{0}, R:{1}, G:{2}, B:{3}",
                A, R, G, B));


            // Multiple conditions

            // Flags
            bool cond1 = false;
            bool cond2 = false;
            bool cond3 = false;
            bool cond4 = true;

            int mask = cond1 ? 1 : 0;       // 0b00000001
            mask |= (cond2 ? 1 : 0) << 1;   // 0b00000010
            mask |= (cond3 ? 1 : 0) << 2;   // 0b00000100 
            mask |= (cond4 ? 1 : 0) << 3;   // 0b00001000 
            Console.WriteLine(mask);

            switch(mask)
            {
                case 0:
                case 1:
                case 4:
                    // do something
                    break;
                case 2:
                case 3:
                case 15:
                    // do something else
                    break;
            }


            Console.ReadKey();
        }
    }
}
