using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LittleJohn
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                string currentLine = Console.ReadLine();
                input += currentLine + " ";
            }
            string pattern = @"(>>>----->>)|(>>----->)|(>----->)";
            Regex regex = new Regex(pattern);
            MatchCollection mathces = regex.Matches(input);

            int small = 0;
            int medium = 0;
            int large = 0;
            foreach (Match match in mathces)
            {
                if (match.ToString() == ">>>----->>")
                {
                    large++;
                }
                else if (match.ToString() == ">>----->")
                {
                    medium++;
                }
                else if (match.ToString() == ">----->")
                {
                    small++;
                }
            }
            string arrrowsResult = small.ToString() + medium.ToString() + large.ToString();
            string binary = Convert.ToString(int.Parse(arrrowsResult), 2);
            char[] reversed = binary.ToCharArray();
            Array.Reverse(reversed);
            string toConvert = binary + new string(reversed);
            int result = Convert.ToInt32(toConvert, 2);
            Console.WriteLine(result);
        }
    }
}
