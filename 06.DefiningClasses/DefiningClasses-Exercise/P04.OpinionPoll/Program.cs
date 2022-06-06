using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peaopleCount = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            Person persons = new Person();
            for (int i = 0; i < peaopleCount; i++)
            {
                string[] currMemberInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = currMemberInfo[0];
                int age = int.Parse(currMemberInfo[1]);
                Person newMemberToAdd = new Person(name, age);
                people.Add(newMemberToAdd);
            }

            List<Person> personsAbove30 = persons.GetAllPersonsAbove30(people);

            foreach (Person person in personsAbove30.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }




        }
    }
}
