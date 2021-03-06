using System;
using System.IO;

namespace _6._Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Console.ReadLine();
            string[] files = Directory.GetFiles(directoryPath);

            double sum = 0.0;
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                Console.WriteLine($"{info.FullName} --> {info.Length} bytes");
                sum += info.Length;
            }
            Console.WriteLine(sum);
        }
    }
}
