using System;
using System.Linq;

namespace _03.Stack
{
   public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            CustomStack<int> customStack = new CustomStack<int>();

            while (input[0] != "END")
            {


                if (input[0] == "Push")
                {
                    input = input.Skip(1).ToArray();

                    for (int i = 0; i < input.Length; i++)
                    {
                        customStack.Add(int.Parse(input[i]));
                    }
                }
                else if (input[0] == "Pop")
                {
                    try
                    {
                        customStack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                   
                }

                input = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in customStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
