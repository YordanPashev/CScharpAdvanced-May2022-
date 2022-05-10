using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.FilterByAge
{
    class Student
    {
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> dataBase = new List<Student>();
            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                string[] currPersonInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = currPersonInfo[0];
                int age = int.Parse(currPersonInfo[1]);
                dataBase.Add(new Student(name, age));
            }

            string condition = Console.ReadLine();
            int ageRestriciton = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Student, int, bool> filter = GetFiler(condition);
            dataBase = dataBase.Where(s => filter(s, ageRestriciton)).ToList();
            Action<Student> print = GetPrinter(format);
            dataBase.ForEach(print);
        }

        private static Action<Student> GetPrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return s => Console.WriteLine(s.Name);
                case "age":
                    return s => Console.WriteLine(s.Age);
                case "name age":
                    return s => Console.WriteLine($"{s.Name} - {s.Age}");
                default:
                    return null;
            }
        }

        private static Func<Student, int, bool> GetFiler(string condition)
        {
            switch (condition)
            {
                case "older":
                    return (s, ageREstriction) => s.Age >= ageREstriction;
                case "younger":
                    return (s, ageREstriction) => s.Age < ageREstriction;
                default:
                    return null;
            }
        }
    }
}
