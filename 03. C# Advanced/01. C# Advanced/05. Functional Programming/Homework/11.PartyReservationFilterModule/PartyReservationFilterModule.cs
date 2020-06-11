using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    public class PartyReservationFilterModule
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filters = new List<string>();
            string line = Console.ReadLine();

            while (line != "Print")
            {
                string[] input = line.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = input[0];
                string criteria = input[1];
                string argument = input[2];

                if (action=="Add filter")
                {
                    filters.Add($"{ criteria};{argument}");
                }
                else if (action == "Remove filter")
                {

                    filters.Remove($"{criteria};{argument}");
                }



                line = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                string[] data = filter.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = data[0];
                string arg = data[1];

                switch (action)
                {
                    case "Starts with":
                        names = names.Where(x => !x.StartsWith(arg)).ToList();
                        break;
                    case "Ends with":
                        names = names.Where(x => !x.EndsWith(arg)).ToList();
                        break;
                    case "Length":
                        names = names.Where(x => x.Length!=int.Parse(arg)).ToList();
                        break;
                    case "Contains":

                        names = names.Where(x => !x.Contains(arg)).ToList();
                        break;
                    default:
                        break;
                }

            }

            Console.WriteLine(string.Join(' ', names));
        }
    }
}
