using System;
using System.IO;

namespace _7._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Console.ReadLine();
            Console.WriteLine(GetDirectorySize(directoryPath,0));
        }
        static double GetDirectorySize(string directoryPath, int identation)
        {
            string[] files = Directory.GetFiles(directoryPath);
            double sum = 0.0;

            string[] directories = Directory.GetDirectories(directoryPath);
            for (int i = 0; i < directories.Length; i++)
            {
                Console.WriteLine($"{new string(' ', identation)}Directory: {directories[i]}");
                sum += GetDirectorySize(directories[i], identation +3);
            }

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                Console.WriteLine($"{new string ('-',identation)}{info.FullName} --> {info.Length} bytes");
                sum += info.Length;
            }
            return sum;
        }
    }
}
