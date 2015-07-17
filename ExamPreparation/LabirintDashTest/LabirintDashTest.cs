namespace LabirintDashTest
{
    using System;

    internal class LabirintDashTest
    {
        private static void Main(string[] args)
        {
            int labirintRows = int.Parse(Console.ReadLine());

            char[][] labirint = new char[labirintRows][];

            for (int i = 0; i < labirintRows; i++)
            {
                labirint[i] = Console.ReadLine().ToCharArray();
            }

            char[] commands = Console.ReadLine().ToCharArray();
            int[] currentPosition = { 0, 0 };
            int lives = 3;
            int movesMade = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];
                int[] previousPosition = new int[]{currentPosition[0],currentPosition[1]};
                ChangeCurrentPosition(currentPosition, command);
                if (!IsValidPosition(currentPosition, labirint))
                {
                    movesMade++;
                    Console.WriteLine("Fell off a cliff! Game Over!");
                    Console.WriteLine("Total moves made: {0}", movesMade);
                    return;
                }

                char currentCellValue = labirint[currentPosition[0]][currentPosition[1]];
                switch (currentCellValue)
                {
                    case '_':
                    case '|':
                        currentPosition = previousPosition;
                        Console.WriteLine("Bumped a wall.");
                        break;
                    case '$':
                        lives++;
                        movesMade++;
                        Console.WriteLine("Awesome! Lives left: {0}", lives);
                        labirint[currentPosition[0]][currentPosition[1]] = '.';
                        break;
                    case ' ':
                        movesMade++;
                        Console.WriteLine("Fell off a cliff! Game Over!");
                        Console.WriteLine("Total moves made: {0}", movesMade);
                        return;
                    case '.':
                        movesMade++;
                        Console.WriteLine("Made a move!");
                        break;
                    case '@':
                    case '*':
                    case '#':
                        movesMade++;
                        lives--;
                        if (lives == 0)
                        {
                            Console.WriteLine("No lives left! Game Over!");
                            Console.WriteLine("Total moves made: {0}", movesMade);
                            return;
                        }

                        Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                        break;
                }
            }

            Console.WriteLine("Total moves made: {0}", movesMade);
        }

        private static void ChangeCurrentPosition(int[] currentPosition, char command)
        {
            switch (command)
            {
                case '>':
                    currentPosition[1]++;
                    break;
                case '<':
                    currentPosition[1]--;
                    break;
                case '^':
                    currentPosition[0]--;
                    break;
                case 'v':
                    currentPosition[0]++;
                    break;
            }
        }

        private static bool IsValidPosition(int[] currentPosition, char[][] labirint)
        {
            if (currentPosition[0] >= 0 && currentPosition[0] < labirint.Length)
            {
                if (currentPosition[1] >= 0 && currentPosition[1] < labirint[currentPosition[0]].Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}