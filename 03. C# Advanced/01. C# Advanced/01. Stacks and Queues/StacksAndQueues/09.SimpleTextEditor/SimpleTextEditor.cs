using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    public class SimpleTextEditor
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();
            string text = string.Empty;

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                char command = Convert.ToChar(input[0]);

                if (command == '1')
                {
                    text+=input[1];
                    stack.Push(text);
                }
                else if (command == '2')
                {
                    int charsToRemove = int.Parse(input[1]);
                    text=text.Substring(0, text.Length - charsToRemove);
                    stack.Push(text);
                }
                else if (command == '3')
                {
                    char element = text[int.Parse(input[1]) - 1];
                    Console.WriteLine(element);
                }
                else if (command == '4')
                {

                    stack.Pop();
                    if (stack.Any())
                    {
                        text = stack.Peek();

                    }
                    else
                    {
                        text = string.Empty;
                    }
                   
                }
            }
        }
    }
}
