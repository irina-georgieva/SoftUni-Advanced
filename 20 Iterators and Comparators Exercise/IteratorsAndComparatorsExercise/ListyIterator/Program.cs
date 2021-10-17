using System;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            ListyIterator<string> listy = new ListyIterator<string>();

            while (command != "END")
            {
                string[] commandArgs = command.Split();
                if (commandArgs[0] == "Create")
                {
                    listy = new ListyIterator<string>(commandArgs.Skip(1).ToArray());
                }
                else if(commandArgs[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (commandArgs[0] == "Print")
                {
                    listy.Print();
                }
                else if (commandArgs[0] == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }

                command = Console.ReadLine();
            }
        }
    }
}
