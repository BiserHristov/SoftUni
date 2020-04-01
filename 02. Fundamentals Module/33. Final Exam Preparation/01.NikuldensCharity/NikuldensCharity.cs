using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.NikuldensCharity
{
    class NikuldensCharity
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Finish")
            {
                List<string> input = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
                string command = input[0];

                if (command == "Replace")
                {
                    char currentChar = char.Parse(input[1]);
                    char newChar = char.Parse(input[2]);

                    if (message.Contains(currentChar))
                    {
                        message = message.Replace(currentChar, newChar);
                    }

                    Console.WriteLine(message);

                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);

                    if (startIndex < 0 || endIndex < 0 || endIndex > message.Length - 1 || startIndex > message.Length - 1)
                    {

                        Console.WriteLine("Invalid indexes!");
                    }
                    else
                    {
                        message = message.Remove(startIndex, endIndex - startIndex + 1);
                        Console.WriteLine(message);
                    }
                }
                else if (command == "Make")
                {
                    string action = input[1];

                    if (action == "Upper")
                    {
                        message = message.ToUpper();

                    }
                    else
                    {
                        message = message.ToLower();

                    }

                    Console.WriteLine(message);
                }
                else if (command == "Check")
                {
                    string value = input[1];

                    if (message.Contains(value))
                    {
                        Console.WriteLine($"Message contains {value}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {value}");
                    }
                }

                else if (command == "Sum")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);
                    long sum = 0;
                    if (startIndex < 0 || endIndex < 0 || endIndex > message.Length - 1 || startIndex > message.Length - 1)
                    {

                        Console.WriteLine("Invalid indexes!");
                    }
                    else
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            sum += (int)message[i];

                        }
                        Console.WriteLine(sum);

                    }


                }




                line = Console.ReadLine();
            }







        }
    }
}

