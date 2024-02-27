using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_management_system
{
    internal class Student
    {
        public string name { get; set;}
        public double grade { get; set;}
        public int rollNumber { get; set;}

        public Student(string name, double grade, int rollNumber)
        {
            this.name = name;
            this.grade = grade;
            this.rollNumber = rollNumber;
        }

        public override string ToString()
        {
            return $"Name: {name}, Grade: {grade}, Rollnumber: {rollNumber}";
        }
        
    }
}
