namespace CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class CommandInterpreter
    {
        private static void Main(string[] args)
        {
            string inputArray = Console.ReadLine();
            List<string> array = inputArray.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string commandLine = Console.ReadLine();

            while (!commandLine.Contains("end"))
            {
                string[] commandArray = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (commandArray[0])
                    {
                        case "reverse":
                            GetReversedArray(array, int.Parse(commandArray[2]), int.Parse(commandArray[4]));
                            break;
                        case "sort":
                            GetSortedArray(array, int.Parse(commandArray[2]), int.Parse(commandArray[4]));
                            break;
                        case "rollLeft":
                            GetRolledLeftArray(array, int.Parse(commandArray[1]));
                            break;
                        case "rollRight":
                            GetRolledRightArray(array, int.Parse(commandArray[1]));
                            break;
                        default:
                            throw new InvalidOperationException("Unrecognized command");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input parameters.");
                }

                commandLine = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", array));
        }

        private static void GetRolledRightArray(List<string> array, int countTimes)
        {
            if (countTimes < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int numberOfIterations = countTimes % array.Count;
            for (int i = 0; i < numberOfIterations; i++)
            {
                array.Insert(0, array[array.Count - 1]);
                array.RemoveAt(array.Count - 1);
            }
        }

        private static void GetRolledLeftArray(List<string> array, int countTimes)
        {
            if (countTimes < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int numberOfIterations = countTimes % array.Count;
            for (int i = 0; i < numberOfIterations; i++)
            {
                array.Insert(array.Count, array[0]);
                array.RemoveAt(0);
            }
        }

        private static void GetSortedArray(List<string> array, int startFrom, int count)
        {
            List<string> arrayToSort = array.GetRange(startFrom, count);
            array.RemoveRange(startFrom, count);
            arrayToSort.Sort();
            array.InsertRange(startFrom, arrayToSort);
        }

        private static void GetReversedArray(List<string> array, int startFrom, int count)
        {
            List<string> arrayToReverse = array.GetRange(startFrom, count);
            array.RemoveRange(startFrom, count);
            arrayToReverse.Reverse();
            array.InsertRange(startFrom, arrayToReverse);
        }
    }
}