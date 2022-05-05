namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {

                List<byte> bytesToCheck = Encoding.UTF8.GetBytes(bytesFilePath).ToList();
                byte[] binaryFileBytes = Encoding.UTF8.GetBytes(binaryFilePath);

                foreach (var byt in binaryFileBytes)
                {
                    if (bytesToCheck.Contains(byt))
                    {
                        writer.Write(byt);
                    }
                }

            }
        }
    }
}
