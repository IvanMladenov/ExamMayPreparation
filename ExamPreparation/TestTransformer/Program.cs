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
            List<string> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();
            while (!command.Contains("end"))
            {
                string[] commandSplit = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandSplit[0] == "reverse")
                {
                    int start = int.Parse(commandSplit[2]);
                    int count = int.Parse(commandSplit[4]);
                    if (start < 0 || count < 0 || start > input.Count - 1 || start + count - 1 >= input.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    ReverseIt(input, start, count);

                }
                else if (commandSplit[0] == "sort")
                {

                    int start = int.Parse(commandSplit[2]);
                    int count = int.Parse(commandSplit[4]);
                    if (start < 0 || count < 0 || start > input.Count - 1 || start + count - 1 >= input.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    SortArr(input, start, count);

                }
                else if (commandSplit[0] == "rollLeft")
                {

                    int countTimes = int.Parse(commandSplit[1]);
                    if (countTimes < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    for (int i = 0; i < countTimes % input.Count; i++)
                    {
                        string current = input[0];
                        input.RemoveAt(0);
                        input.Insert(input.Count, current);
                    }
                }
                else if (commandSplit[0] == "rollRight")
                {
                    int countTimes = int.Parse(commandSplit[1]);
                    if (countTimes < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    for (int i = 0; i < countTimes % input.Count; i++)
                    {
                        string current = input[input.Count - 1];
                        input.RemoveAt(input.Count - 1);
                        input.Insert(0, current);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("[{0}]", string.Join(", ", input));

        }

        static void SortArr(List<string> toSort, int startFrom, int count)
        {
            List<string> sorting = new List<string>();

            for (int i = startFrom; i < startFrom + count; i++)
            {
                sorting.Add(toSort[i]);
            }
            sorting.Sort();

            for (int i = startFrom, counter = 0; i < startFrom + count; i++, counter++)
            {
                toSort.RemoveAt(i);
                toSort.Insert(i, sorting[counter]);
            }
        }

        static void ReverseIt(List<string> toReverse, int startFrom, int count)
        {
            string[] arr = new string[count];

            for (int i = startFrom, counter = 0; i < startFrom + count; i++, counter++)
            {
                arr[counter] = toReverse[i];
            }
            Array.Reverse(arr);
            for (int i = startFrom, counter = 0; i < startFrom + count; i++, counter++)
            {
                toReverse.RemoveAt(i);
                toReverse.Insert(i, arr[counter]);
            }

        }
    }
}