using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _02.Solution
{
    class MuOnline
    {
        static void Main()
        {
            List<string> list = new List<string>();
            list.Add("pseho");
            list.Add("kiro");
            list.Add("stefan");
            list.Add("stoyan");
            Console.WriteLine(list.Capacity);
            list.Insert(4, "mama");
            Console.WriteLine(list.Capacity);
            Console.WriteLine(list[4]);

            //    List<string> rooms = Console.ReadLine()
            //        .Split('|', StringSplitOptions.RemoveEmptyEntries)
            //        .Select(x => x.Trim())
            //        .ToList();

            //    double health = 100;
            //    double bitCoins = 0;

            //    for (int i = 0; i < rooms.Count; i++)
            //    {
            //        List<string> line = rooms[i].Split().ToList();
            //        string command = line[0];

            //        if (command == "potion")
            //        {
            //            double amount = double.Parse(line[1]);

            //            if (health + amount > 100)
            //            {
            //                Console.WriteLine($"You healed for {100 - health} hp.");
            //                health = 100;
            //                Console.WriteLine($"Current health: {health} hp.");
            //            }
            //            else
            //            {
            //                health += amount;
            //                Console.WriteLine($"You healed for {amount} hp.");
            //                Console.WriteLine($"Current health: {health} hp.");
            //            }

            //        }
            //        else if (command == "chest")
            //        {
            //            double bitCoinsFound = double.Parse(line[1]);
            //            Console.WriteLine($"You found {bitCoinsFound} bitcoins.");
            //            bitCoins += bitCoinsFound;
            //        }
            //        else
            //        {
            //            string monsterName = command;
            //            double monsterAttack = double.Parse(line[1]);

            //            health -= monsterAttack;

            //            if (health > 0)
            //            {
            //                Console.WriteLine($"You slayed { monsterName}.");
            //            }
            //            else
            //            {
            //                Console.WriteLine($"You died! Killed by {monsterName}.");
            //                Console.WriteLine($"Best room: {i + 1}");
            //                return;
            //            }
            //        }

            //    }

            //    Console.WriteLine($"You've made it!");
            //    Console.WriteLine($"Bitcoins: {bitCoins}");
            //    Console.WriteLine($"Health: {health}");
        }
    }
}
