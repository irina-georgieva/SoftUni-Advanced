using System;
using System.Collections.Generic;

namespace P08_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> brackets = new Stack<char>();
            bool isBalanced = true;

            // {[()[]]} (()))

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '[' || input[i] == '(')
                {
                    brackets.Push(input[i]);
                }
                else
                {
                    if (input[i] == '}' && brackets.Count > 0 && brackets.Peek() == '{')
                    {
                        brackets.Pop();
                    }
                    else if (input[i] == ']' && brackets.Count > 0 && brackets.Peek() == '[')
                    {
                        brackets.Pop();
                    }
                    else if (input[i] == ')' && brackets.Count > 0 && brackets.Peek() == '(')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (brackets.Count == 0 && isBalanced == true)
            {
                Console.WriteLine("YES");
            }
        }
    }
}
