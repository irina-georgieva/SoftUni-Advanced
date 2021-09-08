using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> strStack = new Stack<char>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                strStack.Push(input[i]);
            }

            while(strStack.Count > 0)
            {
                Console.Write(strStack.Pop());
            }

            Console.WriteLine();
        }
    }
}
