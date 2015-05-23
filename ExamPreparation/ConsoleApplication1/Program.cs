using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_10_PlusRemove
{
    class PlusRemove
    {
        static void Main(string[] args)
        {
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
            char[,] result = new char[arr.Count, maxLenght.Length];
            for (int row = 0; row < arr.Count; row++)
            {
                string currString = arr[row];
                for (int col = 0; col < maxLenght.Length; col++)
                {
                    if (col < currString.Length)
                    {
                        exponat[row, col] = Char.ToUpper(currString[col]);
                        result[row, col] = currString[col];
                    }
                    else
                    {
                        exponat[row, col] = ' ';
                        result[row, col] = ' ';
                    }
                }
            }
            for (int row = 0; row < arr.Count - 2; row++)
            {
                for (int col = 1; col < maxLenght.Length - 1; col++)
                {
                    if (exponat[row, col] == exponat[row + 1, col] && exponat[row, col] == exponat[row + 2, col] && exponat[row, col] == exponat[row + 1, col - 1] && exponat[row, col] == exponat[row + 1, col + 1])
                    {
                        result[row, col] = ' ';
                        result[row + 1, col] = ' ';
                        result[row + 2, col] = ' ';
                        result[row + 1, col - 1] = ' ';
                        result[row + 1, col + 1] = ' ';
                    }
                }
            }
            Print(result, arr.Count, maxLenght.Length);

        }
        static void Print(Char[,] matrix, int rowLenght, int colLenght)
        {
            for (int row = 0; row < rowLenght; row++)
            {
                for (int col = 0; col < colLenght; col++)
                {
                    if (matrix[row, col] != ' ')
                    {
                        Console.Write(matrix[row, col]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
