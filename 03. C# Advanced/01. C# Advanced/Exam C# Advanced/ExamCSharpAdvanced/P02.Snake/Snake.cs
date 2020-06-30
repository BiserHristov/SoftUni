using System;

namespace P02.Snake
{
    class Snake
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int snakeRow = -1;
            int snakeCol = -1;

            int firstBurrowRow = -1;
            int firstBurrowCol = -1;
            bool firstBurrowFilled = false;

            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            for (int i = 0; i < size; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = line[j];
                    if (line[j] == 'S')
                    {
                        snakeRow = i;
                        snakeCol = j;
                    }

                    if (line[j] == 'B')
                    {
                        if (!firstBurrowFilled)
                        {
                            firstBurrowRow = i;
                            firstBurrowCol = j;
                            firstBurrowFilled = true;
                        }
                        else
                        {
                            secondBurrowRow = i;
                            secondBurrowCol = j;
                        }

                    }
                }

            }

            int foodCount = 0;
            bool snakeEscaped = false;

            while (true)
            {


                string direction = Console.ReadLine();
                int prevSnakeRow = snakeRow;
                int prevSnakeCol = snakeCol;
                GetNewLocation(direction, ref snakeRow, ref snakeCol, size);
                if (isOutSide(snakeRow, snakeCol, size))
                {
                    matrix[prevSnakeRow, prevSnakeCol] = '.';
                    snakeEscaped = true;
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodCount++;
                    matrix[prevSnakeRow, prevSnakeCol] = '.';
                    prevSnakeRow = snakeRow;
                    prevSnakeCol = snakeCol;
                    matrix[snakeRow, snakeCol] = 'S';
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[prevSnakeRow, prevSnakeCol] = '.';
                    prevSnakeRow = snakeRow;
                    prevSnakeCol = snakeCol;

                    if (snakeRow == firstBurrowRow &&
                        snakeCol == firstBurrowCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;


                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                    matrix[prevSnakeRow, prevSnakeCol] = '.';
                    prevSnakeRow = snakeRow;
                    prevSnakeCol = snakeCol;
                    matrix[snakeRow, snakeCol] = 'S';

                }
                else
                {
                    matrix[prevSnakeRow, prevSnakeCol] = '.';
                    prevSnakeRow = snakeRow;
                    prevSnakeCol = snakeCol;
                    matrix[snakeRow, snakeCol] = 'S';
                }

                if (foodCount >= 10)
                {
                    break;
                }


            }

            if (snakeEscaped)
            {
                Console.WriteLine("Game over!");
            }
            else if (foodCount >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodCount}");
            PrintMatrix(matrix);


        }
        private static void GetNewLocation(string move, ref int row, ref int col, int size)
        {
            switch (move)
            {
                case "up":
                    row--;

                    break;

                case "down":
                    row++;

                    break;

                case "left":
                    col--;

                    break;

                case "right":
                    col++;

                    break;

            }
        }
        private static bool isOutSide(int row, int col, int size)
        {
            if (row < 0 || row >= size ||
                col < 0 || col >= size)
            {
                return true;

            }
            return false;
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
