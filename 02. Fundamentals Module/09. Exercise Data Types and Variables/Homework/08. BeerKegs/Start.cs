using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.BeerKegs
{
    class Start
    {
        static void Main()
        {
            //            Write a program, which calculates the volume of n beer kegs. You will receive in total 3 * n lines.Each three lines will hold information for a single keg.First up is the model of the keg, after that is the radius of the keg, and lastly is the height of the keg.
            //Calculate the volume using the following formula: π* r^2 * h.
            //At the end, print the model of the biggest keg.

            int count = int.Parse(Console.ReadLine());
            double maxVolume = double.MinValue;
            string maxModel = string.Empty;

            for (int i = 1; i <= count; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * radius * radius * height;

                if (volume > maxVolume)
                {
                    maxModel = model;
                    maxVolume = volume;
                }

            }

            Console.WriteLine(maxModel);
        }
    }
}
