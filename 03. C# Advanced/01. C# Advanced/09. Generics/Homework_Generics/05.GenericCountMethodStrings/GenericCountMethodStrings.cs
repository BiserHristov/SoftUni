using _01.GenericBoxOfString;
using System;
using System.Collections.Generic;
using System.Threading;

namespace _05.GenericCountMethodStrings
{
    public class GenericCountMethodStrings
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());

            var box = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                box.Values.Add(Console.ReadLine());

            }

            string value = Console.ReadLine();

            Console.WriteLine(box.GreaterElementsCount(value));


        }


    }
}
