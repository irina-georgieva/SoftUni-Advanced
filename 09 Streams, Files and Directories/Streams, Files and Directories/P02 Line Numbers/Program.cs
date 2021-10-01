using System;
using System.IO;

namespace P02_Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"E:\SoftUni\C# Path\Advanced Sep 2021 C#\SoftUni-Advanced\09 Streams, Files and Directories\Temp\input.txt");
            using StreamWriter sw = new StreamWriter(@"E:\SoftUni\C# Path\Advanced Sep 2021 C#\SoftUni-Advanced\09 Streams, Files and Directories\Temp\P02output.txt");

            int rowNumber = 1;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                sw.WriteLine($"{rowNumber}. {line}");
                rowNumber++;
            }
        }
    }
}
