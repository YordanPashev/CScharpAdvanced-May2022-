using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> dataBase = new HashSet<string>();

            int numberOfUsers = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfUsers; i++)
            {
                string currUsername = Console.ReadLine();
                dataBase.Add(currUsername);
            }

            dataBase.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
