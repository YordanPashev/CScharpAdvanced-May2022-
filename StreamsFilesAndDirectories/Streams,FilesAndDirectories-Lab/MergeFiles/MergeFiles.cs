namespace MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                List<string> firstTextLines = new List<string>();
                List<string> secondTextLines = new List<string>();

                using (StreamReader readerOne = new StreamReader(firstInputFilePath))
                {
                    string line;
                    while ((line = readerOne.ReadLine()) != null)
                    {
                        firstTextLines.Add(line);
                    }
                }

                using (StreamReader readerTwo = new StreamReader(secondInputFilePath))
                {
                    string line;
                    while ((line = readerTwo.ReadLine()) != null)
                    {
                        secondTextLines.Add(line);
                    }
                }

                int numberOflineForLoop = 0;
                if (firstTextLines.Count >= secondTextLines.Count)
                {
                    for (int i = 0; i < firstTextLines.Count; i++)
                    {
                        if (i >= secondTextLines.Count)
                        {
                            writer.WriteLine(firstTextLines[i]);
                            continue;
                        }

                        writer.WriteLine(firstTextLines[i]);
                        writer.WriteLine(secondTextLines[i]);
                    }
                }

                else
                {
                    for (int i = 0; i < secondTextLines.Count; i++)
                    {
                        if (i >= firstTextLines.Count)
                        {
                            writer.WriteLine(secondTextLines[i]);
                            continue;
                        }
                        writer.WriteLine(firstTextLines[i]);
                        writer.WriteLine(secondTextLines[i]);

                    }
                }     
            }
        }
    }
}
