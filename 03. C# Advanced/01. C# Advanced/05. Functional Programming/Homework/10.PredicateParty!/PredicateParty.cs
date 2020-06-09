using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty_
{
    public class PredicateParty
    {
        public static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string line = Console.ReadLine();

            while (line != "Party!")
            {
                string[] input = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = input[0];
                string criteria = input[1];
                string argument = input[2];
                Func<List<string>, string, List<string>> removeStartFunc = (x, y) =>
                {

                    x.RemoveAll(q => q.StartsWith(y));

                    return x;
                };

                Func<List<string>, string, List<string>> removeEndFunc = (x, y) =>
                {

                    x.RemoveAll(q => q.EndsWith(y));

                    return x;
                };

                Func<List<string>, string, List<string>> removeLengthFunc = (x, y) =>
                {

                    x.RemoveAll(q => q.Length==int.Parse(y));

                    return x;
                };

                Func<List<string>, string, List<string>> doubleStartFunc = (x, y) =>
                {
                    List<string> doubles = new List<string>();

                    doubles = x.Where(g => g.StartsWith(y)).ToList();

                    for (int i = 0; i < doubles.Count; i++)
                    {
                        int index = x.IndexOf(doubles[i]);
                        x.Insert(index, doubles[i]);
                    }

                    return x;
                };


                Func<List<string>, string, List<string>> doubleEndFunc = (x, y) =>
                {
                    List<string> doubles = new List<string>();

                    doubles = x.Where(g => g.EndsWith(y)).ToList();

                    for (int i = 0; i < doubles.Count; i++)
                    {
                        int index = x.IndexOf(doubles[i]);
                        x.Insert(index, doubles[i]);
                    }

                    return x;
                };


                Func<List<string>, string, List<string>> lengthEndFunc = (x, y) =>
                {
                    List<string> doubles = new List<string>();

                    doubles = x.Where(g => g.Length==int.Parse(y)).ToList();

                    for (int i = 0; i < doubles.Count; i++)
                    {
                        int index = x.IndexOf(doubles[i]);
                        x.Insert(index, doubles[i]);
                    }

                    return x;
                };

                if (action == "Remove")
                {
                    if (criteria == "StartsWith")
                    {
                        guests = removeStartFunc(guests, argument);
                    }
                    else if (criteria == "EndsWith")
                    {
                        guests = removeEndFunc(guests, argument);
                    }
                    else if (criteria== "Length")
                    {
                        guests = removeLengthFunc(guests, argument);
                    }
                }
                else if (action== "Double")
                {
                    if (criteria == "StartsWith")
                    {
                        guests = doubleStartFunc(guests, argument);
                    }
                    else if (criteria == "EndsWith")
                    {
                        guests = doubleEndFunc(guests, argument);
                    }
                    else if (criteria == "Length")
                    {
                        guests = lengthEndFunc(guests, argument);
                    }
                }


                line = Console.ReadLine();
            };

            if (guests.Count>0)
            {

                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}

