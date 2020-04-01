using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01WarriorsQuest
{
    class WarriorsQuest
    {
        static void Main(string[] args)
        {


            string message = Console.ReadLine();
            string line = Console.ReadLine();

            while (line != "For Azeroth")
            {
                List<string> input = line.Split().ToList();
                string command = input[0];

                if (command == "GladiatorStance")
                {
                    message = message.ToUpper();
                    Console.WriteLine(message);
                }
                else if (command == "DefensiveStance")
                {
                    message = message.ToLower();
                    Console.WriteLine(message);
                }
                else if (command == "Dispel")
                {
                    int index = int.Parse(input[1]);
                    char letter = char.Parse(input[2]);
                    if (index < 0 || index > message.Length - 1)
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                    else
                    {
                        //Друг възможен вариант: правимм стринга на масив от чарове, променяме стоността на чара на желания индекс и после го правим отново на стринг.

                        //char[] temp = message.ToCharArray();
                        //temp[index] = letter;
                        //message = new string(temp);

                        message = message.Remove(index, 1);
                        message = message.Insert(index, letter.ToString());
                        Console.WriteLine("Success!");
                    }

                }
                else if (command == "Target")
                {
                    if (input[1] == "Change")
                    {
                        string oldSubstring = input[2];
                        string newSubstring = input[3];

                        message = message.Replace(oldSubstring, newSubstring);
                        Console.WriteLine(message);
                    }
                    else if (input[1] == "Remove")
                    {
                        int index = message.IndexOf(input[2]);
                        message = message.Remove(index, input[2].Length);
                        Console.WriteLine(message);

                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist!");
                    }

                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }

                line = Console.ReadLine();

            }


        }
    }

}

