using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PhoneNumbers
{
    class PhoneNumbers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pairPattern = @"([A-Z][A-Za-z]*)[^0-9A-Za-z+]*([+]?[0-9]+[0-9\- \.\/\)\(]*[0-9]+)";//@"([A-Z][a-z]+[a-z])[^a-zA-Z\d\+]+([\d\+][)(\.\-\s\d\/)]+[\d])";
            Regex reg = new Regex(pairPattern);
            Dictionary<string, string> results = new Dictionary<string, string>();
            bool isResult = false;

            while(!input.Contains("END"))
            {
                MatchCollection matches = reg.Matches(input);

                foreach (Match item in matches)
                {
                    results.Add(item.Groups[1].Value.ToString(), item.Groups[2].Value.ToString());
                    isResult = true;
                }

                input=Console.ReadLine();
            }
            if (isResult)
            {
                string replacePattern = @"[)(\-\.\/\s]";
                Console.Write("<ol>");
                foreach (var item in results)
                {
                    string phoneCleared = Regex.Replace(item.Value, replacePattern, string.Empty);

                    Console.Write("<li><b>{0}:</b> {1}</li>", item.Key, phoneCleared);
                }
                Console.WriteLine("</ol>");
            }
            else
            {
                Console.WriteLine("<p>No matches!</p>");
            }
        }
    }
}
