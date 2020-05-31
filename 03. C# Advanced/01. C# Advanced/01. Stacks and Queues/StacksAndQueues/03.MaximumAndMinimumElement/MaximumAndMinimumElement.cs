using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    public class MaximumAndMinimumElement
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < count; i++)
            {
                List<string> line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                string command = line[0];

                switch (command)
                {
                    case "1":
                        stack.Push(int.Parse(line[1]));
                        break;
                    case "2":
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case "3":
                        if (stack.Count > 0)
                        {
                            int maxNumber = FindMaxNumber(stack);
                            Console.WriteLine(maxNumber);
                        }
                        break;
                    case "4":
                        if (stack.Count > 0)
                        {
                            int minNumber = FindMinNumber(stack);
                            Console.WriteLine(minNumber);
                        }
                        break;
                    default:
                        break;
                }


            }

            Console.WriteLine(string.Join(", ", stack));
        }

        public static int FindMaxNumber(Stack<int> stack)
        {
            int[] arr = stack.ToArray();

            return arr.Max();
        }

        public static int FindMinNumber(Stack<int> stack)
        {
            int[] arr = stack.ToArray();

            return arr.Min();

        }
    }
}
