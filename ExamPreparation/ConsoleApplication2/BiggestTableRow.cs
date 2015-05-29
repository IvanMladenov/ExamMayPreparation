using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication2
{
    class BiggestTableRow
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=<td>)-*\d*\.{0,1}\d+?(?=<\/td>)";
            Dictionary<double, List<string>> forPrint = new Dictionary<double, List<string>>();
            double maxSum = double.MinValue;

            while(!input.Contains("</table>"))
            {
                MatchCollection matches = Regex.Matches(input, pattern);
                double currentSum = 0;
                if (matches.Count > 0)
                {
                    List<string>currentValues=new List<string>();
                    foreach (Match item in matches)
                    {                        
                        currentSum += double.Parse(item.ToString());
                        currentValues.Add(item.ToString());
                    }
                    if(currentSum>maxSum)
                    {
                        maxSum = currentSum;
                        forPrint.Add(maxSum, currentValues);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("{0} = {1}", maxSum, string.Join(" + ", forPrint[maxSum]));
        }
    }
}
