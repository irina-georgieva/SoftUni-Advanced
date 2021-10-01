using System;
using System.IO;


namespace P01_Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader sr = new StreamReader(@"E:\SoftUni\C# Path\Advanced Sep 2021 C#\SoftUni-Advanced\09 Streams, Files and Directories\Temp\input.txt");
            using StreamWriter sw = new StreamWriter(@"E:\SoftUni\C# Path\Advanced Sep 2021 C#\SoftUni-Advanced\09 Streams, Files and Directories\Temp\P01output.txt");
            int rowNumber = 0;

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (rowNumber %2 == 1)
                {
                    sw.WriteLine(line);
                }

                rowNumber++;

            }
        }
    }
}
