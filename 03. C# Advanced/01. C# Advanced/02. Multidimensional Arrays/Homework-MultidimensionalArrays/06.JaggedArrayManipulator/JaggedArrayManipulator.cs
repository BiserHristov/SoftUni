using System;

namespace _06.JaggedArrayManipulator
{
    class JaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            double[][] jagged = new double[size][];

            for (int row = 0; row < size; row++)
            {
                string[] inputNumbers = Console.ReadLine().Split(' ');
                jagged[row] = new double[inputNumbers.Length];

                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = double.Parse(inputNumbers[col]);
                }
            }

            for (int i = 0; i < size - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int j = i; j <= i + 1; j++)
                    {
                        for (int k = 0; k < jagged[i].Length; k++)
                        {
                            jagged[j][k] *= 2;
                        }

                    }
                }
                else
                {
                    for (int j = i; j <= i + 1; j++)
                    {
                        for (int k = 0; k < jagged[j].Length; k++)
                        {
                            jagged[j][k] /= 2;
                        }

                    }
                }
            }
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "End")
            {
                //int too small????
                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                double value = double.Parse(input[3]);

                if (0 <= row && row < size &&
                    0 <= col && col < jagged[row].Length)
                {
                    if (command == "Add")
                    {
                        jagged[row][col] += value;

                    }
                    else if (command == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }

                }

                input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            }

            foreach (double[] row in jagged)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
