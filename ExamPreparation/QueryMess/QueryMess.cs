using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P7_QuerryMess
{
    class QuerryMess
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"\s{2,}";//search 2 or more whitespaces
            Regex regex = new Regex(pattern);
            //List<string> str = new List<string>();
            do
            {
                for (int i = 0; i < input.Length; i++)
                {
                    input[i] = input[i].Replace("%20", " ").Replace('+', ' ');
                    input[i] = regex.Replace(input[i], " ");//reduce multiple whitespaces to single
                    //str.Add(input[i]);
                }
                Print(input);
                input = Console.ReadLine().Split(new char[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries);
            }
            while (!input.Contains("END"));
        }
        static void Print(string[] input)
        {
            string key = @".+(?==)"; //new pattern to search keys
            Regex regKey = new Regex(key);
            string value = @"(?<==).+";//search values
            Regex regValue = new Regex(value);
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            for (int i = 0; i < input.Length; i++)
            {
                Match matchKey = regKey.Match(input[i]);
                string currentKey = matchKey.ToString().Trim();
                Match matchValue = regValue.Match(input[i]);
                string currentValue = matchValue.ToString().Trim();
                if (result.Keys.Contains(currentKey) && currentKey != string.Empty)
                {
                    result[currentKey].Add(currentValue);
                }
                else if (!result.Keys.Contains(currentKey) && currentKey != string.Empty)
                {
                    result.Add(currentKey, new List<string>());
                    result[currentKey].Add(currentValue);
                }
            }
            foreach (string item in result.Keys)
            {
                Console.Write("{0}=[{1}]", item, string.Join(", ", result[item]));
            }
            Console.WriteLine();

        }

    }
}
