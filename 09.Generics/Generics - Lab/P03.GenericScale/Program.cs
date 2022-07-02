using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> twoElementsToCompare = new EqualityScale<string>("test", "test");
            Console.WriteLine(twoElementsToCompare.AreEqual());
        }
    }
}
