using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class AnonymousThreat
    {
        static void Main()
        {
            //            The Anonymous have created a cyber hypervirus, which steals data from the CIA. You, as the lead security developer in CIA, have been tasked to analyze the software of the virus and observe its actions on the data.The virus is known for his innovative and unbeleivably clever technique of merging and dividing data into partitions.
            //You will receive a single input line, containing strings, separated by spaces.The strings may contain any ASCII character except whitespace.Then you will begin receiving commands in one of the following formats:
            //•	merge { startIndex}
            //            { endIndex}
            //•	divide { index}
            //            { partitions}
            //            Every time you receive the merge command, you must merge all elements from the startIndex, till the endIndex. In other words, you should concatenate them. 
            //Example: { abc, def, ghi} -> merge 0 1-> { abcdef, ghi}
            //            If any of the given indexes is out of the array, you must take only the range that is inside the array and merge it.
            //Every time you receive the divide command, you must divide the element at the given index, into several small substrings with equal length.The count of the substrings should be equal to the given partitions. 
            //Example: { abcdef, ghi, jkl} -> divide 0 3-> { ab, cd, ef, ghi, jkl}
            //            If the string cannot be exactly divided into the given partitions, make all partitions except the last with equal lengths, and make the last one – the longest. 
            //Example: { abcd, efgh, ijkl} -> divide 0 3-> { a, b, cd, efgh, ijkl}
            //            The input ends when you receive the command “3:1”. At that point you must print the resulting elements, joined by a space.

            List<string> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (command[0] != "3:1")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    if (startIndex < 0 && (endIndex >= 0 && endIndex <= list.Count - 1))
                    {
                        startIndex = 0;
                    }
                    else if ((startIndex < 0 && endIndex < 0) || (startIndex > list.Count - 1 && endIndex > list.Count - 1))
                    {
                        command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                        continue;
                    }
                    else if (endIndex > list.Count - 1 && (startIndex >= 0 && startIndex <= list.Count - 1))
                    {
                        endIndex = list.Count - 1;
                    }
                    else if (startIndex < 0 && endIndex > list.Count - 1)
                    {
                        startIndex = 0;
                        endIndex = list.Count - 1;
                    }

                    string result = string.Empty;

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        result += list[i];
                    }

                    list.RemoveRange(startIndex, (endIndex - startIndex) + 1);

                    list.Insert(startIndex, result);


                }
                else if (command[0] == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);
                    List<string> dividedResult = new List<string>();

                    if (list[index].Length % partitions == 0 &&
                        partitions > 1 && 
                        partitions <= list[index].Length)
                    {
                        int dividedElementLenght = list[index].Length / partitions;
                        string currentElement = string.Empty;

                        for (int i = 1; i <= list[index].Length; i++)
                        {
                            currentElement += list[index][i - 1];

                            if (i % dividedElementLenght == 0)
                            {
                                dividedResult.Add(currentElement);
                                currentElement = string.Empty;
                            }
                        }

                        list.RemoveAt(index);
                        list.InsertRange(index, dividedResult);

                    }
                    else if (list[index].Length % partitions != 0 && 
                                partitions > 1 && 
                                partitions <= list[index].Length)
                    {
                        int dividedElementLenght = list[index].Length / partitions;
                        string currentElement = string.Empty;
                        int partitionsCount = 0;

                        for (int i = 1; i <= list[index].Length; i++)
                        {
                            if (partitionsCount == partitions - 1)
                            {
                                for (int j = i; j <= list[index].Length; j++)
                                {
                                    currentElement += list[index][j - 1];
                                }

                                dividedResult.Add(currentElement);
                                break;
                            }

                            currentElement += list[index][i - 1];

                            if (i % dividedElementLenght == 0)
                            {
                                dividedResult.Add(currentElement);
                                currentElement = string.Empty;
                                partitionsCount++;
                            }
                        }

                        list.RemoveAt(index);
                        list.InsertRange(index, dividedResult);
                    }

                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            }

            Console.WriteLine(string.Join(" ", list));

        }
    }
}
