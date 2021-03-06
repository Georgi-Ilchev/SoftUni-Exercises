using System;

namespace advanced___Implementing_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            for (int i = 0; i < 5; i++)
            {
                list.AddHead(new Node(i));
            }

            for (int i = 0; i < 5; i++)
            {
                list.AddLast(new Node(i));
            }

            list.PrintList();
            Console.WriteLine(list.ToArray().Length);


            //LinkedList list = new LinkedList();

            //for (int i = 1; i <= 10; i++)
            //{
            //    list.AddHead(new Node(i));
            //}

            //list.PrintList();

            //Console.WriteLine($"Poped: {list.Pop().Value}");
            //Console.WriteLine($"Poped: {list.Pop().Value}");
            //Console.WriteLine($"Poped: {list.Pop().Value}");
            //Console.WriteLine($"Poped: {list.Pop().Value}");

            //list.ReversedPrintList();
            
        }

        static void PrintNode(LinkedList list)
        {
            Node currentHead = list.Head;
            while (currentHead != null)
            {
                Console.WriteLine(currentHead.Value);
                currentHead = currentHead.Next;
            }
        }
    }
}
