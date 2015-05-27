using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SemanthicHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string patternOpen=@"<(div)\s*.*\s*((id|class)\s*=\s*""([a-z]+)"").*(\s*>)";
            string patternClose = @"<\/(div)>(\s*<!--\s*([a-z]+)\s*-->)";
            string whitespaceRemoveArea = @"(\s*)(<.*>)";

            Regex close = new Regex(patternClose);
            Regex open=new Regex(patternOpen);
            Regex area = new Regex(whitespaceRemoveArea);

            while(!input.Contains("END"))
            {
                if(input.Contains("<div"))
                {
                    Match matchOpen = open.Match(input);
                    input = Regex.Replace(input, matchOpen.Groups[1].Value.ToString(), matchOpen.Groups[4].Value.ToString());
                    input = Regex.Replace(input, matchOpen.Groups[2].Value.ToString(), string.Empty);
                    input=Regex.Replace(input, matchOpen.Groups[5].Value.ToString(), "");
                    input = input.TrimEnd() + ">";
                    //Remove whitespaces
                    Match whitespaces = area.Match(input);
                    string removedWhitespaces = whitespaces.Groups[2].Value.ToString();
                    removedWhitespaces=Regex.Replace(removedWhitespaces,"\\s{2,}"," ");
                    input = whitespaces.Groups[1].Value.ToString() + removedWhitespaces;
                     

                    Console.WriteLine(input);

                }
                else if(input.Contains("</div"))
                {
                    Match match = close.Match(input);
                    input = Regex.Replace(input, match.Groups[1].Value.ToString(), match.Groups[3].Value.ToString());
                    input = Regex.Replace(input, match.Groups[2].Value.ToString(), string.Empty);
                    Console.WriteLine(input);
                }
                else
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
