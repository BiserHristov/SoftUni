using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._ParallelMergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 9, 4, 6, 2, 0, 5, 8, 1 };

            Divide(numbers);
        }

        static void Divide(List<int> nums)
        {
            int middleIndex = nums.Count / 2;

            var leftList = nums.Take(middleIndex).ToList();
            var righList = nums.Skip(middleIndex).Take(nums.Count - middleIndex + 1).ToList();

            if (leftList.Count != 1)
            {
                Divide(leftList);
                Divide(righList);
            }

            var sortedList = SortList(leftList, righList);
        }

        static List<int> SortList(List<int> first, List<int> second)
        {
            var sortedList = new List<int>();

            //Check if they have different lenths

            while (first.Count > 0 || second.Count > 0)
            {
                if (first.Count == 0)
                {
                    sortedList.AddRange(second);
                    second.Clear();
                    continue;

                }

                if (second.Count == 0)
                {
                    sortedList.AddRange(first);
                    first.Clear();
                    continue;
                }


                if (first[0] < second[0])
                {
                    sortedList.Add(first[0]);
                    first.RemoveAt(0);
                }
                else
                {
                    sortedList.Add(second[0]);
                    second.RemoveAt(0);

                }
            }

            return sortedList;
        }

    }



}
