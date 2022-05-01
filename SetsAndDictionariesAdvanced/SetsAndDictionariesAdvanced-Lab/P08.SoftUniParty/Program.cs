using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();
            Regex vipGuestRegex = new Regex(@"^[0-9]{1}[\w]{7}$");
            string guestName;
            while ((guestName = Console.ReadLine()) != "PARTY")
            {
                if (vipGuestRegex.IsMatch(guestName))
                {
                    vipGuests.Add(guestName);
                    continue;
                }

                regularGuests.Add(guestName);
            }

            while ((guestName = Console.ReadLine()) != "END")
            {
                if (vipGuests.Contains(guestName))
                {
                    vipGuests.Remove(guestName);
                    continue;
                }

                regularGuests.Remove(guestName);
            }

            DisplayAllGuestWhoMissTheParty(vipGuests, regularGuests);
        }

        static void DisplayAllGuestWhoMissTheParty(HashSet<string> vipGuests, HashSet<string> regularGuests)
        {
            Console.WriteLine(vipGuests.Count + regularGuests.Count);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
