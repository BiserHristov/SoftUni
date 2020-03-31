using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _10.Snowballs
{
    class Start
    {
        static void Main()
        {
            //            Tony and Andi love playing in the snow and having snowball fights, but they always argue which makes the best snowballs. They have decided to involve you in their fray, by making you write a program, which calculates snowball data, and outputs the best snowball value.
            //You will receive N – an integer, the number of snowballs being made by Tony and Andi.
            //For each snowball you will receive 3 input lines:
            //•	On the first line you will get the snowballSnow – an integer.
            //•	On the second line you will get the snowballTime – an integer.
            //•	On the third line you will get the snowballQuality – an integer.
            //For each snowball you must calculate its snowballValue by the following formula:
            //(snowballSnow / snowballTime) ^ snowballQuality
            //At the end you must print the highest calculated snowballValue.


            int quantity = int.Parse(Console.ReadLine());
            BigInteger bestValue = 0;
            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;

            for (int i = 0; i < quantity; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger currentValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (currentValue > bestValue)
                {
                    bestValue = currentValue;
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                    bestSnowballQuality = snowballQuality;

                }

            }

            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestValue} ({bestSnowballQuality})");

        }
    }
}
