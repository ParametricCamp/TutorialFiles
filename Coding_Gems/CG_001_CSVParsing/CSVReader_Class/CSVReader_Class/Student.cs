using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader_Class
{
    public class Student
    {
        public string FirstName, LastName, SSN;
        public double[] TestScores = new double[5];
        public string Grade;

        public Student(string rowData) 
        {
            string[] data = rowData.Split(',');

            // Parse data into properties
            this.LastName = data[0];
            this.FirstName = data[1];
            this.SSN = data[2];
            this.TestScores[0] = Convert.ToDouble(data[3]);
            this.TestScores[1] = Convert.ToDouble(data[4]);
            this.TestScores[2] = Convert.ToDouble(data[5]);
            this.TestScores[3] = Convert.ToDouble(data[6]);
            this.TestScores[4] = Convert.ToDouble(data[7]);
            this.Grade = data[8];
        }

        public override string ToString()
        {
            string str = $"{FirstName} {LastName}: " +
                $"{TestScores[0]}-{TestScores[1]}-{TestScores[2]}-{TestScores[3]}-{TestScores[4]}, " +
                $"Final Grade: {Grade}.";
            return str;
        }

    }
}
