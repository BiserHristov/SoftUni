using System;
using System.Runtime.CompilerServices;

namespace _02.TronRacers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int fRow = -1;
            int fCol = -1;

            int sRow = -1;
            int sCol = -1;

            for (int i = 0; i < size; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = line[j];
                    if (line[j] == 'f')
                    {
                        fRow = i;
                        fCol = j;
                    }
                    else if (line[j] == 's')
                    {
                        sRow = i;
                        sCol = j;
                    }
                }
            }

           

            while (true)
            {
                string[] directions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstPlayerMove = directions[0];
                string secondPlayerMove = directions[1];

                GetNewLocation(firstPlayerMove, ref fRow, ref fCol, size);
                GetNewLocation(secondPlayerMove, ref sRow, ref sCol, size);

                if (!MovePlayerIfPossible(matrix, fRow, fCol, 'f') ||
                    !MovePlayerIfPossible(matrix, sRow, sCol, 's'))
                {
                    break;
                }
            }
            PrintMatrix(matrix);

        }
        private static bool MovePlayerIfPossible(char[,] matrix, int row, int col, char playerSymbol)
        {
            if (matrix[row, col] != playerSymbol && matrix[row, col] != '*')
            {

                matrix[row, col] = 'x';
                return false;
            }
            else
            {
                matrix[row, col] = playerSymbol;
                return true;
            }

        }

        private static void GetNewLocation(string move, ref int row, ref int col, int size)
        {
            switch (move)
            {
                case "up":
                    row--;
                    if (row < 0)
                    {
                        row = size - 1;
                    }

                    break;

                case "down":
                    row++;
                    if (row == size)
                    {
                        row = 0;
                    }
                    break;

                case "left":
                    col--;
                    if (col < 0)
                    {
                        col = size - 1;
                    }
                    break;

                case "right":
                    col++;
                    if (col == size)
                    {
                        col = 0;
                    }
                    break;

            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }

    }
}
