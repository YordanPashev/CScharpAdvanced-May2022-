using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < membersCount; i++)
            {
                string[] currMemberInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = currMemberInfo[0];
                int age = int.Parse(currMemberInfo[1]);
                Person newMemberToAdd = new Person(name, age);
                family.AddMember(newMemberToAdd);
            }
         
            Person oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

        }
    }
}
