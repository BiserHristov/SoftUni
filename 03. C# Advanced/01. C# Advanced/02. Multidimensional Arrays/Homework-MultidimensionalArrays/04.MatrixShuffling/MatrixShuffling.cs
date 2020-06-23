using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = ReadStringMatrix();

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "END")
            {
                if (input[0] != "swap" || input.Length != 5)
                {
                    Console.WriteLine("Invalid input!");

                    input = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();
                    continue;
                }

                bool isInside = true;
                int result;

                for (int i = 1; i < input.Length; i++)
                {
                    bool isDigit = int.TryParse(input[i], out result);
                   
                    if (i % 2 == 0 && (result < 0 || result > matrix.GetLength(1)))
                    {
                        isInside = false;
                    }
                    else if (i % 2 != 0 && (result < 0 || result > matrix.GetLength(0)))
                    {
                        isInside = false;
                    }

                    if (!isDigit || !isInside)
                    {
                        break;
                    }

                }

                if (!isInside)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine()
                             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                             .ToArray();
                    continue;
                }

                int firstRow = int.Parse(input[1]);
                int firstCol = int.Parse(input[2]);
                int secondRow = int.Parse(input[3]);
                int secondCol = int.Parse(input[4]);

                string temp = matrix[firstRow, firstCol];
                matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                matrix[secondRow, secondCol] = temp;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }
                    Console.WriteLine();
                }


                input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

        }

        public static string[,] ReadStringMatrix()
        {

            int[] input = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            return matrix;
        }
    }
}
