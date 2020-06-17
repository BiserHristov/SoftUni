using System;

namespace _01.GenericBoxOfString
{
   public  class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string data = Console.ReadLine();
                var box = new Box<string>(data);
                box.Value = data;
                Console.WriteLine(box.ToString());
            }
        }
    }
}
