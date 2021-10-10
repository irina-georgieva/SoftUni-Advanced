
using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new DoublyLinkedList();
            list.AddFirst(4);
            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddFirst(0);
            list.AddLast(100);

            list.RemoveFirst();
            list.RemoveLast();
            list.AddLast(5);

            Console.WriteLine(string.Join("-", list.ToArray()));

            list.ForEach(x => Console.WriteLine("--" + x));
        }
    }
}

