using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_1
{
    class ActivationKeys
    {
        static void Main(string[] args)
        {

            //letters and numbers only?
            string key = Console.ReadLine();

            string line = Console.ReadLine();

            while (line != "Generate")
            {
                List<string> input = line
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();
                string command = input[0];

                if (command == "Contains")
                {
                    if (key.Contains(input[1]))
                    {
                        Console.WriteLine($"{key} contains {input[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    int startIndex = int.Parse(input[2]);
                    int endIndex = int.Parse(input[3]);
                    char[] arr = key.ToCharArray();

                    for (int i = startIndex; i < endIndex; i++)
                    {
                        if (input[1] == "Lower")
                        {
                            arr[i] = char.ToLower(arr[i]);
                        }
                        else if (input[1] == "Upper")
                        {
                            arr[i] = char.ToUpper(arr[i]);
                        }
                    }


                    key = new string(arr);
                    Console.WriteLine(key);

                }

                else if (command== "Slice")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);

                    key=key.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(key);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {key}");

        }
    }
}
