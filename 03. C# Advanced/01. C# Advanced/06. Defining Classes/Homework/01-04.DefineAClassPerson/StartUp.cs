using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(line[0], int.Parse(line[1]));
                people.Add(person);
            }

            people = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
