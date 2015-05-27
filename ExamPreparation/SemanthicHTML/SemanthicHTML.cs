using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SemanthicHTML
{
    class SemanthicHTML
    {
        static void Main(string[] args)
        {
            var row = Console.ReadLine();
            var openTagPattern = @"<div(.*)(id|class)\s*=\s*""(\w+)""(.*)";
            var closeTagPattern = @"<\/div>\s*<!--\s*(\w+)\s*-->";

            while(row!="END")
            {
                if(Regex.IsMatch(row,openTagPattern))
                {
                    var matches = Regex.Match(row, openTagPattern);
                    var tagName = matches.Groups[3].Value.Trim();
                    var before=matches.Groups[1].Value.TrimEnd();
                    var after = matches.Groups[4].Value.TrimEnd();
                    var result = "<" + tagName + before + after;
                    result.Replace("\\s+", " ");
                    result.TrimEnd();
                    Console.WriteLine(result);
                }
                else if(Regex.IsMatch(row,closeTagPattern))
                {
                    var matches = Regex.Match(row, closeTagPattern);
                    var tagname =matches.Groups[1].Value.Trim();
                    var result = "</" + tagname + ">";
                    Console.WriteLine(result);

                }
                else
                {
                    Console.WriteLine(row);
                }
                row = Console.ReadLine();
            }
        }
    }
}
