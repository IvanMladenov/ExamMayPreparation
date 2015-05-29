using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OhMyGirl
{
    class OhMyGirl
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            while(!input.Contains("END"))
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            string keyCreated = KeyGenerator(key);
            string pattern = string.Format("{0}(.{{2,6}}?){0}", keyCreated);
            StringBuilder result = new StringBuilder();
            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);
            foreach(Match item in matches)
            {
                result.Append(item.Groups[1].ToString());
            }
            
            Console.WriteLine(result.ToString());
        }

        static string KeyGenerator(string key)
        {
            char[] escapeChars=new char[]{'.','$','^','{','[', '(', '|', ')', '*', '+', '?', '\\'};
            StringBuilder sb = new StringBuilder();
            if(escapeChars.Contains(key[0]))
            {
                sb.Append("\\"+key[0]);
            }
            else
            {
                sb.Append(key[0]);
            }          
            for (int i = 1; i < key.Length-1; i++)
            {
                if (char.IsLetterOrDigit(key[i]))
                {
                    if (char.IsDigit(key[i]))
                    {
                        sb.Append("\\"+"d*");
                    }
                    else if(char.IsLower(key[i]))
                    {
                        sb.Append("[a-z]*");
                    }
                    else
                    {
                        sb.Append("[A-Z]*");
                    }
                }
                else if(escapeChars.Contains(key[i]))
                {
                    sb.Append("\\" + key[i]);
                }
                else
                {
                    sb.Append(key[i]);
                }
            }
            if (!escapeChars.Contains(key[key.Length - 1]))
            {
                sb.Append(key[key.Length - 1]);
            }
            else
            {
                sb.Append("\\" + key[key.Length - 1]);
            }
            return sb.ToString();
        }
    }
}
