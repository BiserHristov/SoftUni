using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            //<color <clothes, count>>
            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string color = input[0];

                if (!dict.ContainsKey(color))
                {
                    dict.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    string currClothing = input[j];

                    if (!dict[color].ContainsKey(currClothing))
                    {
                        dict[color].Add(currClothing, 0);
                    }

                    dict[color][currClothing]++;
                }
            }

            string[] searchedClothing = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string searchedColor = searchedClothing[0];
            string searchedClothes = searchedClothing[1];

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var cvp in kvp.Value)
                {
                    string result = $"* {cvp.Key} - {cvp.Value}";

                    if (kvp.Key == searchedColor && cvp.Key == searchedClothes)
                    {
                        result += " (found!)";
                    }

                    Console.WriteLine(result);

                }
            }



        }
    }
}
