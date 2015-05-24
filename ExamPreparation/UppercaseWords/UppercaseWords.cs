using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UppercaseWords
{
    class UppercaseWords
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            string pattern = @"^[A-Z]+(?=[^\w])|(?<=[^\w])[A-Z]+$|(?<=[^\w])[A-Z]+(?=[^\w])";
            Regex reg = new Regex(pattern);
            List<string> result = new List<string>();
            while(!inputLine.Contains("END"))
            {
                MatchCollection matches = reg.Matches(inputLine);
                HashSet<string> noRepeats = new HashSet<string>();
                foreach(Match match in matches)
                {
                    noRepeats.Add(match.ToString());
                }
                foreach(string unique in noRepeats)
                {
                    string reversed = Reverse(unique);
                    if (unique != reversed)
                    {
                        
                        inputLine = inputLine.Replace(unique, reversed);
                    }
                    else
                    {
                        //inputLine = Regex.Replace(inputLine, unique, DoubleChars(unique));
                        inputLine = inputLine.Replace(reversed, DoubleChars(reversed));
                    }
                }
                result.Add(inputLine);
                inputLine = Console.ReadLine();
            }
            foreach(string str in result)
            {
                Console.WriteLine(SecurityElement.Escape(str));
            }
        }

        static string DoubleChars(string toDouble)
        {
            StringBuilder doubled = new StringBuilder();
            for (int i = 0; i < toDouble.Length; i++)
            {
                doubled.Append(toDouble[i], 2);
            }
            return doubled.ToString();
        }
        
        static string Reverse(string toReverse)
        {
            char[] arr = toReverse.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
