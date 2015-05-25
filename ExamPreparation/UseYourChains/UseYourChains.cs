using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace UseYourChains
{
    class UseYourChains
    {
        static void Main()
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
            string input = Console.ReadLine();
            string findSequencesInTags =@"(?<=<p>)(.*?)(?=<\/p>)";
            MatchCollection matches = Regex.Matches(input, findSequencesInTags);
            List<string> sequences = new List<string>();

            string removeWhiteSpaces=@"\s{2,}";
            string notSmallLettersAndNums = @"[^a-z\d]";

            foreach(Match match in matches)
            {
                string current = match.ToString();
                current = Regex.Replace(current, notSmallLettersAndNums, " ");
                current = Regex.Replace(current, removeWhiteSpaces, " ");
                current = current.Trim();
                char[]arr=current.ToCharArray();

                for (int i = 0; i < arr.Length; i++)
                {
                    if(char.IsLetter(arr[i])&&arr[i]>='a'&&arr[i]<='m')
                    {
                        arr[i] = (char)(arr[i] + 13);
                    }
                    else if(char.IsLetter(arr[i])&&arr[i]>='n'&&arr[i]<='z')
                    {
                        arr[i] = (char)(arr[i] - 13);
                    }
                }

                sequences.Add(new string(arr));
            }
            Console.WriteLine(string.Join(" ", sequences));
        }
    }
}
