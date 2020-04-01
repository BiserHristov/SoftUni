using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Snowwhite
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> nameColorPhysics = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                List<string> data = input
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                string name = data[0];
                string color = data[1];
                int physics = int.Parse(data[2]);

                if (!nameColorPhysics.ContainsKey(name))
                {
                    nameColorPhysics.Add(name, new Dictionary<string, int>());
                    nameColorPhysics[name].Add(color, physics);
                }
                else
                {
                    if (nameColorPhysics[name].ContainsKey(color))
                    {
                        if (physics > nameColorPhysics[name][color])
                        {
                            nameColorPhysics[name][color] = physics;
                        }
                    }
                    else
                    {
                        nameColorPhysics[name].Add(color, physics);

                    }
                }


                input = Console.ReadLine();
            }
            ////name(color, physics)
            //var ss = nameColorPhysics
            //    .OrderByDescending(x => x.Value.Values.Sum()h
            //    .ThenByDescending(k => k.Value.Keys.Count());
            var colorNamePhysics = new Dictionary<string, Dictionary<string, int>>();

            foreach (var item in nameColorPhysics)
            {
                
                foreach (var cpp in item.Value)
                {
                    if (!colorNamePhysics.ContainsKey(cpp.Key))
                    {
                        colorNamePhysics.Add(cpp.Key, new Dictionary<string, int>());
                      
                    }
                    colorNamePhysics[cpp.Key].Add(item.Key, cpp.Value);

                }
            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();
            foreach (var hatColor in colorNamePhysics.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }
            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }


            //////var ordered = colorNamePhysics
            //////    .OrderByDescending(x => x.Value.Values.Sum())
            //////    .ThenByDescending(k => k.Value.Count())
            //////    .ToDictionary(x => x.Key, y => y.Value);

            //////foreach (var item in ordered)
            //////{
            //////    foreach (var npp in item.Value)
            //////    {
            //////        Console.WriteLine($"({item.Key}) {npp.Key} <-> {npp.Value}");

            //////    }


            //////}

        }
    }
}
