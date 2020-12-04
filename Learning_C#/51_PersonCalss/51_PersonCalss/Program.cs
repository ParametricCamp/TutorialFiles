using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _51_PersonCalss
{
    class Program
    {
        static void Main(string[] args)
        {
            Person jl = new Person("Jose", 2025, 5.9);
            Console.WriteLine(jl.name);
            Console.WriteLine(jl.YOB);
            Console.WriteLine(jl.height);
            Console.WriteLine(jl.isAlive);

            Person jane = new Person("Jane", 2000, 5.8);
            Console.WriteLine(jane.name);
            Console.WriteLine(jane.YOB);
            Console.WriteLine(jane.height);
            Console.WriteLine(jane.isAlive);

            Person baby = new Person("Cutie");
            Console.WriteLine(baby.name);
            Console.WriteLine(baby.YOB);
            Console.WriteLine(baby.height);
            Console.WriteLine(baby.isAlive);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// This is a class that will define the properties 
    /// and functionality of Person objects.
    /// </summary>
    class Person
    {
        // Fields
        public string name;
        public int YOB;
        public double height;
        public bool isAlive;

        // Constructor just with the name
        public Person(string name)
        {
            this.name = name;
            this.YOB = DateTime.Now.Year;
            this.height = 2.0;
            this.isAlive = true;
        }

        // Constructor with more properties
        public Person(string name, int yob, double height)
        {
            this.name = name;
            this.YOB = yob;
            this.height = height;

            int currentYear = DateTime.Now.Year;

            if (this.YOB > currentYear)
            {
                this.isAlive = false;
            }
            else
            {
                this.isAlive = true;
            }
        }
    }
}
