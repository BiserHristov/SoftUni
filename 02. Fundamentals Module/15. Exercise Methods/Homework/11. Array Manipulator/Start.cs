using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Start
    {
        static void Main(string[] args)
        {
            //            Trifon has finally become a junior developer and has received his first task. It’s about manipulating an array of integers.He is not quite happy about it, since he hates manipulating arrays.They are going to pay him a lot of money, though, and he is willing to give somebody half of it if to help him do his job. You, on the other hand, love arrays(and money) so you decide to try your luck.
            //The array may be manipulated by one of the following commands
            //•	exchange { index} – splits the array after the given index, and exchanges the places of the two resulting sub - arrays.E.g. [1, 2, 3, 4, 5]->exchange 2->result: [4, 5, 1, 2, 3]
            //        o If the index is outside the boundaries of the array, print “Invalid index”
            //•	max even/odd– returns the INDEX of the max even/odd element -> [1, 4, 8, 2, 3] -> max odd -> print 4
            //•	min even/odd – returns the INDEX of the min even/odd element -> [1, 4, 8, 2, 3] -> min even > print 3
            //o If there are two or more equal min/max elements, return the index of the rightmost one
            //o If a min/max even/odd element cannot be found, print “No matches”
            //•	first {count
            //    }
            //    even/odd– returns the first {count
            //}
            //elements -> [1, 8, 2, 3] -> first 2 even -> print[8, 2]
            //•	last {count} even/odd – returns the last {count} elements -> [1, 8, 2, 3] -> last 2 odd -> print[1, 3]
            //o   If the count is greater than the array length, print “Invalid count”
            //o If there are not enough elements to satisfy the count, print as many as you can.If there are zero even/odd elements, print an empty array “[]”
            //•	end – stop taking input and print the final state of the array

            int[] array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string line = Console.ReadLine();
            string[] command = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "end")
            {

                switch (command[0])
                {
                    case "exchange":
                        int splitIndex = int.Parse(command[1]);

                        if (splitIndex < 0 || splitIndex > array.Length - 1)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else if (splitIndex >= 0 && splitIndex < array.Length - 1)
                        {
                            int[] result = ExchangeIndex(array, splitIndex);
                            array = result;
                        }

                        break;

                    case "max":
                        int maxIndex = MaxOddOrEvenIndex(array, command[1]);
                        if (maxIndex == -1)
                        {
                            Console.WriteLine("No matches");

                        }
                        else
                        {
                            Console.WriteLine(maxIndex);
                        }
                        break;

                    case "min":
                        int minIndex = MinOddOrEvenIndex(array, command[1]);
                        if (minIndex == -1)
                        {
                            Console.WriteLine("No matches");

                        }
                        else
                        {
                            Console.WriteLine(minIndex);
                        }
                        break;

                    case "first":
                        if (int.Parse(command[1]) > array.Length)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            int[] result = FirstNEvenOddElements(int.Parse(command[1]), array, command[2]);
                            if (result.Length == 0)
                            {
                                Console.WriteLine("[]");
                            }
                            else
                            {
                                Console.WriteLine('[' + string.Join(", ", result) + ']');
                            }
                        }
                        break;

                    case "last":
                        if (int.Parse(command[1]) > array.Length)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            int[] result = LastNEvenOddElements(int.Parse(command[1]), array, command[2]);
                            if (result.Length == 0)
                            {
                                Console.WriteLine("[]");
                            }
                            else
                            {
                                Console.WriteLine('[' + string.Join(", ", result) + ']');
                            }
                        }

                        break;

                    default:
                        break;
                }

                command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine('[' + string.Join(", ", array) + ']');

        }

        static int[] LastNEvenOddElements(int count, int[] arr, string typeNumber)
        {
            int[] tempArr = new int[arr.Length];
            for (int i = 0; i < tempArr.Length; i++)
            {
                tempArr[i] = arr[i];
            }
            Array.Reverse(tempArr);
            int[] result = FirstNEvenOddElements(count, tempArr, typeNumber);
            Array.Reverse(result);
            return result;
        }
        static int[] FirstNEvenOddElements(int count, int[] arr, string typeNumber)
        {
            string odd = string.Empty;
            string even = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    even += arr[i] + " ";
                }
                else
                {
                    odd += arr[i] + " ";

                }
            }

            int[] oddAsNumbers = odd.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] evenAsNumbers = even.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            if (typeNumber == "even" && count >= evenAsNumbers.Length)
            {
                return evenAsNumbers;
            }
            else if (typeNumber == "even" && count < evenAsNumbers.Length)
            {
                int[] result = new int[count];
                for (int i = 0; i < count; i++)
                {
                    result[i] = evenAsNumbers[i];
                }
                return result;
            }
            else if (typeNumber == "odd" && count >= oddAsNumbers.Length)
            {
                return oddAsNumbers;
            }

            //typeNumber == "odd" && count < oddAsNumbers.Length
            else
            {
                int[] result = new int[count];
                for (int i = 0; i < count; i++)
                {
                    result[i] = oddAsNumbers[i];
                }
                return result;
            }


        }

        static int MinOddOrEvenIndex(int[] arr, string typeNumber)
        {
            int minOdd = int.MaxValue;
            int minOddIndex = -1;
            int minEven = int.MaxValue;
            int minEvenIndex = -1;

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if ((arr[i] % 2 == 0 && arr[i] < minEven) ||
                    (arr[i] % 2 == 0 && arr[i] == minEven && i > minEvenIndex))
                {
                    minEven = arr[i];
                    minEvenIndex = i;
                }
                else if ((arr[i] % 2 != 0 && arr[i] < minOdd) ||
                         (arr[i] % 2 != 0 && arr[i] == minOdd && i > minOddIndex))
                {
                    minOdd = arr[i];
                    minOddIndex = i;
                }
            }

            if (typeNumber == "even")
            {
                return minEvenIndex;
            }
            else //typeNumber == "odd"
            {
                return minOddIndex;
            }
        }

        static int MaxOddOrEvenIndex(int[] arr, string typeNumber)
        {

            int maxOdd = int.MinValue;
            int maxOddIndex = -1;
            int maxEven = int.MinValue;
            int maxEvenIndex = -1;

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if ((arr[i] % 2 == 0 && arr[i] > maxEven) ||
                    (arr[i] % 2 == 0 && arr[i] == maxEven && i > maxEvenIndex))
                {
                    maxEven = arr[i];
                    maxEvenIndex = i;
                }
                else if ((arr[i] % 2 != 0 && arr[i] > maxOdd) ||
                        (arr[i] % 2 != 0 && arr[i] == maxOdd && i > maxOddIndex))
                {
                    maxOdd = arr[i];
                    maxOddIndex = i;
                }
            }

            if (typeNumber == "even")
            {
                return maxEvenIndex;
            }
            else //typeNumber == "odd"
            {
                return maxOddIndex;
            }
        }
        static int[] ExchangeIndex(int[] arr, int index)
        {
            int[] resultArray = new int[arr.Length];

            for (int i = index + 1; i <= arr.Length - 1; i++)
            {
                resultArray[i - index - 1] = arr[i];
            }
            int count = arr.Length - 1 - index;
            for (int i = 0; i <= index; i++)
            {
                resultArray[count + i] = arr[i];
            }


            return resultArray;
        }
    }
}
