using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    public class BasicQueueOperations
    {
        public static void Main()
        {
            List<int> list = new List<int>(Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToList());
            int pushNumbers = list[0];
            int popNumbers = list[1];
            int searchNumber = list[2];

            Queue<int> queue = new Queue<int>();
            string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arr.Length; i++)
            {
                queue.Enqueue(int.Parse(arr[i]));
            }

            for (int i = 0; i < popNumbers; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int smallest = 0;
            if (queue.Contains(searchNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                smallest = queue.Dequeue();

                while (queue.Count > 0)
                {
                    int currentElement = queue.Dequeue();
                    if (currentElement < smallest)
                    {
                        smallest = currentElement;
                    }
                }

                Console.WriteLine(smallest);

            }
        }
    }
}
