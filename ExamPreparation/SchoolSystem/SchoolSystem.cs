using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    class SchoolSystem
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, Dictionary<string, List<double>>>();

            for (int i = 0; i < count; i++)
            {
                var inputRow = Console.ReadLine();
                var student = inputRow.Split(' ');
                var fullName = student[0] + " " + student[1];
                var subject = student[2];
                var score = double.Parse(student[3]);
                if(students.ContainsKey(fullName))
                {
                    if(students[fullName].ContainsKey(subject))
                    {
                        students[fullName][subject].Add(score);
                    }
                    else
                    {
                        students[fullName].Add(subject, new List<double>() { score });
                    }
                }
                else
                {
                    var subjects=new Dictionary<string,List<double>>();
                    var scores=new List<double>();
                    scores.Add(score);
                    subjects.Add(subject,scores);
                    students.Add(fullName, subjects);
                }

            }
            foreach (var student in students)
            {
                var result = new StringBuilder();
                result.Append(student.Key+": [");
                foreach (var subjects in student.Value)
                {
                    result.Append(subjects.Key + " - " + subjects.Value.Average().ToString("0.00")+", ");
                }
                string forPrint=result.ToString().TrimEnd(new char[]{',',' '});
                forPrint += "]";
                Console.WriteLine(forPrint);

            }
        }
    }
}
