using System;
using System.IO;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] readFirst = File.ReadAllText("../../../Input1.txt").Split();
            string[] readSecond = File.ReadAllText("../../../Input2.txt").Split('\r', '\n');
            File.WriteAllText("Output.txt", "");
            for (int i = 0; i < readFirst.Length; i++)
            {
                File.AppendAllText("Output.txt", readFirst[i] + "\r\n" + readSecond[i]);
            }

            //using FileStream reader = new FileStream("./Output.txt", FileMode.Open);

            //const int DEF_SIZE = 4096;
            //using FileStream reader = new FileStream("./copyMe.png", FileMode.Open);
            //using FileStream writer = new FileStream("../../../copied.png", FileMode.Create);

            //byte[] buffer = new byte[DEF_SIZE];

            //while (reader.CanRead)
            //{
            //    int bytesRead = reader.Read(buffer, 0, buffer.Length);
            //    if (bytesRead == 0)
            //    {
            //        break;
            //    }

            //    writer.Write(buffer, 0, buffer.Length);
            //}

            //using FileStream reader1 = new FileStream("./copyMe2.jpg", FileMode.Open);
            //using FileStream writer1 = new FileStream("../../../copied2.jpg", FileMode.Create);

            //byte[] buffer1 = new byte[DEF_SIZE];

            //while (reader1.CanRead)
            //{
            //    int bytesRead = reader1.Read(buffer1, 0, buffer1.Length);
            //    if (bytesRead == 0)
            //    {
            //        break;
            //    }

            //    writer1.Write(buffer1, 0, buffer1.Length);
            //}
        }
    }
}
