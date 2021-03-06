using System;
using System.Collections.Generic;
using System.Linq;

namespace _17._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> planning = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] commands = input.Split(":");
                string operation = commands[0];
                if (operation == "Add")
                {
                    string lesson = commands[1];
                    if (planning.Contains(lesson) == false)
                    {
                        planning.Add(lesson);
                    }

                }
                else if (operation == "Insert")
                {
                    string lessonInsert = commands[1];
                    int index = int.Parse(commands[2]);
                    if (planning.Contains(lessonInsert) == false)
                    {
                        if (index >= 0 && index < planning.Count)
                        {
                            planning.Insert(index, lessonInsert);
                        }
                    }

                }
                else if (operation == "Remove")
                {
                    string removeLesson = commands[1];
                    if (planning.Contains(removeLesson))
                    {
                        int index = planning.IndexOf(removeLesson);
                        if (index + 1 < planning.Count)
                        {
                            if (planning[index + 1] == $"{removeLesson}-Excercise")
                            {
                                planning.RemoveRange(index, 2);
                            }
                            else
                            {
                                planning.Remove(removeLesson);
                            }
                        }
                        else
                        {
                            planning.Remove(removeLesson);
                        }

                    }
                }
                else if (operation == "Swap")
                {
                    string firstSwap = commands[1];
                    string secondSwap = commands[2];
                    if (planning.Contains(firstSwap) && planning.Contains(secondSwap))
                    {
                        int firstSwapIndex = planning.IndexOf(firstSwap);
                        int secondSwapIndex = planning.IndexOf(secondSwap);

                        planning[firstSwapIndex] = secondSwap;
                        planning[secondSwapIndex] = firstSwap;

                        if (firstSwapIndex + 1 < planning.Count && secondSwapIndex + 1 < planning.Count)
                        {
                            if (planning[firstSwapIndex + 1] == $"{firstSwap}-Exercise" && planning[secondSwapIndex + 1] == $"{secondSwap}-Exercise")
                            {
                                string temp = planning[secondSwapIndex + 1];
                                planning[secondSwapIndex + 1] = planning[firstSwapIndex + 1];
                                planning[firstSwapIndex + 1] = temp;
                            }
                            else if (planning[firstSwapIndex + 1] == $"{firstSwap}-Exercise")
                            {
                                planning.Insert(secondSwapIndex + 1, planning[firstSwapIndex + 1]);

                                if (secondSwapIndex > firstSwapIndex)
                                {
                                    planning.RemoveAt(firstSwapIndex + 1);
                                }
                                else if (secondSwapIndex < firstSwapIndex)
                                {
                                    planning.RemoveAt(firstSwapIndex + 2);
                                }
                            }
                            else if (planning[secondSwapIndex + 1] == $"{secondSwap}-Exercise")
                            {
                                planning.Insert(firstSwapIndex + 1, planning[secondSwapIndex + 1]);

                                if (firstSwapIndex < secondSwapIndex)
                                {
                                    planning.RemoveAt(secondSwapIndex + 2);
                                }
                                else if (firstSwapIndex > secondSwapIndex)
                                {
                                    planning.RemoveAt(secondSwapIndex + 1);
                                }
                            }
                            else if (firstSwapIndex + 1 < planning.Count)
                            {
                                if (planning[firstSwapIndex + 1] == $"{firstSwap}-Exercise")
                                {
                                    planning.Insert(secondSwapIndex + 1, planning[firstSwapIndex + 1]);

                                    if (secondSwapIndex > firstSwapIndex)
                                    {
                                        planning.RemoveAt(firstSwapIndex + 1);
                                    }
                                    else if (secondSwapIndex < firstSwapIndex)
                                    {
                                        planning.RemoveAt(firstSwapIndex + 2);
                                    }
                                }
                            }
                            else if (secondSwapIndex + 1 < planning.Count)
                            {
                                if (planning[secondSwapIndex + 1] == $"{secondSwap}-Exercise")
                                {
                                    planning.Insert(firstSwapIndex + 1, planning[secondSwapIndex + 1]);

                                    if (firstSwapIndex<secondSwapIndex)
                                    {
                                        planning.RemoveAt(secondSwapIndex + 2);
                                    }
                                    else if (firstSwapIndex>secondSwapIndex)
                                    {
                                        planning.RemoveAt(secondSwapIndex + 1);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (operation == "Exercise")
                {
                    string title = commands[1];

                    if (planning.Contains(title))
                    {
                        int index = planning.IndexOf(title);

                        if (index + 1 < planning.Count)
                        {
                            if (planning[index+1] != $"{title}-Exercise")
                            {
                                planning.Insert(index + 1, $"{title}-Exercise");
                            }
                        }
                        else
                        {
                            planning.Add($"{title}-Exercise");
                        }
                    }
                    else
                    {
                        planning.Add(title);
                        planning.Add($"{title}-Exercise");
                    }
                }



                input = Console.ReadLine();
            }

            for (int index = 0; index < planning.Count; index++)
            {
                Console.WriteLine($"{index+1}.{planning[index]}");
            }
        }
    }
}
