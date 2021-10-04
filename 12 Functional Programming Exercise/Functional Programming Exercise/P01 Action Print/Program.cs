using System;

namespace P01_Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printCollection = input
                => Console.WriteLine(string.Join(Environment.NewLine, input));

            string[] input = Console.ReadLine().Split();

            printCollection(input);
        }
    }
}
