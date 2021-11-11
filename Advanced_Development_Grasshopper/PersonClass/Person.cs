using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClass
{
    public class Person
    {
        public string Name;
        public int Age;
        public bool IsProfessor;

        public Person(string n, int a, bool ip)
        {
            this.Name = n;
            this.Age = a;
            this.IsProfessor = ip;
        }

        public override string ToString()
        {
            return this.Name + ", age: " + this.Age + " is professor? " + this.IsProfessor;
        }
    }
}
