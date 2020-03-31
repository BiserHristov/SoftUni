using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_Overflow
{
    class Start
    {
        static void Main(string[] args)
        {
            //You have a water tank with capacity of 255 liters.On the next n lines, you will receive liters of water, which you have to pour in your tank. If the capacity is not enough, print “Insufficient capacity!” and continue reading the next line. On the last line, print the liters in the tank.

            int lines = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 1; i <= lines; i++)
            {
                int litres = int.Parse(Console.ReadLine());
                if ((sum + litres) > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    sum += litres;
                }
            }

            Console.WriteLine(sum);

        }
    }
}
