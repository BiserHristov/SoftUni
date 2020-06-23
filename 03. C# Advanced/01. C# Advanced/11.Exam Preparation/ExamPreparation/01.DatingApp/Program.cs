using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.DatingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> male = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> female = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int matches = 0;

            while (male.Count > 0 && female.Count > 0)
            {
                int currentMale = male.Peek();
                int currentFemale = female.Peek();

                if (currentFemale <= 0)
                {
                    female.Dequeue();
                    continue;
                }

                if (currentMale <= 0)
                {
                    male.Pop();
                    continue;
                }

                if (currentFemale % 25 == 0)
                {

                    female.Dequeue();
                    female.Dequeue();
                    continue;
                }

                if (currentMale % 25 == 0)
                {

                    male.Pop();
                    male.Pop();
                    continue;
                }

                if (currentFemale == currentMale)
                {
                    matches++;
                    male.Pop();
                    female.Dequeue();
                }
                else
                {
                    int value = male.Peek();
                    male.Pop();
                    male.Push(value - 2);

                    female.Dequeue();
                }

            }

            List<int> maleList = male.ToList();

            if (male.Count > 0)
            {
                for (int i = 0; i < maleList.Count; i++)
                {
                    if (maleList[i] % 25 == 0)
                    {
                        maleList.RemoveRange(i, 2);
                        i -= 2;
                    }

                }
            }


            List<int> femaleList = female.ToList();

            if (femaleList.Count > 0)
            {
                for (int i = 0; i < femaleList.Count; i++)
                {
                    if (femaleList[i] % 25 == 0)
                    {
                        femaleList.RemoveRange(i, 2);
                        i -= 2;
                    }

                }
            }


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Matches: {matches}");
            sb.AppendLine("Males left: " + (maleList.Count > 0 ? string.Join(", ", maleList) : "none"));
            sb.AppendLine("Females left: " + (femaleList.Count > 0 ? string.Join(", ", femaleList) : "none"));
            Console.WriteLine(sb.ToString().Trim());

        }
    }
}
