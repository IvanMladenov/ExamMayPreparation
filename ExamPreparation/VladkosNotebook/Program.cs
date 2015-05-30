using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladkosNotebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = Console.ReadLine();
            Dictionary<string, Player> pagesByColor = new Dictionary<string, Player>();
            
            while(!entry.Contains("END"))
            {
                string[] data = entry.Split('|');
                string color = data[0];
                if(!pagesByColor.ContainsKey(color))
                {
                    pagesByColor[color] = new Player();
                   // pagesByColor[color].Opponents = new List<string>();
                }
                Player currentPlayer = pagesByColor[color];
                if(data[1]=="age")
                {
                    currentPlayer.Age = int.Parse(data[2]);
                }
                else if(data[1]=="name")
                {
                    currentPlayer.Name = data[2];
                }
                else if(data[1]=="win")
                {
                    currentPlayer.WinCount++;
                    currentPlayer.Opponents.Add(data[2]);
                }
                else if(data[1]=="loss")
                {
                    currentPlayer.LossCount++;
                    currentPlayer.Opponents.Add(data[2]);
                }
                entry = Console.ReadLine();
            }

            var validPages = pagesByColor                
                .Where(p => p.Value.Age != 0&& p.Value.Name != null)
                .OrderBy(p => p.Key);

            if(validPages.Count()==0)
            {
                Console.WriteLine("No data recovered.");
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach(var page in validPages)
            {
                sb.AppendLine(string.Format("Color: {0}", page.Key));
                sb.AppendLine(string.Format("-age: {0}", page.Value.Age));
                sb.AppendLine(string.Format("-name: {0}", page.Value.Name));

                string opponents = "(empty)";
                if (page.Value.Opponents.Count > 0)
                {
                    var sortedOpponents = page.Value.Opponents.OrderBy(o => o, StringComparer.Ordinal);
                    sb.AppendLine(string.Format("-opponents: {0}", string.Join(", ", sortedOpponents)));
                }
                else
                {
                    sb.AppendLine(string.Format("-opponents: {0}", opponents));
                }
                double rank = (double)(page.Value.WinCount + 1) / (page.Value.LossCount + 1);
                sb.AppendLine(string.Format("-rank: {0:F2}",rank));
            }
            Console.WriteLine(sb.ToString());
        }
    }

    class Player
    {
        public Player()
        {
            this.Opponents = new List<string>();
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<String> Opponents { get; set; }

        public int WinCount { get; set; }

        public int LossCount { get; set; }
    }
}
