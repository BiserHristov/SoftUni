using System;
using System.Globalization;

namespace BasicSyntaxConditionalStatementsAndLoops
{
    class PadawanEquipment
    {
        static void Main(string[] args)
        {
            decimal amount = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal lightsabers = decimal.Parse(Console.ReadLine());
            decimal robes = decimal.Parse(Console.ReadLine());
            decimal belts = decimal.Parse(Console.ReadLine());

            decimal moneyNeeded = 0;

            decimal lightsabersPrice = (Math.Ceiling(((int)(students)) * 1.1M)) * lightsabers;
            decimal robesPrice = (decimal)(students) * robes;
            int freeBelts = (int)(students / 6);
            decimal beltsPrice = (decimal)(students - freeBelts) * belts;

            moneyNeeded = lightsabersPrice + robesPrice + beltsPrice;

            if (moneyNeeded <= amount)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(moneyNeeded - amount):F2}lv more.");

            }

        }

    }
}

