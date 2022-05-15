using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "George";
            person.Age = 18;

            Console.WriteLine($"{person.Name} is {person.Age} years old.");

        }
    }
}
