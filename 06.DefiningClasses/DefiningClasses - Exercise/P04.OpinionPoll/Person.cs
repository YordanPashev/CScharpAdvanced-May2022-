﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string name, int age) 
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<Person> GetAllPersonsAbove30(List<Person> allPersons)
        {
            List<Person> peopleAbove30 = allPersons.Where(p => p.Age > 30).ToList();

            return peopleAbove30;
        }
    }
}
