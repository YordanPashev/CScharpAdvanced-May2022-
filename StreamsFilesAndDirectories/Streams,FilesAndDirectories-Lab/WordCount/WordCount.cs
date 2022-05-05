namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                Dictionary<string, int> words = new Dictionary<string, int>();

                using (StreamReader wordsToMatch = new StreamReader(wordsFilePath))
                {
                    string line = wordsToMatch.ReadToEnd();

                    string[] arrayOfWords = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    foreach (string currWord in arrayOfWords)
                    {
                        words.Add(currWord.ToLower(), 0);
                    }


                    using (StreamReader textReader = new StreamReader(textFilePath))
                    {
                        string[] text = textReader.ReadToEnd().Split(new string[] { ".", "?", "!", " ", ";", ":", ",", "-", "\r", "\n", "…" }, StringSplitOptions.RemoveEmptyEntries);
                        
                        foreach (string currWord in text)
                        {
                            string  wordToCheck = currWord.ToLower();
                            if (words.ContainsKey(wordToCheck))
                            {
                                words[wordToCheck]++;
                            }

                        }
                    }
                }

                foreach (var currWord in words)
                {
                    writer.WriteLine($"{currWord.Key} - {currWord.Value}");
                }
            }
        }
    }
}
