namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(inputFilePath))
                {

                    int lineCounter = 1;
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int currLineLettersCount = 0;
                        int currLinePunctuationMarksCount = 0;
                        foreach (char symbol in line)
                        {
                            if (char.IsLetter(symbol))
                            {
                                currLineLettersCount++;
                                continue;
                            }

                            else if (char.IsWhiteSpace(symbol))
                            {
                                continue;
                            }

                            currLinePunctuationMarksCount++;

                        }
                        writer.WriteLine($"Line {lineCounter}: {line} ({currLineLettersCount})({currLinePunctuationMarksCount})");
                    }
                }
            }
        }
    }
}
