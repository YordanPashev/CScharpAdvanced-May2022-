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
            using (FileStream writer = new FileStream(outputPath, FileMode.Open))
            {
                HashSet<byte> bytesToCheck = new HashSet<byte>();
                using (StreamReader reader = new StreamReader(bytesFilePath))
                {
                    bytesToCheck = Encoding.UTF8.GetBytes(bytesFilePath).ToHashSet();
                }

                using (FileStream reader = new FileStream(binaryFilePath, FileMode.Open))
                {
                    byte[] arrayOfBytes = new byte[1];

                    int currByte;
                    while ((currByte = reader.Read(arrayOfBytes, 0, arrayOfBytes.Length)) != 0)
                    {
                        if (bytesToCheck.Contains(arrayOfBytes[0]))
                        {
                            writer.Write(arrayOfBytes, 0, arrayOfBytes.Length);
                        }
                    }
                }
            }
        }
    }
}
