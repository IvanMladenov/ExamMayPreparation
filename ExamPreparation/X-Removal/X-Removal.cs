using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Removal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char[]> exponat = new List<char[]>();
            List<char[]> matrix = new List<char[]>();
            string input = Console.ReadLine();

            while (!input.Contains("END"))
            {
                exponat.Add(input.ToLower().ToCharArray());
                matrix.Add(input.ToCharArray());
                input = Console.ReadLine();
            }

            for (int row = 0; row < exponat.Count - 2; row++)
            {
                for (int col = 0; col < exponat[row].Length - 2; col++)
                {
                    if (IsAtRange(exponat, row, col) && IsAtRange(exponat, row, col + 2) && IsAtRange(exponat, row + 1, col + 1) && IsAtRange(exponat, row + 2, col) && IsAtRange(exponat, row + 2, col + 2))
                    {
                        StringBuilder model = new StringBuilder(), curent = new StringBuilder();
                        model.Append(exponat[row][col], 5);
                        curent.Append((char)exponat[row][col]);
                        curent.Append((char)exponat[row][col + 2]);
                        curent.Append((char)exponat[row + 1][col + 1]);
                        curent.Append((char)exponat[row + 2][col]);
                        curent.Append((char)exponat[row + 2][col + 2]);
                        if (model.ToString() == curent.ToString())
                        {
                            matrix[row][col] = ' ';
                            matrix[row][col + 2] = ' ';
                            matrix[row + 1][col + 1] = ' ';
                            matrix[row + 2][col] = ' ';
                            matrix[row + 2][col + 2] = ' ';
                        }
                    }
                }
            }
            MatrixPrint(matrix);
        }
        static void MatrixPrint(List<char[]> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        Console.Write(matrix[row][col]);
                    }
                }
                Console.WriteLine();
            }
        }
        static bool IsAtRange(List<char[]> model, int row, int col)
        {
            if (row >= 0 && row < model.Count)
            {
                if (col < model[row].Length && col >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
