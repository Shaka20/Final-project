using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_management_system
{
    internal class StudentManagement
    {
        private List<Student> students = new List<Student>();

        public void addNewStudent(string name, double grade, int rollNumber)
        {

            if (students.FindAll(student => student.rollNumber == rollNumber).Count() > 0) { Console.WriteLine("User with this rollnumber already exists"); return; }
            students.Add(new Student(name, grade, rollNumber));
            
        }

        public void printAllStudentInfo()
        {
            students.ForEach(Console.WriteLine);
        }

        public void findStudentByRollNumber(int rollNumber)
        {
            students
                .FindAll(student => student.rollNumber == rollNumber)
                .ForEach(Console.WriteLine);
        }

        public void updateStudentGrade(int rollNumber, double grade)
        {
            foreach (Student student in students)
            {
                if(student.rollNumber == rollNumber)
                {
                    student.grade = grade;
                }
            }
        }
    }
}
