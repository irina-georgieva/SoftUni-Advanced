using System;
using System.IO;

namespace P06_Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"E:\SoftUni\C# Path\Advanced Sep 2021 C#\SoftUni-Advanced\09 Streams, Files and Directories\Temp";
            var totalLength = GetTotalLength(directoryPath);

            Console.WriteLine(totalLength);
        }

        static long GetTotalLength(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            long totalLength = 0;

            foreach (var file in files)
            {
                totalLength += new FileInfo(file).Length;
            }

            var subDirectories = Directory.GetDirectories(directoryPath);
            foreach (var directory in subDirectories)
            {
                totalLength += GetTotalLength(directory);
            }

            return totalLength;
        }
    }
}
