using System;

namespace _02.GenericBoxOfIntegers
{
    class GenericBoxOfIntegers
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int data = int.Parse(Console.ReadLine());
                var box = new Box<int>(data);
            
                Console.WriteLine(box.ToString());
            }
        }
    }
}
