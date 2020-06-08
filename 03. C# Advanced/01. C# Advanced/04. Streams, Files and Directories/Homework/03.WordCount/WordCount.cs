using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.WordCount
{
    public class WordCount
    {
        public static void Main()
        {
            string wordsPath = "words.txt";
            string textPath = "text.txt";
            string[] inputWords = File.ReadAllLines(wordsPath);
            string[] inputText = File.ReadAllLines(textPath);
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var word in inputWords)
            {
                dict.Add(word.ToLower(), 0);
            }

            for (int i = 0; i < inputText.Length; i++)
            {
                string[] text = inputText[i]
                    .ToLower()
                    .Split(new char[] { ' ', '.', ',','?','!','-'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int j = 0; j < text.Length; j++)
                {
                    if (dict.ContainsKey(text[j]))
                    {
                        dict[text[j]]++;
                    }
                }
            }

            foreach (var wcp in dict.OrderByDescending(x=>x.Value))
            {
                File.AppendAllText("actualResults.txt", $"{wcp.Key} - {wcp.Value}\n");
            }
        }
    }
}
