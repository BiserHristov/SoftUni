using System;

namespace _01.ExtractPersonInformation
{
    class ExtractPersonInformation
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string line = Console.ReadLine();
                int startIndexName = line.IndexOf('@');
                int endIndexName = line.IndexOf('|');
                string name = line.Substring(startIndexName + 1, endIndexName - startIndexName - 1);

                int startIndexAge = line.IndexOf('#');
                int endIndexAge = line.IndexOf('*');
                string age = line.Substring(startIndexAge + 1, endIndexAge - startIndexAge - 1);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
