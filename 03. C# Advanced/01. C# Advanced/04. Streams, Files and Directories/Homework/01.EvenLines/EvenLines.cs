using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    public class EvenLines
    {
        public static void Main()
        {
            string path = "text.txt";

            using StreamReader streamReader = new StreamReader(path);
            string line = streamReader.ReadLine();
            int counter = 0;
            char[] symbols = new char[] { '-', ',', '.', '!', '?' };

            while (line != null)
            {
                if (counter++ % 2 != 0)
                {
                    line = streamReader.ReadLine();
                    continue;
                }

                string[] words = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Array.Reverse(words);

                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        if (symbols.Contains(words[i][j]))
                        {
                            words[i] = words[i].Replace(words[i][j], '@');


                        }
                    }
                }

                Console.WriteLine(string.Join(' ', words));
                line = streamReader.ReadLine();
            }


        }
    }
}
