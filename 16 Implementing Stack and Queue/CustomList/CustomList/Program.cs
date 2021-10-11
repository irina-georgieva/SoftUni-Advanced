using System;
using System.Collections.Generic;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Add(10);
            list.Add(20);
            list.RemoveAt(1);
            list.Contains(10);
            list.Swap(0, 1);

        }
    }
}
