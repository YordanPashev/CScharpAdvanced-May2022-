using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person person)
        {
            if(this.Name.CompareTo(person.Name) != 0)
            {
                return this.Name.CompareTo(person.Name);
            }

            return this.Age.CompareTo(person.Age);
        }

        public override int GetHashCode()
        {
            return this.Name.ToLower().GetHashCode() + this.Age.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Person person = obj as Person;
            return this.Name.Equals(person.Name) && this.Age.Equals(person.Age);
        }
    }
}
