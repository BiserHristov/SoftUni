using System;

namespace Elevator
{
    class Start
    {
        static void Main()
        {
            //            3.Elevator
            //Calculate how many courses will be needed to elevate n persons by using an elevator of capacity of p persons.The input holds two lines: the number of people n and the capacity p of the elevator.

            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            double courses = 0;

            if (people <= capacity)
            {
                courses = 1;

            }
            else
            {
                courses = people / (capacity * 1.0);

            }

            Console.WriteLine(Math.Ceiling(courses));

        }
    }
}
