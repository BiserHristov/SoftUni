using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_2
{
    class EmojiDetector
    {
        static void Main()
        {
            string input = Console.ReadLine();

            MatchCollection emoji = Regex.Matches(input, @"(\*\*|::)(?<emoji>[A-Z][a-z]{2,})\1");
            MatchCollection numbers = Regex.Matches(input, @"[0-9]");

            int emojiCount = emoji.Count;
            BigInteger coolSum = 1;

            foreach (Match item in numbers)
            {
                coolSum *= int.Parse(item.Value);

            }

            List<string> validEmoji = new List<string>();

            foreach (Match item in emoji)
            {
                //int?



                int emojiAsciiSum = 0;
                string currentItem = item.Groups["emoji"].Value;


                for (int i = 0; i < currentItem.Length; i++)
                {
                    emojiAsciiSum += (int)(currentItem[i]);

                }

                // > or >=

                if (emojiAsciiSum > coolSum)
                {
                    validEmoji.Add(item.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolSum}");
            Console.WriteLine($"{emojiCount} emojis found in the text. The cool ones are:");
            if (validEmoji.Count > 0)
            {
                foreach (var item in validEmoji)
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}
