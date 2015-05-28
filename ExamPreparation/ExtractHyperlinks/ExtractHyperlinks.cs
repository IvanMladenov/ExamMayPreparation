using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ExtractHyperlinks
{
    class ExtractHyperlinks
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=<a).+?(?=<\/a>)";
            string hrefPattern = @"";
            Regex reg = new Regex(pattern);

            StringBuilder allText = new StringBuilder();

            while(!input.Contains("END"))
            {
                allText.Append(input);
                input = Console.ReadLine();
            }
            MatchCollection matches = reg.Matches(allText.ToString());
            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString());
            }
        }
    }
}
