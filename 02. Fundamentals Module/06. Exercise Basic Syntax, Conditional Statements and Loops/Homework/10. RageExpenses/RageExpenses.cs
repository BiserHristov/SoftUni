using System;
using System.Globalization;

namespace BasicSyntaxConditionalStatementsAndLoops
{
    class RageExpenses
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());

            int headset = 0;
            int mouse = 0;
            int keyboard = 0;
            int display = 0;
            int secondKeyboard = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    headset++;

                    if (i % 3 == 0)
                    {
                        keyboard++;
                        mouse++;
                        secondKeyboard++;
                    }

                }
                else if (i % 3 == 0)
                {
                    mouse++;
                }

                if (secondKeyboard == 2)
                {
                    display++;
                    secondKeyboard = 0;

                }
            }

            decimal allExpenses = headset * headsetPrice + mouse * mousePrice + keyboard * keyboardPrice + display * displayPrice;

            Console.WriteLine($"Rage expenses: {allExpenses:F2} lv.");

        }

    }
}

