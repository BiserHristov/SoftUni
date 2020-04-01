using System;
using System.Text.RegularExpressions;

namespace _02.Registration
{
    class Registration
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int successfulCount = 0;

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, @"U\$(?<username>[A-Z][a-z]{2,})U\$.*?P@\$(?<password>[A-Za-z]{5,}[0-9]+)P@\$");
                if (match.Success)
                {
                    successfulCount++;

                    Console.WriteLine($"Registration was successful\nUsername: {match.Groups["username"]}, Password: {match.Groups["password"]}");

                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }

            }
            Console.WriteLine($"Successful registrations: {successfulCount}");

        }
    }
}
