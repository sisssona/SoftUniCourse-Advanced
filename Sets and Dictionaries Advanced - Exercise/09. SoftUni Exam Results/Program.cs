using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> students = new SortedDictionary<string, int>();
            SortedDictionary<string, int> submissions = new SortedDictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] info = input.Split("-");
                if (info.Length != 2)
                {

                    string username = info[0];
                    string language = info[1];
                    int points = int.Parse(info[2]);
                    if (!students.ContainsKey(username))
                    {
                        students.Add(username, points);

                    }
                    else
                    {
                        if (points > students[username])
                        {
                            students[username] = points;
                        }
                    }
                    if (!submissions.ContainsKey(language))
                    {
                        submissions.Add(language, 0);
                    }

                    submissions[language]++;
                }
                else
                {
                    string username = info[0];
                    students.Remove(username);
                }

            }
            Console.WriteLine("Results:");
            foreach (var user in students.OrderByDescending(x=>x.Value))
            {             
                    Console.WriteLine($"{user.Key} | {user.Value}");                
            }
            Console.WriteLine($"Submissions:");
            foreach (var student in submissions.OrderByDescending(l => l.Value))
            {              
                    Console.WriteLine($"{student.Key} - {student.Value}");                
            }
        }
    }
}