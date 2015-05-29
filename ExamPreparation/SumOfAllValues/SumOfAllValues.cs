using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SumOfAllValues
{
    class SumOfAllValues
    {
        static void Main(string[] args)
        {
            string keyString = Console.ReadLine();
            string text = Console.ReadLine();
            string keyPattern = @"^([a-zA-Z_]+)\d.*\d([a-zA-Z_]+)$";//@"^([a-zA-Z_]+)\d.*\d([a-zA-Z_]+)$";

            Match match = Regex.Match(keyString, keyPattern);
            if(match.Groups.Count<2)
            {
                Console.WriteLine("<p>A key is missing</p>");
                return;
            }

            string startKey = match.Groups[1].Value.ToString();
            string endKey = match.Groups[2].Value.ToString();
            string decimalPattern = string.Format(@"{0}(\d*\.\d+){1}",startKey,endKey);
            string integerPattern = string.Format(@"{0}(\d+){1}", startKey, endKey);
            MatchCollection doubleMatches = Regex.Matches(text, decimalPattern);
            MatchCollection intMathces = Regex.Matches(text, integerPattern);

            double sum = 0;
            foreach (Match item in doubleMatches)
            {
                double currentMatch = double.Parse(item.Groups[1].Value.ToString());
                sum += currentMatch;
            }

            foreach (Match item in intMathces)
            {
                double current = double.Parse(item.Groups[1].Value.ToString());
                sum += current;
            }
            if(sum!=0)
            {
                Console.WriteLine("<p>The total value is: <em>{0}</em></p>",sum);
            }
            else
            {
                Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            }
        }
    }
}
