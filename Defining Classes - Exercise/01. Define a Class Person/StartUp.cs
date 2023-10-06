using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        int numberOfpersonalInfo = int.Parse(Console.ReadLine());
        List<Person> personList = new();

        for (int i = 0; i < numberOfpersonalInfo; i++)
        {
            string[] personalInf = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string name = personalInf[0];
            int age = int.Parse(personalInf[1]);
            Person person = new Person(name, age);
            if (person.Age > 30)
            {
                personList.Add(person);
            }
        }
        foreach (var person in personList.OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
