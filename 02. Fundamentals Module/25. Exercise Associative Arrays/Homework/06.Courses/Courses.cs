using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Courses
    {
        static void Main(string[] args)
        {
            List<string> line = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            while (line[0] != "end")
            {
                string course = line[0];
                string name = line[1];

                if (dict.ContainsKey(course))
                {
                    dict[course].Add(name);
                }
                else
                {
                    dict.Add(course, new List<string>());
                    dict[course].Add(name);
                }

                line = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            dict = dict.
                OrderByDescending(x => x.Value.Count)
                .ToDictionary(t => t.Key, t => (List<string>)t.Value.OrderBy(v => v).ToList());


            foreach (var course in dict)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var item in course.Value)
                {
                    Console.WriteLine($"-- {item}");
                }

            }
        }
    }
}
