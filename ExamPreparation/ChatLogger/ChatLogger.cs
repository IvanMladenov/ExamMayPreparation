using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Globalization;

namespace ChatLogger
{
    class ChatLogger
    {
        static void Main(string[] args)
        {
            DateTime currentTime = DateTime.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            SortedDictionary<DateTime, string> dict = new SortedDictionary<DateTime, string>();
            while (!input.Contains("END"))
            {
                string[]arr=input.Split('/');
                string message = arr[0].Trim();
                DateTime date = DateTime.Parse(arr[1].Trim());
                dict.Add(date,message);
                
                input = Console.ReadLine();
            }

            foreach (var item in dict)
            {
                Console.WriteLine("<div>{0}</div>",SecurityElement.Escape(item.Value));
            }

            LastMessage(currentTime, dict.Last().Key);
        }

        static void LastMessage(DateTime current, DateTime lastMessage)
        {
            if(lastMessage.Day-current.Day>1)
            {
                Console.WriteLine("<p>Last active: <time>{0}-{1}-{2}</time></p>", lastMessage.Day, lastMessage.Month, lastMessage.Year);
            }
            else if(lastMessage.Day-current.Day==1)
            {
                Console.WriteLine("<p>Last active: <time>yesterday</time></p>");
            }
            else if(lastMessage.Hour-current.Hour==1)
            {
                Console.WriteLine("<p>Last active: <time>1 hour ago</time></p>");
            }
            else if(lastMessage.Hour-current.Hour>1)
            {
                Console.WriteLine("<p>Last active: <time>{0} hours ago</time></p>", lastMessage.Hour - current.Hour);
            }
            else if(lastMessage.Minute-current.Minute==1)
            {
                Console.WriteLine("<p>Last active: <time>1 minute ago</time></p>");
            }
            else if (lastMessage.Minute - current.Minute > 1)
            {
                Console.WriteLine("<p>Last active: <time>{0} minute ago</time></p>",lastMessage.Minute-current.Minute);
            }
            else if(lastMessage.Minute-current.Minute<1)
            {
                Console.WriteLine("<p>Last active: <time>a few moments ago</time></p>");
            }

        }

        public static System.Globalization.DateTimeStyles cultureinfo { get; set; }
    }
}
