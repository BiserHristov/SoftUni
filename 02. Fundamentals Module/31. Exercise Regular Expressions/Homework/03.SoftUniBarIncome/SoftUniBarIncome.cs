using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class SoftUniBarIncome
    {
        static void Main()
        {
            string line = Console.ReadLine();
            decimal totalPrice = 0;

            while (line != "end of shift")
            {
                Regex regex = new Regex(@"^%([A-Z]{1}[a-z]+)%[^|$%\.]*<(\w+)>[^|$%\.]*?\|(\d+)\|[^|$%\.]*?(\d+\.?\d*)\$$");
                MatchCollection matches = regex.Matches(line);

                foreach (Match match in matches)
                {
                    decimal price = decimal.Parse(match.Groups[3].Value) * decimal.Parse(match.Groups[4].Value);
                    totalPrice += price;
                    Console.WriteLine($"{match.Groups[1]}: {match.Groups[2]} - {price:F2}"); ;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalPrice:F2}");
        }
    }
}
