using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _07.StudentAcademy
{
    class StudentAcademy
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, double> dict = new Dictionary<string, double>();

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, grade);
                }
                else
                {
                    dict[name] = (dict[name] + grade) / 2;
                }

            }

            dict = dict
                .Where(x => x.Value >= 4.50)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {(item.Value):F2}");

            }

        }
    }
}
