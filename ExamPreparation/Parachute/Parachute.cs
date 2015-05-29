using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Parachute
{
    class Parachute
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int indexOfParachute=0;
            bool parachuteOnMap = false;
            int numberOfIterations = 0;

            while(!input.Contains("END"))
            {
                char[] row = input.ToCharArray();

                if(parachuteOnMap)
                {
                    int curIndex=indexOfParachute+WindMotion(row);
                    if(row[curIndex]=='/'||row[curIndex]=='\\')
                    {
                        Console.WriteLine("Got smacked on the rock like a dog!");
                        Console.WriteLine("{0} {1}", numberOfIterations, curIndex);
                        break;
                    }
                    else if(row[curIndex]=='~')
                    {
                        Console.WriteLine("Drowned in the water like a cat!");
                        Console.WriteLine("{0} {1}", numberOfIterations, curIndex);
                        break;
                    }
                    else if(row[curIndex]=='_')
                    {
                        Console.WriteLine("Landed on the ground like a boss!");
                        Console.WriteLine("{0} {1}", numberOfIterations, curIndex);
                        break;
                    }
                    indexOfParachute = curIndex;
                }
                if (row.Contains('o')&&!parachuteOnMap)
                {
                    indexOfParachute = GenIndexO(row);
                    parachuteOnMap = true;
                }
                
                input = Console.ReadLine();
                numberOfIterations++;
            }
        }

        static int GenIndexO(char[]row)
        {
            int index=0;
            for (int i = 0; i < row.Length; i++)
            {
                if(row[i]=='o')
                {
                    index = i;
                    break;
                }             
            }
            return index;
        }

        static int WindMotion(char[]row)
        {
            int direction = 0;
            for (int i = 0; i < row.Length; i++)
            {
                if(row[i]=='<')
                {
                    direction--;
                }
                else if(row[i]=='>')
                {
                    direction++;
                }
            }
            return direction;
        }
    }
}
