using System;

namespace P01.ClassDataBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {

                var box = new Box(length, width, height);
                Console.WriteLine(box);
            }
            catch (ArgumentOutOfRangeException m)
            {

                Console.WriteLine(m.ParamName);
            }


        }
    }
}
