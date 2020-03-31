using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.LadyBugs
{
    class Start
    {
        /// <summary>
        /// 10.	*LadyBugs
       ///        You are given a field size and the indexes of ladybugs inside the field.After that on every new line until the "end" command is given, a ladybug changes its position either to its left or to its right by a given fly length.
       ///       A command to a ladybug looks like this: "0 right 1". This means that the little insect placed on index 0 should fly one index to its right.If the ladybug lands on a fellow ladybug, it continues to fly in the same direction by the same fly length. If the ladybug flies out of the field, it is gone.
       ///       For example, imagine you are given a field with size 3 and ladybugs on indexes 0 and 1. If the ladybug on index 0 needs to fly to its right by the length of 1 (0 right 1) it will attempt to land on index 1 but as there is another ladybug there it will continue further to the right by additional length of 1, landing on index 2. After that, if the same ladybug needs to fly to its right by the length of 1 (2 right 1), it will land somewhere outside of the field, so it flies away:
       
       ///If you are given ladybug index that does not have ladybug there, nothing happens.If you are given ladybug index that is outside the field, nothing happens.
       ///Your job is to create the program, simulating the ladybugs flying around doing nothing.At the end, print all cells in the field separated by blank spaces. For each cell that has a ladybug on it print '1' and for each empty cells print '0'. For the example above, the output should be '0 1 0'. 

        /// </summary>

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] >= 0 && line[i] <= arr.Length - 1)
                {
                    arr[line[i]] = 1; ;
                }
            }


            string command = Console.ReadLine();
            int endIndex = 0;

            while (command != "end")
            {
                string[] commandAsArray = command.Split();
                int startIndex = int.Parse(commandAsArray[0]);
                string direction = commandAsArray[1];
                int step = int.Parse(commandAsArray[2]);

                if (startIndex < 0 ||
                    startIndex > arr.Length - 1 ||
                    step == 0 ||
                    arr[startIndex] == 0)
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (direction == "right")
                {
                    endIndex = startIndex + step;
                    if (endIndex > arr.Length - 1)
                    {
                        arr[startIndex] = 0;
                        command = Console.ReadLine();
                        continue;
                    }

                }
                else
                {
                    endIndex = startIndex - step;
                    if (endIndex < 0)
                    {
                        arr[startIndex] = 0;
                        command = Console.ReadLine();
                        continue;
                    }
                }
                bool keepLooping = true;

                while (keepLooping)
                {


                    if (arr[endIndex] == 0)
                    {
                        arr[endIndex] = 1;
                        arr[startIndex] = 0;
                        break;
                    }
                    else
                    {
                        if (direction == "right")
                        {
                            while (arr[endIndex] != 0)
                            {
                                endIndex += step;
                                if (endIndex > arr.Length - 1)
                                {
                                    arr[startIndex] = 0;
                                    keepLooping = false;
                                    break;
                                }
                            }

                        }
                        else
                        {
                            while (arr[endIndex] != 0)
                            {
                                endIndex -= step;
                                if (endIndex < 0)
                                {
                                    arr[startIndex] = 0;
                                    keepLooping = false;
                                    break;
                                }
                            }

                        }
                    }


                }

                command = Console.ReadLine();

            }


            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
