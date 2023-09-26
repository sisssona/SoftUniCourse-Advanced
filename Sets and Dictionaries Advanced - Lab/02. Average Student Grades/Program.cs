using System.Xml.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();    
            for (int i = 0; i < n; i++)
            {
                string[] studentsGrades = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string student = studentsGrades[0];
                decimal grade = decimal.Parse(studentsGrades[1]);

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<decimal>());
                    students[student].Add(grade);

                }
                else
                {
                    students[student].Add(grade);
                }
            }
            foreach (var item in students)
            {
                string name = item.Key;
                List<decimal> grades = item.Value;
                decimal average = item.Value.Average();
                Console.WriteLine($"{name} -> {String.Join(" ", grades.Select(grade => $"{grade:F2}"))} (avg: {average:f2})");
            }
        }
    }
}