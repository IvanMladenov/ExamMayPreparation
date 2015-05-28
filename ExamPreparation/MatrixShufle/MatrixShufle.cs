using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixShufle
{
    class MatrixShufle
    {
        public static int currentRow;
        public static int currentCol;
        public static int matrixSize;

        static void Main(string[] args)
        {
            matrixSize = int.Parse(Console.ReadLine());
            List<char> textToFill = Console.ReadLine().ToList();

            char[][]result=new char [matrixSize][];

            int textCount=textToFill.Count();
            for (int i =textCount ; i < matrixSize*matrixSize; i++)
            {
                textToFill.Add(' ');
            }

            currentCol = 0;
            currentRow = 0;

            while(textToFill.Count>0)
            {
                RightFill(result, textToFill);
                DownFill(result, textToFill);
                LeftFill(result, textToFill);
                UpFill(result, textToFill);
            }
        }

        static void RightFill(char[][] matrix,List<char>text)
        {
            //char[][] filled = matrix;
            int toStopAt=matrixSize-currentRow;
            while(currentRow<toStopAt)
            {
                matrix[currentRow][currentCol] = text[0];
                text.RemoveAt(0);
                currentCol++;
            }
                
            //return filled;
        }

        static char[][] LeftFill(char[][] matrix, List<char> text)
        {
            char[][] filled = matrix;

            return filled;
        }

        static char[][] DownFill(char[][] matrix, List<char> text)
        {
            char[][] filled = matrix;

            return filled;
        }

        static char[][] UpFill(char[][] matrix, List<char> text)
        {
            char[][] filled = matrix;

            return filled;
        }

    }
}
