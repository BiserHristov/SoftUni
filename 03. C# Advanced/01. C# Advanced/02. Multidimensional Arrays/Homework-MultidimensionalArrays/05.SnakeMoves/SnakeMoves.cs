using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class SnakeMoves
    {
        public static object Quene { get; private set; }

        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];

            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 != 0)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        char currentElement = snake.Dequeue();
                        snake.Enqueue(currentElement);
                        matrix[row, col] = currentElement;
                    }
                    continue;
                }
                for (int col = 0; col < cols; col++)
                {
                    char currentElement = snake.Dequeue();
                    snake.Enqueue(currentElement);
                    matrix[row, col] = currentElement;

                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
