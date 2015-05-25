using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace ClearingCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char[]> matrix = new List<char[]>();
            string command = Console.ReadLine();
            while (!command.Contains("END"))
            {
                matrix.Add(command.ToCharArray());
                command = Console.ReadLine();
            }
            string commands = "><^v";
            for (int row = 0; row < matrix.Count; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    char current = matrix[row][col];
                    switch (current)
                    {
                        case '<':
                            for (int i = col - 1; i >= 0; i--)
                            {
                                if (!commands.Contains(matrix[row][i]))
                                {
                                    matrix[row][i] = ' ';
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        case '>':
                            for (int i = col + 1; i < matrix[row].Length; i++)
                            {
                                if (!commands.Contains(matrix[row][i]))
                                {
                                    matrix[row][i] = ' ';
                                }
                                else
                                {
                                    break;
                                }
                            }
                            break;
                        case '^':
                            for (int i = row - 1; i >= 0; i--)
                                if (!commands.Contains(matrix[i][col]))
                                {
                                    matrix[i][col] = ' ';
                                }
                                else
                                {
                                    break;
                                }

                            break;
                        case 'v':
                            for (int i = row + 1; i < matrix.Count; i++)
                            {
                                if (!commands.Contains(matrix[i][col]))
                                {
                                    matrix[i][col] = ' ';
                                }
                                else
                                {
                                    break;
                                }
                            }

                            break;
                    }
                }
            }
            for (int i = 0; i < matrix.Count; i++)
            {
                Console.Write("<p>");
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(SecurityElement.Escape(matrix[i][j].ToString()));
                }
                Console.WriteLine("</p>");
            }
        }
    }
}
