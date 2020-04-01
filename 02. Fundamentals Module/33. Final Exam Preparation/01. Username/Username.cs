using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Username
{
    class Username
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string line = Console.ReadLine();

            while (line != "Sign up")
            {
                List<string> input = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();
                string command = input[0];

                if (command == "Case")
                {
                    if (input[1] == "lower")
                    {
                        username = username.ToLower();
                    }
                    else if (input[1] == "upper")
                    {
                        username = username.ToUpper();
                    }
                    Console.WriteLine(username);
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);

                    if (startIndex >= 0 && endIndex >= 0 &&
                        endIndex < username.Length && startIndex < username.Length)
                    {
                        string result = username.Substring(startIndex, endIndex - startIndex + 1);
                        char[] charArray = result.ToCharArray();
                        Array.Reverse(charArray);
                        result = new string(charArray);
                        Console.WriteLine(result);
                    }
                }
                else if (command == "Cut")
                {
                    if (username.Contains(input[1]))
                    {
                        username = username.Remove(username.IndexOf(input[1]), input[1].Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {input[1]}.");
                    }
                }
                else if (command == "Replace")
                {
                    username = username.Replace(input[1], "*");
                    Console.WriteLine(username);
                }
                else if (command == "Check")
                {
                    if (username.Contains(input[1]))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {input[1]}.");
                    }
                }


                line = Console.ReadLine();
            }


        }
    }
}
