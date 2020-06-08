using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace _02.LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            string path = "text.txt";
            string[] lines = File.ReadAllLines(path);
            StringBuilder sb = new StringBuilder();
           

            for (int i = 0; i < lines.Length; i++)
            {
                int letterCount = 0;
                int marksCount = 0;
                string[] words = lines[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < words.Length; j++)
                {
                    for (int k = 0; k < words[j].Length; k++)
                    {
                        char currentChar = words[j][k];
                        if (Char.IsLetter(currentChar))
                        {
                            letterCount++;
                        }
                        else if (!Char.IsWhiteSpace(currentChar) && !Char.IsDigit(currentChar))
                        {
                            marksCount++;
                        }

                    }
                }
               sb.AppendLine($"Line {i + 1}: {lines[i]} ({letterCount})({marksCount})");

            }

            File.WriteAllText("output.txt", sb.ToString());

        }
    }
}
