using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Chronometer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "start")
                {
                    chronometer.Start();
                }
                else if (line == "stop")
                {
                    chronometer.Stop();
                }
                else if (line == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (line == "laps")
                {
                    var laps = chronometer.Laps;
                    Console.Write("Laps:");
                    if (laps.Count == 0)
                    {
                        Console.WriteLine(" no laps");
                    }
                    else
                    {
                        Console.WriteLine();
                        for (int i = 0; i < laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {laps[i]}");
                        }

                    }
                }
                else if (line == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (line == "reset")
                {
                    chronometer.Reset();
                }
                else if (line == "exit")
                {
                    return;
                }

            }
        }
    }
}
