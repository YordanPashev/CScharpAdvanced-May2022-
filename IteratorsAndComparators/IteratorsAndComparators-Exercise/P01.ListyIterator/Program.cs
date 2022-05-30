using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var listOfItems = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> collection = new ListyIterator<string>(listOfItems.Skip(1).ToList());
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                if (cmd == "Move")
                {
                    Console.WriteLine(collection.Move());
                }

                else if (cmd == "Print")
                {
                    collection.Print();
                }

                else if (cmd == "HasNext")
                {
                    Console.WriteLine(collection.HasNext());
                }
            }
        }
    }
}
