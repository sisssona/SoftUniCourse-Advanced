﻿namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);
                Student student = new Student() { Name = name, Age = age };

                students.Add(student);            
            }
            //foreach (Student student in students)
            //{
            //    Console.WriteLine($"{student.Name} - {student.Age}");
            //}
            string filterType = Console.ReadLine();
            int filterNumber = int.Parse(Console.ReadLine());
            Func<Student, int, bool> filter = FilterGenerator(filterType);

            students = students.Where(student => filter(student, filterNumber)).ToList();
            string format = Console.ReadLine();
            Action<Student> printer = PrinterGenerator(format);
            students.ForEach(s => printer(s));

            Action<Student> PrinterGenerator(string format)
            {
                if (format == "name age")
                {
                    return s => Console.WriteLine($"{s.Name} - {s.Age}");
                }
                if (format == "name")
                {
                    return s => Console.WriteLine($"{s.Name}");
                }
                if (format == "age")
                {
                    return s => Console.WriteLine($"{s.Age}");
                }
                return null;
            }

            Func<Student, int, bool> FilterGenerator(string filterType)
            {
                Func<Student, int, bool> filter = null;
                if (filterType == "older")
                {
                    filter = (student, number) => student.Age >= number;
                }
                if (filterType == "younger")
                {
                    filter = (student, number) => student.Age < number;
                }
                return filter;
            }
        }
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}