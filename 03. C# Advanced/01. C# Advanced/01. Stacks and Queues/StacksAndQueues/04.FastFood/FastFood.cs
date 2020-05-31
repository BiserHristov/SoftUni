using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class FastFood
    {
        static void Main()
        {
            int totalFood = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)));

            int[] arr = queue.ToArray();
            Console.WriteLine(arr.Max());

            while (queue.Count > 0 && totalFood >= queue.Peek())
            {
                totalFood -= queue.Dequeue();
                
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
            }


        }
    }
}
