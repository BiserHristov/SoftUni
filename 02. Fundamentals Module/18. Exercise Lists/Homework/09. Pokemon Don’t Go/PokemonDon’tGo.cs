using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main()
        {

            //            Ely likes to play Pokemon Go a lot. But Pokemon Go bankrupted … So the developers made Pokemon Don’t Go out of depression. And so Ely now plays Pokemon Don’t Go. In Pokemon Don’t Go, when you walk to a certain pokemon, those closer to you, naturally get further, and those further from you, get closer.
            //You will receive a sequence of integers, separated by spaces – the distances to the pokemons.Then you will begin receiving integers, which will correspond to indexes in that sequence.
            //When you receive an index, you must remove the element at that index from the sequence (as if you’ve captured the pokemon).
            //•	You must increase the value of all elements in the sequence, which are less or equal to the removed element, with the value of the removed element.
            //•	You must decrease the value of all elements in the sequence, which are greater than the removed element, with the value of the removed element.
            //If the given index is less than 0, remove the first element of the sequence, and copy the last element to its place.
            //If the given index is greater than the last index of the sequence, remove the last element from the sequence, and copy the first element to its place.
            //The increasing and decreasing of elements should be done in these cases, also. The element, whose value you should use is the removed element.
            //The program ends when the sequence has no elements(there are no pokemons left for Ely to catch).

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int index = int.Parse(Console.ReadLine());
            int sum = 0;

            while (list.Count > 0)
            {
                List<int> updaetedList = new List<int>();
                int elementForRemove;

                if (index < 0)
                {
                    elementForRemove = list[0];
                    sum += elementForRemove;
                    list[0] = list[list.Count - 1];

                }
                else if (index > list.Count - 1)
                {
                    elementForRemove = list[list.Count - 1];
                    sum += elementForRemove;
                    list[list.Count - 1] = list[0];
                }
                else
                {
                    elementForRemove = list[index];
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (i == index)
                    {
                        sum += elementForRemove;
                        continue;
                    }
                    int currentElement = list[i];

                    if (currentElement <= elementForRemove)
                    {
                        updaetedList.Add(currentElement + elementForRemove);
                    }
                    else if (currentElement > elementForRemove)
                    {
                        updaetedList.Add(currentElement - elementForRemove);
                    }
                }
                list = updaetedList;

                if (list.Count > 0)
                {
                    index = int.Parse(Console.ReadLine());
                }

            }

            Console.WriteLine(sum);
        }
    }
}
