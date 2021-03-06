using System;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            ZipFile.CreateFromDirectory(@"D:\ZipAndExtract1", @"D:\ZipAndExtract2\myZipFile.zip");
            ZipFile.ExtractToDirectory(@"D:\ZipAndExtract2\myZipFile.zip", @"D:\ZipAndExtract3");

            //2
            // First and foremost, it creates a zip file inside the project directory (the zip file contains the whole assembly directory).
            // Then, it unzips the zip file and extracts it on the desktop.
            // P.S. Apologies in case your desktop is overwhelmed, I just followed the task requirements.

            //string directoryPath = Directory.GetCurrentDirectory();
            //string zipPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../zipped.zip"));
            //string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //ZipFile.CreateFromDirectory(directoryPath, zipPath);
            //ZipFile.ExtractToDirectory(zipPath, desktop);
        }
    }
}
