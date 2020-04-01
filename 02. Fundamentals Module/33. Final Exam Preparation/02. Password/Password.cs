using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Password
{
    class Password
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, @"^(.+?)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$");

                if (match.Success)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 1; j <= match.Groups.Count; j++)
                    {
                        sb.Append(match.Groups[j + 1].Value);
                    }

                    Console.WriteLine($"Password: {sb.ToString()}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
