using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the contents of the CSV file (as plain text)
            //string rawCSV = System.IO.File.ReadAllText(@"C:\Users\JLX\Desktop\csv\grades.csv");

            // Read the contents of the CSV files as individual lines
            string[] csvLines = System.IO.File.ReadAllLines(@"C:\Users\JLX\Desktop\csv\grades.csv");

            // Create lists with the CSV data
            var firstNames = new List<string>();
            var lastNames = new List<string>();
            var finalGrades = new List<double>();

            // Split each row into column data
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split(',');

                lastNames.Add(rowData[0]);
                firstNames.Add(rowData[1]);

                double g = Convert.ToDouble(rowData[7]);
                finalGrades.Add(g);
            }

            Console.WriteLine("FIRST NAMES:");
            for (int i = 0; i < firstNames.Count; i++)
            {
                Console.WriteLine(firstNames[i]);
            }

            Console.WriteLine("LAST NAMES:");
            for (int i = 0; i < lastNames.Count; i++)
            {
                Console.WriteLine(lastNames[i]);
            }

            Console.WriteLine("FINAL GRADES:");
            for (int i = 0; i < finalGrades.Count; i++)
            {
                Console.WriteLine(finalGrades[i]);
            }

            Console.ReadKey();
        }
    }
}