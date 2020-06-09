using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    public class PredicateForNames
    {
        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Func<string, bool> lenghtFunc = x => x.Length <= length;
            names = names.Where(lenghtFunc).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
