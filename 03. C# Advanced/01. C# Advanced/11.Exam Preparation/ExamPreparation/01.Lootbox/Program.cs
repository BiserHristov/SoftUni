using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    public class Program
    {
        static void Main(string[] args)
        {

            List<int> first = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> second = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            List<int> claimed = new List<int>();


            while (first.Count != 0 && second.Count != 0)
            {


                int sum = first[0] + second[second.Count - 1];

                if (sum % 2 == 0)
                {

                    claimed.Add(sum);
                    first.RemoveAt(0);
                    second.RemoveAt(second.Count - 1);

                }
                else
                {
                    first.Add(second[second.Count - 1]);
                    second.RemoveAt(second.Count - 1);
                }
            }

            if (first.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");

            }
            if (second.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");

            }

            int claimedItemsSum = claimed.Sum();
            if (claimedItemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsSum}");
            }
        }
    }
}
