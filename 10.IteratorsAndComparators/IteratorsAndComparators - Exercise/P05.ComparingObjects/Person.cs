using System;
using System.Collections.Generic;


namespace ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public List<Person> MyProperty { get; set; }

        public int CompareTo(Person person)
        {
            int comareResultByNames = this.Name.CompareTo(person.Name);
            if (comareResultByNames != 0)
            {
                return comareResultByNames;
            }

            int comareResultByAge = this.Age.CompareTo(person.Age);
            if (comareResultByAge != 0)
            {
                return comareResultByAge;
            }

            int comareResultByTown = this.Town.CompareTo(person.Town);
            if (comareResultByTown != 0)
            {
                return comareResultByTown;
            }

            return 0;
        }
    }
}
