using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EmailValidator
{
    class EmailValidator
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string line = Console.ReadLine();

            while (line != "Complete")
            {

                List<string> input = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                string command = input[0];
                if (command == "Make")
                {
                    if (input[1] == "Upper")
                    {

                        email = email.ToUpper();

                    }
                    else if (input[1] == "Lower")
                    {
                        email = email.ToLower();
                    }
                    Console.WriteLine(email);
                }
                else if (command == "GetDomain")
                {
                    int count = int.Parse(input[1]);
                    string result = email.Substring(email.Length - count);
                    Console.WriteLine(result);

                }
                else if (command == "GetUsername")
                {
                    int index = email.IndexOf('@');
                    if (index < 0)
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        Console.WriteLine(email.Substring(0, index));
                    }

                }
                else if (command == "Replace")
                {
                    email = email.Replace(char.Parse(input[1]), '-');
                    Console.WriteLine(email);
                }
                else if (command== "Encrypt")
                {
                    List<int> list = new List<int>();

                    foreach (var ch in email)
                    {
                        list.Add((int)ch);
                    }

                    Console.WriteLine(string.Join(" ", list));
                }

                line = Console.ReadLine();
            }
        }
    }
}
