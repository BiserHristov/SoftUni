using System;

namespace _06._Middle_Characters
{
    class Start
    {
        static void Main()
        {
            //            6.Middle Characters
            //You will receive a single string.Write a method that prints the middle character.If the length of the string is even there are two middle characters.

            string line = Console.ReadLine();
            string middleChars = GiveMiddleCharacters(line);
            Console.WriteLine(middleChars);
        }

        static string GiveMiddleCharacters(string input)
        {
            string result = string.Empty;

            if (input.Length % 2 != 0)
            {
                result = (input[input.Length / 2]).ToString();
            }
            else if (input.Length % 2 == 0)
            {
                result = input[(input.Length / 2) - 1].ToString() + input[input.Length / 2].ToString();
            }

            return result;
        }
    }
}

