using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> dataBase = new HashSet<string>();

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = cmd
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string action = cmdArgs[0];
                string licenseNumber = cmdArgs[1];

                if (action == "IN")
                {
                    if (!dataBase.Contains(licenseNumber))
                    {
                        dataBase.Add(licenseNumber);
                    }
                }

                else if (action == "OUT")
                {
                    if (dataBase.Contains(licenseNumber))
                    {
                        dataBase.Remove(licenseNumber);
                    }
                }
            }

            if (dataBase.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            else
            {
                foreach (var licenseNumber in dataBase)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        }
    }
}
