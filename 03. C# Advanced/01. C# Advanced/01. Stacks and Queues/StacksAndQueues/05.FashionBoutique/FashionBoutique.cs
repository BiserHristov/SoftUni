using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    public class FashionBoutique
    {
        public static void Main()
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(x => int.Parse(x)));
            int capacity = int.Parse(Console.ReadLine());
            int boxes = 0;
            int sum = 0;

            while (stack.Count != 0)
            {

                int currentClothe = stack.Pop();

                if (sum + currentClothe < capacity)
                {
                    sum += currentClothe;
                }
                else if (sum + currentClothe == capacity)
                {
                    boxes++;
                    sum = 0;
                }
                else if (sum + currentClothe > capacity)
                {
                    boxes++;
                    sum = currentClothe;
                }
            }

            if (sum!=0)
            {
                boxes++;
            }

            Console.WriteLine(boxes);
        }
    }
}
