using System;
using System.Collections.Generic;

namespace GenericBoxofString
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Box<string>> listOfStrings = new List<Box<string>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();
                Box<string> box = new Box<string>(input);
                listOfStrings.Add(box);
            }

            foreach (Box<string> box in listOfStrings)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}
