using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TextGravity
{
    class TextGravity
    {
        static void Main(string[] args)
        {
            int matrixCols = int.Parse(Console.ReadLine());
            string sentence = Console.ReadLine();

            int matrixRows;
            if(sentence.Length%matrixCols==0)
            {
                matrixRows = sentence.Length / matrixCols;
            }
            else
            {
                matrixRows = sentence.Length / matrixCols + 1;
            }
            char[,] matrix = new char[matrixRows, matrixCols];

            FillTheMatrix(sentence, matrix);

            for (int row = matrix.GetLength(0)-2; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix = Exchange(matrix, row, col);
                }
            }
            Print(matrix);
        }

        static void Print(char[,]matrix)
        {
            Console.Write("<table>");//SecurityElement.Escape("<table>"));
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("<tr>");//"{0}", SecurityElement.Escape("<tr>"));
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("<td>{0}</td>", matrix[row, col]);
                }
                Console.Write("</tr>");//"{0}", SecurityElement.Escape("</tr>"));
            }
            Console.WriteLine("</table>");//, SecurityElement.Escape("<table>"));
        }

        static char[,] Exchange(char[,]matrix,int currentRow, int currentCol)
        {
            if(matrix[currentRow+1,currentCol]==' ')
            {
                while(true)
                {
                    matrix[currentRow + 1, currentCol] = matrix[currentRow, currentCol];
                    matrix[currentRow, currentCol] = ' ';
                    currentRow++;
                    if(currentRow+1>=matrix.GetLength(0)||matrix[currentRow+1,currentCol]!=' ')
                    {
                        break;
                    }
                }
                //do
                //{
                //    matrix[currentRow + 1, currentCol] = matrix[currentRow, currentCol];
                //    matrix[currentRow, currentCol] = ' ';
                //    currentRow++;
                //}
                //while (matrix[currentRow+1,currentCol] == ' ' && currentRow < matrix.GetLength(0));
            }
            return matrix;
        }

        private static void FillTheMatrix(string sentence, char[,] matrix)
        {
            for (int row = 0, indexCounter = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++, indexCounter++)
                {
                    if (indexCounter < sentence.Length)
                    {
                        matrix[row, col] = sentence[indexCounter];
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }

                }
            }
        }
    }
}
