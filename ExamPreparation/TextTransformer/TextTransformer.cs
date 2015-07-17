using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformer
{
    using System.Text.RegularExpressions;

    class TextTransformer
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb=new StringBuilder();

            while (!input.Contains("burp"))
            {
                sb.Append(input.Trim());
                input = Console.ReadLine();
            }

            string wholeInput = sb.ToString();
            string pattern = @"\$[^&%'$]+?\$|\&[^&%'$]+?\&|\'[^&%'$]+?\'|\%[^&%'$]+?\%";
            Regex reg=new Regex(pattern);
            MatchCollection matches = reg.Matches(wholeInput);
            List<string>importantPieces=new List<string>();
            foreach (Match match in matches)
            {
                importantPieces.Add(match.ToString());
            }

            List<string> final=new List<string>();
            foreach (var item in importantPieces)
            {
                int weight = 0;
                    switch (item[0])
                    {
                        case'$':
                            weight = 1;
                            final.Add(GetDecriptedString(item,weight));
                            break;
                        case '%':
                            weight = 2;
                            final.Add(GetDecriptedString(item,weight));
                            break;
                        case '\'':
                            weight = 4;
                            final.Add(GetDecriptedString(item,weight));
                            break;
                        case '&':
                            weight = 3;
                            final.Add(GetDecriptedString(item,weight));
                            break;
                }
            }
            Console.WriteLine(string.Join(" ",final));
        }

        private static string GetDecriptedString(string item, int weight)
        {
            StringBuilder sb=new StringBuilder();
            for (int i = 1; i < item.Length-1; i++)
            {
                char current;
                if (i % 2 != 0)
                {
                    current = (char)(item[i] + weight);
                }
                else
                {
                    current = (char)(item[i] - weight);
                }

                sb.Append(current);
            }

            return sb.ToString();
        }
    }
}
