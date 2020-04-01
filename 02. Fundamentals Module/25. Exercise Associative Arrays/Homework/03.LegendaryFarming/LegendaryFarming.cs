using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    public class LegendaryFarming
    {
        public static void Main()
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();
            while (true)
            {
                List<string> line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();


                for (int i = 0; i <= line.Count - 2; i += 2)
                {
                    int quantity = int.Parse(line[i]);
                    string material = line[i + 1];
                    material = material.ToLower();

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        if (keyMaterials.ContainsKey(material))
                        {
                            keyMaterials[material] += quantity;

                        }
                        else
                        {
                            keyMaterials[material] = quantity;
                        }

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;
                            PrintData(keyMaterials, junkMaterials, material);
                            return;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] += quantity;
                        }
                        else
                        {
                            junkMaterials[material] = quantity;
                        }
                    }

                }

            }

        }

        static void PrintData(Dictionary<string, int> keyMaterials, Dictionary<string, int> junkMaterials, string material)
        {
            string result = "";
            if (material == "shards")
            {
                result = "Shadowmourne";
            }
            else if (material == "fragments")
            {
                result = "Valanyr";
            }
            else if (material == "motes")
            {
                result = "Dragonwrath";
            }

            Console.WriteLine($"{result} obtained!");

            keyMaterials = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(t => t.Key, t => t.Value);

            foreach (var item in keyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            junkMaterials = junkMaterials
                .OrderBy(x => x.Key)
                .ToDictionary(t => t.Key, t => t.Value);

            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
