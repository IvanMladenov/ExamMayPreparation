using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixShufle
{
    class MatrixShufle
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            List<char> textToFill = Console.ReadLine().ToList();
            char[][]result=new char [matrixSize][];
            int textCount=textToFill.Count();
            for (int i =textCount ; i < matrixSize*matrixSize; i++)
            {
                textToFill.Add(' ');
            }

            int currentRow=0;
            int currentCol=0;

            while(textToFill.Count>0)
            {
                RightFill(result, textToFill);
                DownFill(result, textToFill);
                LeftFill(result, textToFill);
                UpFill(result, textToFill);
            }
        }

        static char[][] RightFill(char[][] matrix,List<char>text)
        {
            char[][] filled = matrix;

            return filled;
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
