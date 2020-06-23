using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string[] bombInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombInput.Length; i++)
            {
                int[] coordinates = bombInput[i]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int row = coordinates[0];
                int col = coordinates[1];
                int value = matrix[row, col];

                //lower row
                if (value <= 0)
                {
                    continue;
                }
                if (0 <= row - 1)
                {
                    if (0 <= col - 1 && matrix[row - 1, col - 1] > 0)
                    {
                        matrix[row - 1, col - 1] -= value;
                    }

                    if (matrix[row - 1, col] > 0)
                    {
                        matrix[row - 1, col] -= value;
                    }

                    if (col + 1 < size && matrix[row - 1, col + 1] > 0)
                    {
                        matrix[row - 1, col + 1] -= value;
                    }
                }

                //bomb row
                if (0 <= col - 1 && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= value;
                }

                if (col + 1 < size && matrix[row, col + 1] > 0)
                {
                    matrix[row, col + 1] -= value;
                }

                //upper row
                if (row + 1 < size)
                {
                    if (0 <= col - 1 && matrix[row + 1, col - 1] > 0)
                    {
                        matrix[row + 1, col - 1] -= value;
                    }

                    if (matrix[row + 1, col] > 0)
                    {
                        matrix[row + 1, col] -= value;
                    }

                    if (col + 1 < size && matrix[row + 1, col + 1] > 0)
                    {
                        matrix[row + 1, col + 1] -= value;
                    }
                }

                matrix[row, col] = 0;

            }

            int sum = 0;
            int count = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
