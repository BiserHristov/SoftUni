using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class ReplaceRepeatingChars
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= input.Length - 1; i++)
            {
                if (!sb.ToString().EndsWith(input[i]))
                {
                    sb.Append(input[i]);
                }

            }

            Console.WriteLine(sb.ToString());
        }
    }
}
