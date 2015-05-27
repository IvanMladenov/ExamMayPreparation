using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid
{
    class Pyramid
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int previousNumber = int.Parse(Console.ReadLine().Trim());
            int[] toAdd = new int[]{previousNumber};
            List<int[]> row=new List<int[]>();
            row.Add(toAdd);
            for (int i = 0; i < numberOfRows; i++)
            {
                string line = Console.ReadLine();
                int[]currentRow = line.
                    Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray();
                row.Add(currentRow);
            }
            
            int maxNumber = int.MinValue;

            List<int> sequence = new List<int>();
            sequence.Add(previousNumber);
  
            for (int i = 1; i < row.Count; i++)
            {
                for (int j = 0; j < row[i].Length; j++)
                {
                    if(row[i][j]>previousNumber)
                    {
                        previousNumber = row[i][j];
                        sequence.Add(row[i][j]);
                        break;
                    }
                    else
                    {
                        previousNumber++;
                    }
                }
            }
            Console.WriteLine(string.Join(", ", sequence));
           
        }
    }
}
