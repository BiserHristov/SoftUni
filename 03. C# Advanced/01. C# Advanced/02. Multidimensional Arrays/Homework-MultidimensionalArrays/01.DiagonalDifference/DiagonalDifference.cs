using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main()
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

            int leftDiagonalSum = 0;
            int curRow = 0;
            int curCol = 0;
            for (int i = 0; i < size; i++)
            {
                leftDiagonalSum += matrix[curRow, curCol];
                curRow++;
                curCol++;
            }

            int rightDiagonalSum = 0;
            curRow = 0;
            curCol = size - 1;

            for (int i = size - 1; i >= 0; i--)
            {
                rightDiagonalSum += matrix[curRow, curCol];
                curRow++;
                curCol--;
            }

            Console.WriteLine(Math.Abs(leftDiagonalSum-rightDiagonalSum));
        }
    }
}
