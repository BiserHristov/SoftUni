using System;

namespace _07.KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int counter = 0;
            int maxCount = 0;
            int maxRow = -1;
            int maxCol = -1;
            int removedElements = 0;

            while (true)
            {
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == '0')
                        {
                            continue;
                        }
                        //down left
                        if (row + 1 < size)
                        {
                            if (0 <= col - 2)
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                        }

                        if (row + 2 < size)
                        {
                            if (0 <= col - 1)
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                        }

                        //down right
                        if (row + 1 < size)
                        {
                            if (col + 2 < size)
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                        }

                        if (row + 2 < size)
                        {
                            if (col + 1 < size)
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                        }

                        //up left
                        if (0 <= row - 1)
                        {
                            if (0 <= col - 2)
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                        }

                        if (0 <= row - 2)
                        {
                            if (0 <= col - 1)
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                        }

                        //up right
                        if (0 <= row - 1)
                        {
                            if (col + 2 < size)
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    counter++;
                                }
                            }
                        }

                        if (0 <= row - 2)
                        {
                            if (col + 1 < size)
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    counter++;
                                }
                            }
                        }

                        if (counter > maxCount)
                        {
                            maxCount = counter;
                            maxRow = row;
                            maxCol = col;

                        }
                        counter = 0;

                    }
                }

                if (maxCount != 0)
                {
                    matrix[maxRow, maxCol] = '0';
                    removedElements++;
                    maxCount = 0;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(removedElements);

        }
    }
}
