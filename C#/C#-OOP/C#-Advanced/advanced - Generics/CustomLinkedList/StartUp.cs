using System;

namespace CustomLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoubleLinkedList<int> doubleLinked = new DoubleLinkedList<int>();
            doubleLinked.AddFirst(1);
            doubleLinked.AddFirst(2);
            doubleLinked.AddFirst(3);
            doubleLinked.AddFirst(4);
            doubleLinked.ForEach(Console.WriteLine);
        }
    }
}
