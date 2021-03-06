using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem17._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] parts = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Done")
            {
                string[] command = input.Split();

                if (command[0] == "Move")
                {
                    if (command[1] == "Left")
                    {
                        int index = int.Parse(command[2]);

                        if (index > 0 && index < parts.Length)
                        {
                            string temp = parts[index];
                            parts[index] = parts[index - 1];
                            parts[index - 1] = temp;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        int index = int.Parse(command[2]);
                        if (index >= 0 && index < parts.Length - 1)
                        {
                            string temp = parts[index];
                            parts[index] = parts[index + 1];
                            parts[index + 1] = temp;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                else
                {
                    if (command[1] == "Even")
                    {
                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Console.Write($"{parts[i]} ");
                            }
                        }
                        Console.WriteLine();
                    }
                    else if (command[1] == "Odd")
                    {
                        for (int i = 0; i < parts.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                Console.Write($"{parts[i]} ");
                            }
                        }
                        Console.WriteLine();
                    }
                }

            }
            Console.WriteLine($"You crafted {string.Join(null, parts)}!");
        }
    }
}
