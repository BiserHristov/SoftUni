using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PokeMon
{
    class Start
    {
        static void Main()
        {
            //            A Poke Mon is a special type of pokemon which likes to Poke others. But at the end of the day, the Poke Mon wants to keeps statistics, about how many pokes it has managed to make.
            //The Poke Mon pokes his target, and then proceeds to poke another target. The distance between his targets reduces his poke power.
            //You will be given the poke power the Poke Mon has, N – an integer.
            //Then you will be given the distance between the poke targets, M – an integer.
            //Then you will be given the exhaustionFactor Y – an integer.
            //Your task is to start subtracting M from N until N becomes less than M, i.e.the Poke Mon does not have enough power to reach the next target.
            //Every time you subtract M from N that means you’ve reached a target and poked it successfully. COUNT how many targets you’ve poked – you’ll need that count.
            //The Poke Mon becomes gradually more exhausted.IF N becomes equal to EXACTLY 50 % of its original value, you must divide N by Y, if it is POSSIBLE.This DIVISION is between integers.
            //If a division is not possible, you should NOT do it.Instead, you should continue subtracting.
            //After dividing, you should continue subtracting from N, until it becomes less than M.
            //When N becomes less than M, you must take what has remained of N and the count of targets you’ve poked, and print them as output.

            //NOTE: When you are calculating percentages, you should be PRECISE at maximum.
            //Example: 505 is NOT EXACTLY 50 % from 1000, its 50.5 %.

            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int pokedTargert = 0;
            double halfPower = 1.0 * power / 2;

            while (power >= distance)
            {
                power -= distance;
                pokedTargert++;

                if (exhaustionFactor!=0 && power*1.0 == halfPower)
                {
                    power /= exhaustionFactor;
                }

            }

            Console.WriteLine(power);
            Console.WriteLine(pokedTargert);



        }
    }
}
