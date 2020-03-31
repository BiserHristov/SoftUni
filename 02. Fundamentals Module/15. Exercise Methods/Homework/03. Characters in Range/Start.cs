using System;

namespace _3._Characters_in_Range
{
    class Start
    {
        static void Main()
        {
            //            3.Characters in Range
            //Write a method that receives two characters and prints on a single line all the characters in between them according to ASCII.
            char first = char.Parse(Console.ReadLine());
            char last = char.Parse(Console.ReadLine());

            string charsAsString = GiveCharsBetweenLimits(first, last);
            Console.WriteLine(string.Join(" ", charsAsString));


        }

        static string GiveCharsBetweenLimits(char start, char end)
        {
            string result = string.Empty;

            if (end < start)
            {
                char temp = end;
                end = start;
                start = temp;

            }

            for (int i = start + 1; i < end; i++)
            {
                result += (char)i + " ";
            }

            return result;
        }

    }
}
