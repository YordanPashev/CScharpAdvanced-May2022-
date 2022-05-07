namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            List<string> text = new List<string>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int lineCounter = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineCounter % 2 == 0)
                    {
                        line = ReverseWords(line);
                        text.Add(line);
                    }

                    lineCounter++;
                }
            }

            return string.Join("\n", text);
        }
        private static string ReverseWords(string replacedSymbols)
        {
            string[] reverseWords = replacedSymbols.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray(); 
            Array.Reverse(reverseWords);
            replacedSymbols = string.Join(' ', reverseWords);
            return ReplaceSymbols(replacedSymbols);
        }


        private static string ReplaceSymbols(string line)
        {
            char[] separetors = new char[] { '-', ',', '.', '!', '?' };
            return separetors.Aggregate(line, (str, cItem) => str.Replace(cItem, '@'));
        }
    }
}
