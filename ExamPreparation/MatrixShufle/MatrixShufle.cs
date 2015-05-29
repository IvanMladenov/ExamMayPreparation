using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixShufle
{
    class MatrixShufle
    {
        //public static int currentRow;
        //public static int currentCol;
        public static int matrixSize;

        static void Main(string[] args)
        {
            matrixSize = int.Parse(Console.ReadLine());
            List<char> textToFill = Console.ReadLine().ToList();

            char[,] result = new char[matrixSize, matrixSize];

            int textCount=textToFill.Count();
            for (int i =textCount ; i < matrixSize*matrixSize; i++)
            {
                textToFill.Add(' ');
            }

            SpiralMatrixFill(textToFill, result);

            StringBuilder whiteSquares = new StringBuilder();
            StringBuilder blackSquares = new StringBuilder();
            for (int row = 0; row < result.GetLength(0); row++)
            {
                if(row%2==0)
                {
                    whiteSquares.Append(WhiteOrBlackSquaresEstract(row, 0, result));
                    blackSquares.Append(WhiteOrBlackSquaresEstract(row, 1, result));
                }
                else
                {
                    whiteSquares.Append(WhiteOrBlackSquaresEstract(row, 1, result));
                    blackSquares.Append(WhiteOrBlackSquaresEstract(row, 0, result));
                }
            }

            string final = whiteSquares.ToString() + blackSquares.ToString();

            if(IsPalindrome(final))
            {
                Console.WriteLine("<div style='background-color:#4FE000'>{0} </div>", final);
            }
            else
            {
                Console.WriteLine("<div style='background-color:#E0000F'>{0} </div>", final);
            }
        }

        static bool IsPalindrome(string toCheck)
        {
            StringBuilder check = new StringBuilder();
            toCheck = toCheck.ToLower();

            for (int i = 0; i < toCheck.Length; i++)
            {
                if(char.IsLetter(toCheck[i]))
                {
                    check.Append(toCheck[i]);
                }
            }
            string reversed = string.Join("", check.ToString().Reverse());
            bool isPalindrome = reversed == check.ToString();
            return isPalindrome;
        }

        static string WhiteOrBlackSquaresEstract(int currRow, int startAt, char[,]matrix)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = startAt; i < matrix.GetLength(1); i+=2)
            {
                sb.Append(matrix[currRow, i]);
            }
            return sb.ToString();
        }

        private static void SpiralMatrixFill(List<char> textToFill, char[,] result)
        {
            int firstLoopCol = 0; int firstLoopColEnd = matrixSize;

            int secondLoopRow = 1; int secondLoopRowEnd = matrixSize;

            int thirdLoopRow = matrixSize - 1 - 1; int thirdLoopRowEnd = 0;

            int fourthLoopRow = matrixSize - 1 - 1; int fourthLoopRowEnd = 1; int thirdLoopCol = 0;

            while (textToFill.Count > 0)
            {
                for (int i = firstLoopCol; i < firstLoopColEnd; i++)
                {
                    result[firstLoopCol, i] = textToFill[0];
                    textToFill.RemoveAt(0);
                }
                firstLoopCol++;
                firstLoopColEnd--;
                for (int i = secondLoopRow; i < secondLoopRowEnd; i++)
                {
                    result[i, secondLoopRowEnd - 1] = textToFill[0];
                    textToFill.RemoveAt(0);
                }
                secondLoopRowEnd--;
                secondLoopRow++;
                for (int i = thirdLoopRow; i >= thirdLoopRowEnd; i--)
                {
                    result[thirdLoopRow + 1, i] = textToFill[0];
                    textToFill.RemoveAt(0);
                }
                thirdLoopRow--;
                thirdLoopRowEnd++;
                for (int i = fourthLoopRow; i >= fourthLoopRowEnd; i--)
                {
                    result[i, thirdLoopCol] = textToFill[0];
                    textToFill.RemoveAt(0);
                }
                thirdLoopCol++;
                fourthLoopRowEnd++;
                fourthLoopRow--;
            }
        }
    }
}
