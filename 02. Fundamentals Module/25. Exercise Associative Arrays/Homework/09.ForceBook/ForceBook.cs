using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class ForceBook
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {

                if (input.Contains(" | "))
                {
                    List<string> line = input
                        .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    string forceSide = line[0];
                    string forceUser = line[1];

                    bool exist = false;
                    bool breakUp = false;

                    //Check if user exist in every side
                    foreach (var item in dict)
                    {
                        foreach (var user in item.Value)
                        {
                            if (user == forceUser)
                            {
                                exist = true;
                                breakUp = true;
                                break;


                            }
                        }

                        if (breakUp)
                        {
                            break;
                        }
                    }

                    //If user does not exist, check if side exist
                    if (!exist)
                    {
                        if (dict.ContainsKey(forceSide))
                        {
                            if (!dict[forceSide].Contains(forceUser))
                            {
                                dict[forceSide].Add(forceUser);
                            }
                        }
                        else
                        {
                            dict.Add(forceSide, new List<string>());
                            dict[forceSide].Add(forceUser);
                        }
                    }
                }
                else if (input.Contains(" -> "))
                {
                    List<string> line = input
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    string forceUser = line[0];
                    string newForceSide = line[1];

                    bool userExist = false;
                    bool toBreak = false;


                    //Checks if user exist in every side
                    foreach (var item in dict)
                    {
                        foreach (var user in item.Value)
                        {
                            if (user == forceUser)
                            {
                                if (dict.ContainsKey(newForceSide))
                                {
                                    dict[newForceSide].Add(forceUser);
                                    dict[item.Key].Remove(forceUser);

                                }
                                else
                                {
                                    dict.Add(newForceSide, new List<string>());
                                    dict[newForceSide].Add(forceUser);
                                    dict[item.Key].Remove(forceUser);
                                }

                                Console.WriteLine($"{forceUser} joins the {newForceSide} side!");
                                userExist = true;
                                toBreak = true;
                                break;


                            }
                        }

                        if (toBreak)
                        {
                            break;
                        }
                    }

                    //If user does not exist, check if side exist
                    if (!userExist)
                    {
                        if (dict.ContainsKey(newForceSide))
                        {
                            dict[newForceSide].Add(forceUser);
                        }
                        else
                        {
                            dict.Add(newForceSide, new List<string>());
                            dict[newForceSide].Add(forceUser);
                        }

                        Console.WriteLine($"{forceUser} joins the {newForceSide} side!");

                    }

                }

                input = Console.ReadLine();
            }

            dict = dict
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => (List<string>)x.Value.OrderBy(v => v).ToList());

            foreach (var item in dict)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");

                    foreach (var user in item.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }

                }

            }
        }
    }
}
