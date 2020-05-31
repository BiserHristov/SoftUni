using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _08.BalancedParentheses
{
    public class BalancedParentheses
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            char[] openSymbols = new char[] { '(', '{', '[' };
            foreach (char item in input)
            {
                if (openSymbols.Contains(item))
                {
                    stack.Push(item);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    if ((stack.Peek() == '(' && item == ')') ||
                        (stack.Peek() == '{' && item == '}') ||
                        (stack.Peek() == '[' && item == ']'))
                    {

                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
