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
            string input = Console.ReadLine();
            string pattern = @"(?<=[^a-zA-Z]|^)([A-Z]*)(?=[^a-zA-Z]|$)";
            Regex reg = new Regex(pattern);

            while(!input.Contains("END"))
            {
                MatchCollection matches = reg.Matches(input);
                HashSet<string> noRepeats = new HashSet<string>();

                foreach (Match match in matches)
                {
                    noRepeats.Add(match.ToString());
                }
                foreach (string unique in noRepeats)
                {

                    if(unique==Reverse(unique))
                    {
                        string replacePattern = string.Format("(?<=[^a-zA-Z]){0}(?=[^a-zA-Z])", unique);
                        input = Regex.Replace(input, replacePattern, DoubleChars(unique));

                    }
                    else
                    {
                        input = Regex.Replace(input,unique,Reverse(unique));
                    }
                    

                }
                Console.WriteLine(SecurityElement.Escape(input));
                input = Console.ReadLine();
            }
            //string inputLine = Console.ReadLine();
            //string pattern = @"^[A-Z]+(?=[^\w])|(?<=[^\w])[A-Z]+$|(?<=[^\w])[A-Z]+(?=[^\w])";
            //Regex reg = new Regex(pattern);
            //List<string> result = new List<string>();
            //while(!inputLine.Contains("END"))
            //{
            //    MatchCollection matches = reg.Matches(inputLine);
            //    HashSet<string> noRepeats = new HashSet<string>();
            //    foreach(Match match in matches)
            //    {
            //        noRepeats.Add(match.ToString());
            //    }
            //    foreach(string unique in noRepeats)
            //    {
            //        string reversed = Reverse(unique);
            //        string proba = @"\b" + unique;
            //        Regex rep = new Regex(proba);

            //        if (unique != reversed)
            //        {
            //            inputLine = rep.Replace(inputLine, reversed);
            //        }
            //        else
            //        {
            //            inputLine = rep.Replace(inputLine,DoubleChars(unique));
            //        }
            //    }
            //    result.Add(inputLine);
            //    inputLine = Console.ReadLine();
            //}
            //foreach(string str in result)
            //{
            //    Console.WriteLine(SecurityElement.Escape(str));
            //}
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
