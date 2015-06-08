using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RowAndCol = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            string snake = Console.ReadLine();
            int[] shot = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            char[,] matrix = new char[RowAndCol[0], RowAndCol[1]];

            for (int row = RowAndCol[0] - 1, counter = 0; row >= 0; row --)
            {
                if (row % 2 == 0)
                {
                    for (int col = RowAndCol[1] - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[counter];
                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = 0; col < RowAndCol[1]; col++)
                    {
                        matrix[row , col] = snake[counter];
                        counter++;
                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(IsInside(row,col,shot))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            for (int row = matrix.GetLength(0) - 2; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix = Exchange(matrix, row, col);
                }
            }

            Print(matrix);

        }

        static char[,] Exchange(char[,] matrix, int currentRow, int currentCol)
        {
            if (matrix[currentRow + 1, currentCol] == ' ')
            {
                while (true)
                {
                    matrix[currentRow + 1, currentCol] = matrix[currentRow, currentCol];
                    matrix[currentRow, currentCol] = ' ';
                    currentRow++;
                    if (currentRow + 1 >= matrix.GetLength(0) || matrix[currentRow + 1, currentCol] != ' ')
                    {
                        break;
                    }
                }
                
            }
            return matrix;
        }

        static void Print(char[,]arr)
        {
            for (int row = 0; row < arr.GetLength(0); row++)
			{
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write(arr[row, col]);
                }
                Console.WriteLine();
			}
        }

        static bool IsInside(int pointX, int pointY, int[]centerAndRadius)
        {
            int centerX=centerAndRadius[0];
            int centerY=centerAndRadius[1];
            int radius = centerAndRadius[2];

            bool isInCircle = (pointX - centerX) * (pointX - centerX) + (pointY - centerY) * (pointY - centerY) <= radius * radius;
            return isInCircle;
        }
    }
}
