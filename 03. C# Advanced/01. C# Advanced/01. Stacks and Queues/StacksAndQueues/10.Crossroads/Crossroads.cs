using System;
using System.Collections;
using System.Collections.Generic;

namespace _10.Crossroads
{
    public class Crossroads
    {
        public static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int counter = 0;

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {

                    int currentGreenLight = greenLight;

                    while (cars.Count != 0)
                    {

                        string currentCar = cars.Peek();
                        int currentLength = currentCar.Length;

                        if (currentLength <= currentGreenLight)
                        {
                            cars.Dequeue();
                            counter++;
                            currentGreenLight -= currentLength;

                        }
                        else
                        {
                            if (currentLength <= currentGreenLight + freeWindow)
                            {
                                cars.Dequeue();
                                counter++;
                                break;

                            }
                            else
                            {
                                char hitChar = currentCar[currentGreenLight + freeWindow];
                                Console.WriteLine($"A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {hitChar}.");
                                return;
                            }

                        }
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}

