using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_11_StringMRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> arr = new List<string> { };
            string input = Console.ReadLine();
            string maxLenght = string.Empty;

            while (!input.Contains("END"))
            {
                arr.Add(input);
                if (input.Length > maxLenght.Length)
                {
                    maxLenght = input;
                }
                input = Console.ReadLine();
            }

            char[,] exponat = new char[arr.Count, maxLenght.Length];
            for (int row = 0; row < arr.Count; row++)
            {
                for (int col = 0; col < maxLenght.Length; col++)
                {
                    string currString = arr[row];
                    if (col < currString.Length)
                    {
                        exponat[row, col] = currString[col];
                    }
                    else
                    {
                        exponat[row, col] = ' ';
                    }
                }
            }
            string[] arrComm = command.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int degrees = int.Parse(arrComm[1]);
            double iterations = degrees * 2 / 180;
            //char[,] rotated;
            for (int i = 0; i < iterations; i++)
            {
                exponat = Rotate(exponat);
            }
            Print(exponat);



        }
        static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static char[,] Rotate(char[,] matrix)
        {
            char[,] rotated = new char[matrix.GetLength(1), matrix.GetLength(0)];

            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    rotated[row, col] = matrix[matrix.GetLength(0) - col - 1, row];
                }
            }
            return rotated;
        }
    }
}
