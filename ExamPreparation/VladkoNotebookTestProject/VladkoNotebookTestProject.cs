namespace VladkoNotebookTestProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class VladkoNotebookTestProject
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Player> container = new Dictionary<string, Player>();

            while (!input.Contains("END"))
            {
                string[] inputSplited = input.Split('|');
                if (!container.ContainsKey(inputSplited[0]))
                {
                    container.Add(inputSplited[0], new Player());
                }

                switch (inputSplited[1])
                {
                    case "win":
                        container[inputSplited[0]].Wins++;
                        container[inputSplited[0]].Opponents.Add(inputSplited[2]);
                        break;
                    case "loss":
                        container[inputSplited[0]].Loss++;
                        container[inputSplited[0]].Opponents.Add(inputSplited[2]);
                        break;
                    case "name":
                        container[inputSplited[0]].Name = inputSplited[2];
                        break;
                    case "age":
                        container[inputSplited[0]].Age = int.Parse(inputSplited[2]);
                        break;
                }

                input = Console.ReadLine();
            }

            var sortedDictionary =
                container.Where(x => x.Value.Name != null).Where(x => x.Value.Age != default(int)).OrderBy(x => x.Key);
            if (sortedDictionary.Count()==0)
            {
                Console.WriteLine("No data recovered.");
            }

            foreach (var pair in sortedDictionary)
            {
                pair.Value.Opponents.Sort(StringComparer.Ordinal);
                string color = pair.Key;
                int playerAge = pair.Value.Age;
                string playerName = pair.Value.Name;
                string opponent = pair.Value.Opponents.Any() ? string.Join(", ", pair.Value.Opponents) : "(empty)";
                double rank = ((double)pair.Value.Wins + 1) / (pair.Value.Loss + 1);

                Console.WriteLine("Color: {0}", color);
                Console.WriteLine("-age: {0}", playerAge);
                Console.WriteLine("-name: {0}", playerName);
                Console.WriteLine("-opponents: {0}", opponent);
                Console.WriteLine("-rank: {0:F2}", rank);
            }
        }
    }

    internal class Player
    {
        public Player()
        {
            this.Opponents = new List<string>();
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public int Wins { get; set; }

        public int Loss { get; set; }

        public List<string> Opponents { get; set; }
    }
}