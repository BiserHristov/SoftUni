using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.School_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> books = Console.ReadLine().Split('&', StringSplitOptions.RemoveEmptyEntries).ToList();
            string line = Console.ReadLine();

            while (line != "Done")
            {
                List<string> commands = line
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();

                string action = commands[0];
                if (action == "Add Book" && !books.Contains(commands[1]))
                {
                    books.Insert(0, commands[1]);
                }
                else if (action == "Take Book" && books.Contains(commands[1]))
                {
                    books.Remove(commands[1]);

                }
                else if (action == "Swap Books" && books.Contains(commands[1]) && books.Contains(commands[2]))
                {
                    string firstBookName = commands[1];
                    int firstIndex = books.IndexOf(commands[1]);
                    int secondIndex = books.IndexOf(commands[2]);
                    books[firstIndex] = commands[2];
                    books[secondIndex] = firstBookName;
                }
                else if (action == "Insert Book")
                {
                    books.Add(commands[1]);
                }
                else if (action == "Check Book" && int.Parse(commands[1]) >= 0 && int.Parse(commands[1]) <= books.Count - 1)
                {
                    Console.WriteLine(books[int.Parse(commands[1])]);
                }


                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", books));
        }
    }
}
