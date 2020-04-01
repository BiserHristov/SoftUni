using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            string firstString = input[0];
            string secondString = input[1];
            long sum = 0;

             while (true)
            {
                int firstМultiplier = 1;
                int secondМultiplier = 1;

                if (firstString.Length == 0)
                {
                    foreach (char ch in secondString)
                    {
                        sum += ch;
                    }
                    break;
                }

                if (secondString.Length == 0)
                {
                    foreach (char ch in firstString)
                    {
                        sum += ch;
                    }
                    break;
                }

                firstМultiplier = firstString[0];
                secondМultiplier = secondString[0];
                firstString = firstString.Remove(0, 1);
                secondString = secondString.Remove(0, 1);

                sum += firstМultiplier * secondМultiplier;

            }

            Console.WriteLine(sum);
        }
    }
}
