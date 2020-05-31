using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    public class TruckTour
    {
        public static void Main(string[] args)
        {
            long count = long.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();


            for (long i = 0; i < count; i++)
            {
                queue.Enqueue(Console.ReadLine());

            }
            Queue<string> innerQueue = new Queue<string>(queue);
            long capacity = 0;

            for (int i = 0; i < queue.Count; i++)
            {
                for (int j = 0; j < queue.Count; j++)
                {
                    long[] input = innerQueue.Peek().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                    long currentCapacity = input[0];
                    long distance = input[1];

                    if (capacity + currentCapacity - distance >= 0)
                    {
                        capacity += currentCapacity - distance;
                        innerQueue.Enqueue(innerQueue.Dequeue());
                    }
                    else
                    {
                        capacity = 0;
                        break;
                    }

                }
                if (capacity > 0)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                    innerQueue = new Queue<string>(queue);
                }
            }




        }
    }
}
