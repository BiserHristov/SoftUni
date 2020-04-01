using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.TreasureFinder
{
    class TreasureFinder
    {
        static void Main(string[] args)
        {
            List<int> key = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            string message = Console.ReadLine();
          

            while (message != "find")
            {
                StringBuilder sb = new StringBuilder();
                int counter = 0;
                for (int i = 0; i < message.Length; i++)
                {
                    sb.Append((char)(message[i]- key[counter]));
                    counter++;
                    if (counter == key.Count)
                    {
                        counter = 0;
                    }

                }
                string result = sb.ToString();
                int startElementIndex = result.IndexOf('&');
                int endElementIndex = result.IndexOf('&', startElementIndex + 1);
                string element = result.Substring(startElementIndex + 1, endElementIndex - startElementIndex-1);

                int startCordIndex = result.IndexOf('<');
                int endCordIndex = result.IndexOf('>');
                string coordinates = result.Substring(startCordIndex + 1, endCordIndex - startCordIndex-1);

                Console.WriteLine($"Found {element} at {coordinates}");



                message = Console.ReadLine();
            }




        }
    }
}
