using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> fileInfo = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo("../../../");
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (var file in files)
            {
                if (!fileInfo.ContainsKey(file.Extension))
                {
                    fileInfo.Add(file.Extension, new Dictionary<string, double>());
                }
                fileInfo[file.Extension].Add(file.Name, file.Length / 1000.00);
            }
            
            //for (int i = 0; i < files.Length; i++)
            //{
            //    string extension = files[i].Extension;
            //    string fileName = files[i].Name;
            //    double fileSize = files[i].Length;

            //    if (!fileInfo.ContainsKey(extension))
            //    {
            //        fileInfo[extension] = new Dictionary<string, double>();
            //    }

            //    if (!fileInfo[extension].ContainsKey(fileName))
            //    {
            //        fileInfo[extension][fileName] = fileSize;
            //    }
            //}

            using (StreamWriter writer = new StreamWriter
                (@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\DirectoryTraversal.txt"))
            {
                foreach (var item in fileInfo.OrderByDescending(f => f.Value.Count).ThenBy(i => i.Key))
                {
                    writer.WriteLine($"{item.Key}");
                    foreach (var file in item.Value.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
            //2
            //    var dict = new Dictionary<string, List<string>>();

            //    var input = Console.ReadLine();
            //    var file = Directory.GetFiles(input);
            //    ReadFiles(dict, file);

            //    var allFiles = FilesAsString(dict);

            //    // This will make resulted file on your desktop!!!
            //    var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //    File.WriteAllText(@$"{path}\report.txt", allFiles);
            //}

            //private static string FilesAsString(Dictionary<string, List<string>> dict)
            //{
            //    dict = dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            //    var sb = new StringBuilder();

            //    foreach (var d in dict)
            //    {
            //        sb.AppendLine($"{d.Key}");

            //        foreach (var item in d.Value)
            //        {
            //            sb.AppendLine(item);
            //        }
            //    }

            //    return sb.ToString().TrimEnd();
            //}

            //private static void ReadFiles(Dictionary<string, List<string>> dict, string[] file)
            //{
            //    foreach (var item in file)
            //    {
            //        var currentFile = new FileInfo(item);
            //        var extension = currentFile.Extension;
            //        var fileName = currentFile.Name;
            //        var fileMemory = currentFile.Length / 1024.00;

            //        if (!dict.ContainsKey(extension))
            //        {
            //            dict.Add(extension, new List<string>());
            //        }

            //        dict[extension].Add($"--{fileName} - {fileMemory:F3}kb");
            //    }
            //}
        }
    }
}
