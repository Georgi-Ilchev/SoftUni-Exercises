using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] elements = command.Split();
                if (elements[0] == "Delete")
                {

                    int elementDelete = int.Parse(elements[1]);
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == elementDelete )
                        {
                            list.RemoveAt(i);
                            i--;
                        }
                    }
                    //вместо цикъл
                    //int elementDelete = int.Parse(elements[1]);
                    //list.RemoveAll(x => x == elementDelete);


                }
                else if (elements[0] == "Insert")
                {
                    int elementInsert = int.Parse(elements[1]);
                    int index = int.Parse(elements[2]);

                    list.Insert(index, elementInsert);
                }


                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(' ',list));
        }
    }
}
