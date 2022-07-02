namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            decimal result = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(folderPath);
            FileInfo[] fileInfos = dirInfo.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo fileInfo in fileInfos)
            {
                result += fileInfo.Length;
            }

            result = result / 1024 / 1024;

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.Write(result);
            }
        }
    }
}
