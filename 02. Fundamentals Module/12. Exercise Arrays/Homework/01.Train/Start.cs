using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Start
    {
        static void Main()
        {
            //            1.Train
            //You will be given a count of wagons in a train n.On the next n lines you will receive how many people are going to get on each wagon. At the end print the whole train and after that, on the next line, the sum of the people in the train. 

            int wagons = int.Parse(Console.ReadLine());
            int[] train = new int[wagons];
            int sum = 0;

            for (int i = 0; i < wagons; i++)
            {
                train[i] = int.Parse(Console.ReadLine());
                sum += train[i];
            }


            for (int i = 0; i < wagons; i++)
            {
                Console.Write(train[i]+ " ");
            }

            Console.WriteLine("\n"+sum);
        }

    }
}
