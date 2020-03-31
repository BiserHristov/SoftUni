using System;

namespace _02._Vowels_Count
{
    class Start
    {
        static void Main()
        {
            //            2.Vowels Count
            //Write a method that receives a single string and prints the count of the vowels. Use appropriate name for the method.

            string line = Console.ReadLine();

            int result = GetVowelsCount(line);
            Console.WriteLine(result);

        }

        static int GetVowelsCount(string input)
        {
            int count = 0;
            char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u', 'y' };

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (Char.ToLower(input[i]) == vowels[j])
                    {
                        count++;
                    }
                }

            }

            return count;
        }
    }
}
