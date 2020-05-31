using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    public class SongsQueue
    {
        public static void Main()
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (queue.Count != 0)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = input[0];

                switch (command)
                {
                    case "Play":
                        queue.Dequeue();
                        break;
                    case "Add":
                        string name = string.Empty;
                        for (int i = 1; i <= input.Length - 1; i++)
                        {
                            name += input[i] + ' ';
                        }
                        name = name.TrimEnd();

                        if (!queue.Contains(name))
                        {
                            queue.Enqueue(name);
                        }
                        else
                        {
                            Console.WriteLine($"{name} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", queue));
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
