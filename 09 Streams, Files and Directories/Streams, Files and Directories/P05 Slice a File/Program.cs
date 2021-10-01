﻿using System;
using System.IO;

namespace P05_Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream fileStream = new FileStream("input.txt", FileMode.OpenOrCreate);

            var data = new byte[fileStream.Length];
            

            var bytesPerFile = (int)Math.Ceiling(fileStream.Length / 4.0);

            for (int i = 1; i <= 4; i++)
            {
                var buffer = new byte[bytesPerFile];
                fileStream.Read(buffer);

                using FileStream writer = new FileStream($"Part-{i}.txt", FileMode.OpenOrCreate);
                writer.Write(buffer);
            }
        }
    }
}
