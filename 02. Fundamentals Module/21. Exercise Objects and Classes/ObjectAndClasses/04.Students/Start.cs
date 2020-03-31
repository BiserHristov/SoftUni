using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Start
    {
        static void Main()
        {
            //Write a program that receives a count of students - n and orders them by grade in descending order. Each student should have a First name(string), 
            //a Last name(string) and a grade(a floating - point number).


            int count = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                List<string> line = Console.ReadLine().Split().ToList();
                string fNmae = line[0];
                string lName = line[1];
                double grade = double.Parse(line[2]);
                Student student = new Student(fNmae, lName, grade);

                students.Add(student);

            }

            students = students.OrderByDescending(x => x.Grade).ToList();

            foreach (Student student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }

    class Student
    {
        public Student(string firstname, string lastName, double grade)
        {
            this.FirstName = firstname;
            this.LastName = lastName;
            this.Grade = grade;

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}: {this.Grade:F2}";


        }
    }
}
