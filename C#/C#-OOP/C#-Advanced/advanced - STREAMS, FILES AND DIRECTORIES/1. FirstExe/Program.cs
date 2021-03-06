using System;
using System.IO;

namespace advanced___STREAMS__FILES_AND_DIRECTORIES
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader =
                new StreamReader("Input.txt"))
            {
                string line = reader.ReadLine();
                int index = 0;
                using (var writer = new StreamWriter("Output.txt"))
                {
                    while (line != null)
                    {
                        if (index % 2 == 1)
                        {
                            writer.WriteLine(line);
                        }
                        index++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
