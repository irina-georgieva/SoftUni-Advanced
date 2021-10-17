using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commandArgs[0] == "Push")
                {
                    stack.Push(commandArgs.Skip(1)
                        .Select(e => e.Split(",").First()).ToArray());
                }

                else if (commandArgs[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException ae)
                    {

                        Console.WriteLine(ae.Message);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
