using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClubParty
{
    public class Program
    {
        static void Main(string[] args)
        {

            int capacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);



            Queue<string> halls = new Queue<string>();
            List<int> people = new List<int>();

            StringBuilder sb = new StringBuilder();
            int sum = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {

                bool isNumber = int.TryParse(input[i], out int currentPeople);

                if (isNumber)
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }


                    if (sum + currentPeople > capacity)
                    {
                        sb.AppendLine($"{halls.Dequeue()} -> {string.Join(", ", people)}");
                        sum = 0;
                        people.Clear();



                    }

                    if (halls.Count > 0)
                    {

                        people.Add(currentPeople);
                        sum += currentPeople;
                    }


                }
                else
                {
                    halls.Enqueue(input[i]);
                }
            }


            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
