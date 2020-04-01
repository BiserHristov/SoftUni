using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MorseCodeTranslator
{
    class MorseCodeTranslator
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> alphabet = new Dictionary<string, char>();
            alphabet.Add(".-", 'A');
            alphabet.Add("-...", 'B');
            alphabet.Add("-.-.", 'C');
            alphabet.Add("-..", 'D');
            alphabet.Add(".", 'E');
            alphabet.Add("..-.", 'F');
            alphabet.Add("--.", 'G');
            alphabet.Add("....", 'H');
            alphabet.Add("..", 'I');

            alphabet.Add(".---", 'J');
            alphabet.Add("-.-", 'K');
            alphabet.Add(".-..", 'L');
            alphabet.Add("--", 'M');
            alphabet.Add("-.", 'N');
            alphabet.Add("---", 'O');
            alphabet.Add(".--.", 'P');
            alphabet.Add("--.-", 'Q');
            alphabet.Add(".-.", 'R');
            alphabet.Add("...", 'S');
            alphabet.Add("-", 'T');
            alphabet.Add("..-", 'U');
            alphabet.Add("...-", 'V');
            alphabet.Add(".--", 'W');
            alphabet.Add("-..-", 'X');
            alphabet.Add("-.--", 'Y');
            alphabet.Add("--..", 'Z');


            List<string> messsage = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < messsage.Count; i++)
            {
                if (messsage[i]== "|")
                {
                    sb.Append(' ');
                }
                else
                {
                    if (alphabet.ContainsKey(messsage[i]))
                    {
                        sb.Append(alphabet[messsage[i]]);

                    }

                }
            }

            Console.WriteLine(sb.ToString()); ;
      
        }
    }
}
