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
            string line = Console.ReadLine();
            Dictionary<string, Player> pagesByColor=new Dictionary<string,Player>();

            //pagesByColor["purple"]=new Player();
            //pagesByColor[purple]=

            while(!line.Contains("END"))
            {
                string[] data = line.Split('|');
                string color = data[0];
                if(!pagesByColor.ContainsKey(color))
                {
                    pagesByColor[color] = new Player();
                }

                if(data[1]=="age")
                {
                    int age = int.Parse(data[2]);
                    pagesByColor[color].Age = age;
                }

                else if(data[1]=="name")
                {
                    pagesByColor[color].Name=data[2]
                }
                else if(data[1]=="win:)
                {
                      
                }
                line = Console.ReadLine();
            }
        }
    }
    class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Oponents { get; set; }
        public int Wins { get; set; }
        public int Loss { get; set; }
    }
}
