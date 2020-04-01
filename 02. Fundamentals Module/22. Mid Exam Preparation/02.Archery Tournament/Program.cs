using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {

            List<int> target = Console.ReadLine()
                .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int points = 0;
            string line = Console.ReadLine();

            while (line != "Game over")
            {
                if (line.Length > 7)
                {
                    int firstSymbolIndex = line.IndexOf('@');

                    int lastSymbolIndex = line.LastIndexOf('@');
                    int startIndex = int.Parse(line.Substring(firstSymbolIndex + 1, lastSymbolIndex - firstSymbolIndex - 1));
                    if (startIndex < 0 || startIndex > target.Count - 1)
                    {
                        line = Console.ReadLine();
                        continue;

                    }
                    int lenght = int.Parse(line.Substring(lastSymbolIndex + 1, line.Length - 1 - lastSymbolIndex));
                    string command = line.Substring(0, firstSymbolIndex);
                    int counter = 0;

                    if (command == "Shoot Left")
                    {
                        int searchIndex = startIndex - lenght;
                        while (searchIndex < 0)
                        {
                            searchIndex += target.Count;
                        }

                        if (target[searchIndex] <= 5)
                        {
                            points += target[searchIndex];
                            target[searchIndex] = 0;
                        }
                        else
                        {
                            points += 5;
                            target[searchIndex] -= 5;
                        }


                    }
                    else if (command == "Shoot Right")
                    {

                        int searchIndex = startIndex + lenght;
                        while (searchIndex > target.Count - 1)
                        {
                            searchIndex -= target.Count;
                        }

                        if (target[searchIndex] <= 5)
                        {
                            points += target[searchIndex];
                            target[searchIndex] = 0;
                        }
                        else
                        {
                            points += 5;
                            target[searchIndex] -= 5;
                        }



                    }

                }

                else if (line == "Reverse")
                {
                    target.Reverse();
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" - ", target));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
