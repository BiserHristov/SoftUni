using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Furniture
    {
        static void Main()
        {
            string input = Console.ReadLine();
            decimal totalPrice = 0;
            StringBuilder sb = new StringBuilder("Bought furniture:\n");

            while (input != "Purchase")
            {
                Match furniture = Regex.Match(input, @">>([A-Za-z]+)<<(\d+\.?\d*)!(\d+)");

                if (furniture.Success)
                {
                    totalPrice += (decimal.Parse(furniture.Groups[2].Value) * decimal.Parse(furniture.Groups[3].Value));
                    sb.AppendLine(furniture.Groups[1].Value);
                }


                input = Console.ReadLine();
            }

            sb.AppendFormat($"Total money spend: {totalPrice:F2}");
            Console.WriteLine(sb.ToString());
        }
    }
}
