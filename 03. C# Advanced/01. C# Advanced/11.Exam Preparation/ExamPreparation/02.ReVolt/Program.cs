using System;

namespace _02.ReVolt
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int comandsCnt = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int playerRow = -1;
            int playerCol = -1;


            for (int i = 0; i < size; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = line[j];
                    if (line[j] == 'f')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }
            }

            bool won = false;
            int prevRow = -1;
            int prevCol = -1;

            for (int i = 0; i < comandsCnt; i++)
            {
                string direction = Console.ReadLine();
                prevRow = playerRow;
                prevCol = playerCol;

                GetNewLocation(direction, ref playerRow, ref playerCol, size);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    matrix[prevRow, prevCol] = '-';
                    prevRow = playerRow;
                    prevCol = playerCol;

                    GetNewLocation(direction, ref playerRow, ref playerCol, size);

                    if (hasWon(matrix, playerRow, playerCol))
                    {
                        matrix[playerRow, playerCol] = 'f';
                        won = true;
                        break;
                    }
                    matrix[playerRow, playerCol] = 'f';
                }
                else if (matrix[playerRow, playerCol] == 'T')
                {
                    playerRow = prevRow;
                    playerCol = prevCol;
                }
                else if (hasWon(matrix, playerRow, playerCol))
                {
                    matrix[playerRow, playerCol] = 'f';
                    matrix[prevRow, prevCol] = '-';
                    won = true;
                    break;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'f';
                    matrix[prevRow, prevCol] = '-';
                }

               
            }

            if (won)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");

            }

            PrintMatrix(matrix);
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
        public static bool hasWon(char[,] matrix, int row, int col) => matrix[row, col] == 'F';

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

    }
}
