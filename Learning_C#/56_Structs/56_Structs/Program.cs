using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _56_Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            // A primitive type
            int number = 50;
            // A struct type
            Complex x = new Complex(3, -4);
            // A class type
            Person jl = new Person("Jose", 100);

            // Primitives and structs are passed by value:
            // changes to the objects do not change the originals
            Console.WriteLine(number);
            Increase(number);
            Console.WriteLine(number);
            Console.WriteLine(x);
            Increase(x);
            Console.WriteLine(x);

            // Objects from classes are passed by reference:
            // changes to the object will affect the original
            Console.WriteLine(jl);
            Increase(jl);
            Console.WriteLine(jl);

            Console.ReadKey();
        }

        public static void Increase(Person p)
        {
            p.Age++;
        }

        public static void Increase(int num)
        {
            num++;
        }

        public static void Increase(Complex comp)
        {
            comp.Real++;
        }
    }


    public class Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"{this.Name}, {this.Age}";
        }
    }

    public struct Complex
    {
        public double Real;
        public double Imaginary;

        public Complex (double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public override string ToString()
        {
            return $"{Real} {Imaginary}i";
        }
    }
}
