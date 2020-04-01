using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> validUsernames = new List<string>();

            foreach (var name in input)
            {
                bool isValid = true;
                string currentName = name.ToLower();

                if (currentName.Length >= 3 && currentName.Length <= 16)
                {
                    for (int i = 0; i < currentName.Length; i++)
                    {
                        if (!(char.IsLetterOrDigit(currentName[i]) ||
                            currentName[i] == '-' || currentName[i] == '_'))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        validUsernames.Add(currentName);
                    }
                }


            }

            foreach (var item in validUsernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
