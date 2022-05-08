namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = "/report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*");

            Dictionary<string, Dictionary<string, double>> filesInfo = new Dictionary<string, Dictionary<string, double>>();
            
            foreach (string filePath in files)
            {
                FileInfo currFileInfo = new FileInfo(filePath);
                string fileName = currFileInfo.Name;
                string extension   = currFileInfo.Extension;
                double size = currFileInfo.Length / 1024.0;

                if (!filesInfo.ContainsKey(extension))
                {
                    filesInfo.Add(extension, new Dictionary<string, double>());
                }

                filesInfo[extension].Add(fileName, size);
            }

            StringBuilder allFilesInfo = new StringBuilder();

            foreach (var ext in filesInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                allFilesInfo.AppendLine(ext.Key);

                foreach (var fileInfo in ext.Value.OrderBy(x => x.Value))
                {
                    allFilesInfo.AppendLine($"--{fileInfo.Key} - {fileInfo.Value:F3}kb");   
                }
            }

            return allFilesInfo.ToString().TrimEnd(); 
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(path, textContent);

        }

    }
}
