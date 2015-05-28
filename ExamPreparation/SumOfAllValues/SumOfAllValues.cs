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
            string keyPattern = @"^([a-zA-Z_]+)\d.+\d([a-zA-Z_]+)$";

            Match match = Regex.Match(keyString, keyPattern);
            string startKey = match.Groups[1].Value.ToString();
            string endKey = match.Groups[2].Value.ToString();
        }
    }
}
