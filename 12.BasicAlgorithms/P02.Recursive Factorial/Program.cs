using System;

namespace P02.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int digit = int.Parse(Console.ReadLine());
            int result = CalculateFactorial(digit);
            Console.WriteLine(result);
        }

        public static int CalculateFactorial(int digit)
        {
            if (digit == 1)
            {
                return 1;
            }

            return digit * CalculateFactorial(digit - 1);
        }
    }
}
