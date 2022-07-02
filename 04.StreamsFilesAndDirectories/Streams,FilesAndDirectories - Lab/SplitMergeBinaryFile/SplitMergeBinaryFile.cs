namespace SplitMergeBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (StreamReader reader = new StreamReader(sourceFilePath))
            {
                List<byte> allBytes = Encoding.UTF8.GetBytes(sourceFilePath).ToList();

                byte[] data = new byte[1];
                for (int i = 0; i < allBytes.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        using (StreamWriter firstPart = new StreamWriter(partOneFilePath))
                        {
                            firstPart.Write(allBytes[i]);
                        }
                        continue;
                    }

                    using (StreamWriter secondPart = new StreamWriter(partTwoFilePath))
                    {
                        secondPart.Write(allBytes[i]);
                    }
                }

            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (StreamWriter writer = new StreamWriter(joinedFilePath))
            {
                List<byte> firstPart = Encoding.UTF8.GetBytes(partOneFilePath).ToList();
                List<byte> secondPart = Encoding.UTF8.GetBytes(partOneFilePath).ToList();

                for (int i = 0; i < firstPart.Count; i++)
                {
                    if (i >= secondPart.Count)
                    {
                        writer.Write(firstPart[i]);
                        continue;
                    }

                    writer.Write(firstPart[i]);
                    writer.Write(secondPart[i]);
                }

            }
        }
    }
}