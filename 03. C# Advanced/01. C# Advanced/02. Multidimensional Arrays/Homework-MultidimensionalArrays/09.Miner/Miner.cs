using System;
using System.Linq;

namespace _09.Miner
{
    class Miner
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size, size];
            int totalCoals = 0;
            int currentRow = -1;
            int currentCol = -1;

            for (int row = 0; row < size; row++)
            {
                char[] values = Console.ReadLine()
                    .Replace(" ", "")
                    .ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    if (values[col] == 'c')
                    {
                        totalCoals++;
                    }
                    else if (values[col] == 's')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                    matrix[row, col] = values[col];
                }
            }


            int foundCoals = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];

                if (command == "left")
                {
                    if (0 <= currentCol - 1)
                    {
                        currentCol--;
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (command == "right")
                {
                    if (currentCol + 1 < size)
                    {
                        currentCol++;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "up")
                {
                    if (0 <= currentRow - 1)
                    {
                        currentRow--;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (command == "down")
                {
                    if (currentRow + 1 < size)
                    {
                        currentRow++;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (matrix[currentRow,currentCol]=='e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }
                else if (matrix[currentRow, currentCol] == 'c')
                {
                    foundCoals++;
                    if (foundCoals==totalCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                    matrix[currentRow, currentCol] = '*';
                }
            }

            Console.WriteLine($"{totalCoals-foundCoals} coals left. ({currentRow}, {currentCol})");
        }
    }
}
