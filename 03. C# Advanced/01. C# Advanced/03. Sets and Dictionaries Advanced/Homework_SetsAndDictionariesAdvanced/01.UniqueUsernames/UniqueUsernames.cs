using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string currName = Console.ReadLine();
                names.Add(currName);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);

            }


        }
    }
}
