using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            int inputLine = int.Parse(Console.ReadLine());

            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            for (int i = 0; i < inputLine; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = personData[0];
                int age = int.Parse(personData[1]);

                Person currPerson = new Person(name, age);
                sortedSet.Add(currPerson);
                hashSet.Add(currPerson);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
