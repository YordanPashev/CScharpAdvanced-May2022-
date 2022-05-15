using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> FamilyMembers { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            FamilyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            List<Person> oldestFamilyMember = FamilyMembers.OrderByDescending(p => p.Age).ToList();

            return oldestFamilyMember[0];
        }

    }
}
