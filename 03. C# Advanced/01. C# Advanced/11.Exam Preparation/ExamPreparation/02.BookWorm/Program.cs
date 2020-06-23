using System;

namespace _02.BookWorm
{
    public class Program
    {
        static void Main()
        {
            string initialString = Console.ReadLine();

            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < size; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = line[j];
                    if (line[j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                    }
                }

            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                int prevPlayerRow = playerRow;
                int prevPlayerCol = playerCol;
                switch (command)
                {
                    case "up":
                        playerRow--;
                        if (isOutSide(playerRow, playerCol, size))
                        {
                            initialString = RemoveLastCharIfExist(initialString);
                            playerRow++;
                        }
                        else
                        {
                            initialString = ConsumePosition(matrix[playerRow, playerCol], initialString);
                            matrix[prevPlayerRow, prevPlayerCol] = '-';
                            matrix[playerRow, playerCol] = 'P';
                        }
                        break;

                    case "down":
                        playerRow++;
                        if (isOutSide(playerRow, playerCol, size))
                        {
                            initialString = RemoveLastCharIfExist(initialString);
                            playerRow--;
                        }
                        else
                        {
                            initialString = ConsumePosition(matrix[playerRow, playerCol], initialString);
                            matrix[prevPlayerRow, prevPlayerCol] = '-';
                            matrix[playerRow, playerCol] = 'P';
                        }
                        break;

                    case "left":
                        playerCol--;
                        if (isOutSide(playerRow, playerCol, size))
                        {
                            initialString = RemoveLastCharIfExist(initialString);
                            playerCol++;
                        }
                        else
                        {
                            initialString = ConsumePosition(matrix[playerRow, playerCol], initialString);
                            matrix[prevPlayerRow, prevPlayerCol] = '-';
                            matrix[playerRow, playerCol] = 'P';
                        }
                        break;

                    case "right":
                        playerCol++;
                        if (isOutSide(playerRow, playerCol, size))
                        {
                            initialString = RemoveLastCharIfExist(initialString);
                            playerCol--;
                        }
                        else
                        {
                            initialString = ConsumePosition(matrix[playerRow, playerCol], initialString);
                            matrix[prevPlayerRow, prevPlayerCol] = '-';
                            matrix[playerRow, playerCol] = 'P';
                        }
                        break;

                    default:
                        break;
                }



            }

            Console.WriteLine(initialString);
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
        private static bool isOutSide(int playerRow, int playerCol, int size)
        {
            if (playerRow < 0 || playerRow >= size ||
                playerCol < 0 || playerCol >= size)
            {
                return true;

            }
            return false;
        }
        private static string RemoveLastCharIfExist(string initialString)
        {
            string result = string.Empty;
            if (initialString.Length > 0)
            {
                result = initialString.Substring(0, initialString.Length - 1);
            }
            return result;
        }

        private static string ConsumePosition(char value, string initialString)
        {
            if (value != '-')
            {
                initialString += value;
            }
            return initialString;

        }
    }
}
