using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the contents of the CSV files as individual lines
            string[] csvLines = System.IO.File.ReadAllLines(@"C:\Users\JLX\Desktop\csv\grades.csv");

            // Students
            var students = new List<Student>();

            // Split each row into column data
            for (int i = 1; i < csvLines.Length; i++)
            {
                Student st = new Student(csvLines[i]);
                students.Add(st);
            }

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i]);
            }


            Console.ReadKey();
        }
    }
}
