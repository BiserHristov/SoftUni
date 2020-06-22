using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            string[] input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                string town = input[2];
                var person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine().Split();
            }

            int index = int.Parse(Console.ReadLine());

            Person matchPerson = people[--index];

            int equal = 0;
            int notEqual = 0;

            foreach (var person in people)
            {
                if (matchPerson.CompareTo(person) != 0)
                {
                    notEqual++;
                }
                else
                {
                    equal++;
                }
            }

            if (equal>1)
            {
                Console.WriteLine($"{equal} {notEqual} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
