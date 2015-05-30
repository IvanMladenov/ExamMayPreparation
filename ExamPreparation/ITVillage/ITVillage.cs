using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITVillage
{
    class ITVillage
    {
        static void Main(string[] args)
        {
            string[] inputFields = Console.ReadLine().Split('|');
            StringBuilder sb = new StringBuilder();
            sb.Append(inputFields[0] + inputFields[1][7]+inputFields[2][7]+Reverse(inputFields[3])+inputFields[2][1]+inputFields[1][1]);
            sb.Replace(" ", string.Empty);
            string toCount=sb.ToString();

            int[] startPos = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int startIndex = StartPosition(startPos);

            int[] dices = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int gameCoins = 50;
            int innCounter = toCount.Count(x=>x=='I');
            for (int i = 0; i < dices.Length; i++)
            {
                int currentMove = dices[i];
                startIndex = (startIndex+currentMove)%sb.Length;
                char currentChar = sb[startIndex];
                if (currentChar == 'N')
                {
                    Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                    return;
                }
                switch (currentChar)
                {
                    case 'P':
                        gameCoins -= 5;
                        break;

                    case 'I':
                        if (gameCoins >= 100)
                        {
                            gameCoins -= 100;
                            innCounter--;
                            if(innCounter==0)
                            {
                                Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>",gameCoins);
                                //return;
                            }
                        }
                        else
                        {
                            gameCoins -= 10;
                        }
                        break;

                    case 'F':
                        gameCoins += 20;
                        break;

                    case 'S':
                        i += 2;
                        break;

                    case 'V':
                        gameCoins *= 10;
                        break;
                }
              
                if(gameCoins<0)
                {
                    Console.WriteLine("<p>You lost! You ran out of money!<p>");
                    return;
                }

            }
            Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>",gameCoins);


         }

        static string Reverse(string x)
        {
            char[] arr = x.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static int StartPosition(int[] arr)
        {
            switch (arr[0])
            {
                case 1:
                    return arr[1] - 1;
                    break;
                case 2:
                    if (arr[1] == 1)
                    {
                        return 11;
                    }
                    return 4;
                    break;
                case 3:
                    if (arr[1] == 1)
                    {
                        return 10;
                    }
                    return 5;
                    break;
                case 4:
                    return 10 - arr[1];
                    break;
                default:
                    return 0;
            }
        }
    }
}
