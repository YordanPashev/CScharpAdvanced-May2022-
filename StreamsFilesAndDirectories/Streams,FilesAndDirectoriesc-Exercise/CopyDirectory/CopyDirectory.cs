namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            string inputPath = Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            Directory.CreateDirectory(outputPath);

            string[] filesToCopy = Directory.GetFiles(inputPath);

            foreach (var file in filesToCopy)
            {
                string fileName = outputPath + "/" + Path.GetFileName(file);
                File.Copy(file, fileName);
            }
        }
    }
}
