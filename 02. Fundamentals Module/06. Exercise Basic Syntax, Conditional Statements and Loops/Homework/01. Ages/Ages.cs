using System;
using System.Globalization;

namespace BasicSyntaxConditionalStatementsAndLoops
{
    class Ages
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            int age = int.Parse(Console.ReadLine());

            if (age >= 66)
            {
                text = "elder";
            }
            else if (age >= 20)
            {
                text = "adult";
            }
            else if (age >= 14)
            {
                text = "teenager";
            }
            else if (age >= 3)
            {
                text = "child";
            }
            else if (age >= 0 && age <= 2)
            {
                text = "baby";
            }

            Console.WriteLine(text);
        }
    }
}

