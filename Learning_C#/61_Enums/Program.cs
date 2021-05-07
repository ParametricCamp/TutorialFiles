using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _61_Enums
{
    class Program
    {
        /// <summary>
        /// Create a `Status` Enum to define the different types
        /// of Status a package might be under
        /// </summary>
        enum Status
        {
            InStore, 
            InTransit,
            OutForDelivery,
            Delivered
        }

        /// <summary>
        /// This would be a package tracking program...
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Define a variable of the enum type `Status`
            Status packageStatus = Status.OutForDelivery;
            Console.WriteLine("Package status is: " + packageStatus);

            // Use the enum values for direct comparisons
            if (packageStatus == Status.InStore)
            {
                Console.WriteLine("Package hasn't leaved facilities");
            }
            else if (packageStatus == Status.InTransit)
            {
                Console.WriteLine("Package is on its way");
            }
            else if (packageStatus == Status.OutForDelivery)
            {
                Console.WriteLine("You will receive your package VERY soon");
            }
            else if (packageStatus == Status.Delivered)
            {
                Console.WriteLine("Package is delivered");
            } 
            
            Console.ReadKey();
        }
    }
}
