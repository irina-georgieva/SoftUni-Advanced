using System;
using System.Collections.Generic;

namespace P09_TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            Stack<string> history = new Stack<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int command = int.Parse(input[0]);

                if (command == 1)
                {
                    text += input[1];
                    history.Push(text);
                }
                else if (command == 2)
                {
                    int number = int.Parse(input[1]);
                    text = text.Remove(text.Length - number);
                    history.Push(text);
                }
                else if (command == 3)
                {
                    int index = int.Parse(input[1]);
                    if (text.Length >= index)
                    {
                        Console.WriteLine(text[index-1]);
                    }
                }
                else if (command == 4)
                {
                    if(history.Count > 1)
                    {
                        history.Pop();
                        text = history.Peek();
                    }
                    else if(history.Count == 1)
                    {
                        history.Pop();
                        text = string.Empty;
                    }
                }
            }
        }
    }
}
