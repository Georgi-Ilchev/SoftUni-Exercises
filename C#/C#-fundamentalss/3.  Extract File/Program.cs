using System;
using System.Linq;

namespace _3.__Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("\\").ToArray();
            string name = string.Empty;
            string type = string.Empty;

            string[] last = input[input.Length - 1].Split(".");
            name = last[0];
            type = last[1];

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {type}");
        }
    }
}
