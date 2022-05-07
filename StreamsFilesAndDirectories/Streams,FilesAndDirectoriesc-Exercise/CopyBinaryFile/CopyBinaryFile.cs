using System.IO;
using System.Linq;
using System.Text;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);

        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream writer = new FileStream(outputFilePath, FileMode.CreateNew))
            {
                using (FileStream reader = new FileStream(inputFilePath, FileMode.Open))
                {
                    byte[] arrayOfBytes = new byte[1024];

                    int currBytes;
                    while ((currBytes = reader.Read(arrayOfBytes, 0, arrayOfBytes.Length)) != 0)
                    {
                        writer.Write(arrayOfBytes, 0, arrayOfBytes.Length);
                    }
                }
            }
        }
    }
}
