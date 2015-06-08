using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OlympicsAreComing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string,Country>all=new Dictionary<string,Country>();
     
            while (!input.Contains("report"))
            {
                string[] data = input.Split('|');
                for (int i = 0; i < data.Length; i++)
                {
                    Regex reg = new Regex("\\s+");
                    data[i] = reg.Replace(data[i], " ");
                    data[i] = data[i].Trim();
                }

                if(!all.ContainsKey(data[1]))
                {
                    all.Add(data[1], new Country(data[0]));
                    all[data[1]].Wins++;
                }
                else
                {
                    all[data[1]].Participants.Add(data[0]);
                    all[data[1]].Wins++;
                }
               
                input = Console.ReadLine();
            }

            var sorted = all.OrderByDescending(x => x.Value.Wins);

            foreach (var item in sorted)
            {
                Console.WriteLine("{0} ({1} participants): {2} wins", item.Key, item.Value.Participants.Count(), item.Value.Wins);
            }
        }
    }

    class Country
    {
        public Country(string participant)
        {
            this.Participants = new HashSet<string>(){participant};
        }

        public int Wins { get; set; }

        public HashSet<string> Participants { get; set; }
    }
}
