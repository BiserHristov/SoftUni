using System;
using System.Drawing;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class RadioactiveMutantVampireBunnies
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int playerRow = -1;
            int playerCol = -1;

            char[,] matrix = new char[rows, cols];


            for (int row = 0; row < rows; row++)
            {
                char[] values = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {

                    if (values[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                    matrix[row, col] = values[col];
                }
            }


            char[] commands = Console.ReadLine().ToCharArray();
            char bunny = 'B';
            char freeSpace = '.';
            char player = 'P';
            bool won = false;
            bool dead = false;
            char[,] newArr = new char[rows, cols];
            Array.Copy(matrix, newArr, matrix.Length);
            int nextRow = playerRow;
            int nextCol = playerCol;

            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];
                

                if (command == 'U')
                {
                    nextRow--;

                }
                else if (command == 'D')
                {
                    nextRow++;
                }
                else if (command == 'L')
                {
                    nextCol--;
                }
                else if (command == 'R')
                {
                    nextCol++;
                }
                newArr[playerRow, playerCol] = freeSpace;
                //won
                if (nextRow < 0 || nextRow >= rows ||
                    nextCol < 0 || nextCol >= cols)
                {
                    won = true;

                }
                else
                {
                    //freespace
                    if (matrix[nextRow, nextCol] == freeSpace)
                    {
                        newArr[nextRow, nextCol] = player;
                    }
                    //bunny
                    else
                    {
                        playerRow = nextRow;
                        playerCol = nextCol;
                        dead = true;
                    }
                }
                

                //PrintMatrix(newArr);
                //Console.WriteLine();
                //bunny explosion
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == bunny)
                        {
                            //UP
                            if (0 <= row - 1)
                            {
                                if (matrix[row - 1, col] == freeSpace)
                                {
                                    newArr[row - 1, col] = bunny;
                                }
                                else if (matrix[row - 1, col] == player)
                                {
                                    newArr[row - 1, col] = bunny;
                                    dead = true;
                                }

                            }
                            //down
                            if (row + 1 < rows)
                            {
                                if (matrix[row + 1, col] == freeSpace)
                                {
                                    newArr[row + 1, col] = bunny;
                                }
                                else if (matrix[row + 1, col] == player)
                                {
                                    newArr[row + 1, col] = bunny;
                                    dead = true;
                                }
                            }
                            //left
                            if (0 <= col - 1)
                            {
                                if (matrix[row, col - 1] == freeSpace)
                                {
                                    newArr[row, col - 1] = bunny;
                                }
                                else if (matrix[row, col - 1] == player)
                                {
                                    newArr[row, col - 1] = bunny;
                                    dead = true;
                                }
                            }
                            //right
                            if (col + 1 < cols)
                            {
                                if (matrix[row, col + 1] == freeSpace)
                                {
                                    newArr[row, col + 1] = bunny;
                                }
                                else if (matrix[row, col + 1] == player)
                                {
                                    newArr[row, col + 1] = bunny;
                                    dead = true;
                                }
                            }

                            //PrintMatrix(newArr);

                            //Console.WriteLine();

                        }
                    }
                }

                if (won)
                {
                    PrintMatrix(newArr);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }
                else if (dead)
                {
                    PrintMatrix(newArr);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
               
                 Array.Copy(newArr, matrix, matrix.Length);
                playerRow = nextRow;
                playerCol = nextCol;
            }





        }
        public static void PrintMatrix(char[,] matrix)
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
