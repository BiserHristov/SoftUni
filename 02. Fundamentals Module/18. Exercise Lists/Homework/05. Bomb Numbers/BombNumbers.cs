using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class BombNumbers
    {
        static void Main()
        {
            //Write a program that reads a sequence of numbers and a special bomb number with a certain power. Your task is to detonate every occurrence of the special bomb number and according to its 
            //power -his neighbors from left and right.Detonations are performed from left to right and all detonated numbers disappear. Finally print the sum of the remaining elements in the sequence.


            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> command = Console.ReadLine().Split().Select(int.Parse).ToList();
            int bombNumber = command[0];
            int power = command[1];

            while (list.IndexOf(bombNumber) >= 0)
            {


                for (int i = 1; i <= power; i++)
                {
                    if (list.IndexOf(bombNumber) - 1 >= 0)
                    {
                        list.RemoveAt(list.IndexOf(bombNumber) - 1);
                    }
                    else
                    {
                        break;
                    }
                }

                for (int i = 1; i <= power; i++)
                {
                    if (list.IndexOf(bombNumber) + 1 <= list.Count - 1)
                    {
                        list.RemoveAt(list.IndexOf(bombNumber) + 1);
                    }
                    else
                    {
                        break;
                    }
                }

                list.Remove(bombNumber);
            }

            Console.WriteLine(list.Sum());


        }

    }
}
