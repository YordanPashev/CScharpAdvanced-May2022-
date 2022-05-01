using System;
using System.Collections.Generic;

namespace P06.RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> setOfUniqueNames = new HashSet<string>();
            
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string nameToAdd = Console.ReadLine();
                setOfUniqueNames.Add(nameToAdd);
            }
          
            foreach (var name in setOfUniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
