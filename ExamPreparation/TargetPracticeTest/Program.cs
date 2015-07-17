using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetPracticeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string snake = Console.ReadLine();
            int[] shotParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            char[,] matrix=new char[dimensions[0],dimensions[1]];

            FillTheMatrix(matrix, snake);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (IsInsideTheCircle(row, col, shotParameters))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            DropCharacters(matrix);

            PrintMatrix(matrix);
        }

        private static void FillTheMatrix(char[,] matrix, string forFill)
        {
            int charCounter = 0;
            bool fillLeft = true;
            for (int row = matrix.GetLength(0)-1; row >= 0; row--)
            {
                if (fillLeft)
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (charCounter == forFill.Length)
                        {
                            charCounter = 0;
                        }
                        matrix[row, col] = forFill[charCounter];
                        charCounter++;
                    }
                    fillLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (charCounter == forFill.Length)
                        {
                            charCounter = 0;
                        }
                        matrix[row, col] = forFill[charCounter];
                        charCounter++;
                    }
                    fillLeft = true;
                }
            }
        }

        private static bool IsInsideTheCircle(int pointX, int pointY, int[] parameters)
        {
            int circleX = parameters[0];
            int circleY = parameters[1];
            int circleRadius = parameters[2];

            return (pointX - circleX) * (pointX - circleX) + (pointY - circleY) * (pointY - circleY)
                   <= circleRadius * circleRadius;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void DropCharacters(char[,] matrix)
        {

            for (int row = matrix.GetLength(0)-1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] != ' ')
                    {
                        continue;
                    }

                    int currentRow = row - 1;
                    while (currentRow >= 0)
                    {
                        if (matrix[currentRow,col] != ' ')
                        {
                            matrix[row,col] = matrix[currentRow,col];
                            matrix[currentRow,col] = ' ';
                            break;
                        }

                        currentRow--;
                    }
                }
            }
        }
    }
}
