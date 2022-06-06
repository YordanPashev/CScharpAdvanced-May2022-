using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);
                string town = cmdArgs[2];
                Person newPersonToAdd = new Person(name, age, town);
                persons.Add(newPersonToAdd);
            }

            int indexOfPersonToCompare = int.Parse(Console.ReadLine()) - 1;

            Person personsToCompare = persons[indexOfPersonToCompare];
            int matchCount = 0;
            int notEaquelCount = 0;

            foreach (Person person in persons)
            {
                if (person.CompareTo(personsToCompare) == 0)
                {
                    matchCount++;
                }

                else
                {
                    notEaquelCount++;
                }
            }

            if (matchCount == 1)
            {
                Console.WriteLine("No matches");
            }

            else
            {
                Console.WriteLine($"{matchCount} {notEaquelCount} {persons.Count}");
            }
        }
    }
}
