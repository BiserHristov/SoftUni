using System;

namespace _03.ExtractFile
{
    class ExtractFile
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
           
            int endIndex = line.LastIndexOf('.');
            int startIndex = line.LastIndexOf('\\', endIndex);
            string fileName = line.Substring(startIndex + 1, endIndex - startIndex-1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {line.Substring(endIndex+1)}");

        }
    }
}
