using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._OrderByAge
{
    class Program
    {
        static void Main()
        {
            //You will receive an unknown number of lines. Each line will be consisted of an array of 3 elements.The first element will be a string and it will represent the name of a person. The second element will be a string and it will represent the ID of the person.
            //    The last element will be an integer - the age of the person. When you receive the command "End", print all the people, ordered by age. 

            string command = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while (command != "End")
            {
                List<string> line = command.Split().ToList();
                string name = line[0];
                string iD = line[1];
                int age = int.Parse(line[2]);

                Person person = new Person(name, iD, age);
                persons.Add(person);

                command = Console.ReadLine();
            }

            persons = persons.OrderBy(x => x.Age).ToList();

            foreach (Person person in persons)
            {
                Console.WriteLine(person.ToString());
            }


        }
    }

    public class Person
    {
        public Person(string name, string iD, int age)
        {
            this.Name = name;
            this.ID = iD;
            this.Age = age;

        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} with ID: {this.ID} is {this.Age} years old.");
            return sb.ToString();
        }
    }

}
