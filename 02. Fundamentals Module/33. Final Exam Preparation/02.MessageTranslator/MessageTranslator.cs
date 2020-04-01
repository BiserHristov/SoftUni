using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.MessageTranslator
{
    class MessageTranslator
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, @"!(?<command>[A-Z][a-z]{2,})!:\[(?<message>[A-Za-z]{8,})\]");

                if (!match.Success)
                {
                    Console.WriteLine("The message is invalid");
                }
                else
                {
                    List<int> list = new List<int>();
                    foreach (var ch in match.Groups["message"].Value)
                    {
                        list.Add((int)ch);
                    }

                    Console.WriteLine($"{match.Groups["command"].Value}: {string.Join(' ', list)}");

                }
            }
        }
    }
}
