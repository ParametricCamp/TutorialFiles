using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyGeometryKernel;

namespace ConsoleAppUsingMyGeometryKernel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Vector v0 = new Vector(0, 1, 2);
            Console.WriteLine(v0);

            Point p = new Point(3, 4, 5);
            Console.WriteLine(p);

            Line line = new Line(p, v0);
            Console.WriteLine(line);

            Console.ReadKey();
        }
    }
}
