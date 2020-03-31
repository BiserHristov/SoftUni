using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Start
    {
        /// <summary>
        /// The clone factory in Kamino got another order to clone troops. But this time you are tasked to find the best DNA sequence to use in the production. 
        ///  You will receive the DNA length and until you receive the command "Clone them!" you will be receiving a DNA sequences of ones and zeroes, split by "!" (one or several).
        ///  You should select the sequence with the longest subsequence of ones.If there are several sequences with same length of subsequence of ones, print the one with the leftmost starting index, if there are several sequences with same length and starting index, select the sequence with the greater sum of its elements.
        ///  After you receive the last command "Clone them!" you should print the collected information in the following format:
        ///  "Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
        ///  "{DNA sequence, joined by space}"
        /// </summary>
        static void Main()
        {

            int dimension = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            int[] array = line.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] bestArrray = new int[array.Length];
            int bestCount = -1;
            int bestStartIndex = -1;

            int currentStartIndex = int.MaxValue;
            int currentSample = 0;
            int bestSample = -1;

            while (line != "Clone them!")
            {

                int[] arr = line.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


                int currentCount = 0;
                int currentBestCount = 0;
                int currentBestStartIndex = int.MaxValue;
                currentSample++;

                for (int i = 0; i < arr.Length; i++)
                {
                    currentCount = 0;
                    int element = arr[i];
                    if (element == 0)
                    {
                        continue;
                    }
                    currentCount++;
                    currentStartIndex = i;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] == 1)
                        {
                            currentCount++;
                        }
                        else
                        {
                            break;
                        }

                    }

                    if (currentCount > currentBestCount ||
                       (currentCount == currentBestCount && currentStartIndex < currentBestStartIndex))
                    {
                        currentBestCount = currentCount;
                        currentBestStartIndex = currentStartIndex;
                    }

                }

                if (currentBestCount > bestCount ||
                   (currentBestCount == bestCount && currentBestStartIndex < bestStartIndex) ||
                   (currentBestCount == bestCount && currentBestStartIndex == bestStartIndex && arr.Sum() > bestArrray.Sum()))
                {
                    bestStartIndex = currentBestStartIndex;
                    bestCount = currentBestCount;
                    bestSample = currentSample;


                    for (int i = 0; i < bestArrray.Length; i++)
                    {
                        bestArrray[i] = arr[i];

                    }
                }

                line = Console.ReadLine();

            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestArrray.Sum()}.");
            Console.WriteLine(string.Join(" ", bestArrray));
        }
    }
}
