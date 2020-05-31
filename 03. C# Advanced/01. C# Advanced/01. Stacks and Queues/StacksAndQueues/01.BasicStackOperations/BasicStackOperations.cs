using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _01.BasicStackOperations
{
    public class BasicStackOperations
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

            Stack<int> stack = new Stack<int>();
            string[] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(int.Parse(arr[i]));
            }

            for (int i = 0; i < popNumbers; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stack.Contains(searchNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                
                Console.WriteLine(stack.Min());

            }
        }
    }
}
