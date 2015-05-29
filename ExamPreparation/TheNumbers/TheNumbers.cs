using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TheNumbers
{
    class TheNumbers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, "\\d+");
            List<string> result = new List<string>();
            foreach (Match item in matches)
            {
                int currentMatch = int.Parse(item.Value.ToString());
                string hexadecial = currentMatch.ToString("X").PadLeft(4,'0');
                hexadecial="0x"+hexadecial;
                result.Add(hexadecial);
            }

            Console.WriteLine(string.Join("-", result));
        }
    }
}
