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
            string reportFileName = @"C:\Users\..\Desktop\report.txt";

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
                string fileName = Path.GetFileName(filePath);
                string extension   = Path.GetExtension(filePath);
                double size = new FileInfo(filePath).Length / 1024.0;

                if (!filesInfo.ContainsKey(extension))
                {
                    filesInfo.Add(extension, new Dictionary<string, double>());
                }

                filesInfo[extension].Add(fileName, size);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var ext in filesInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.AppendLine(ext.Key);

                foreach (var file in ext.Value.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value:F3}kb");   
                }
            }

            return sb.ToString().TrimEnd(); 
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";
            File.WriteAllText(path, textContent);

        }

    }
}
