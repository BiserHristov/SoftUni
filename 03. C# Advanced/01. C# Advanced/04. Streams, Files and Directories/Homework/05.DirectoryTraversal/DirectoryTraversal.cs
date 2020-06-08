using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    public class DirectoryTraversal
    {
        public static void Main()
        {
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);
            Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();

            foreach (var filePath in files)
            {
                string fileName = filePath
                    .Split('\\', StringSplitOptions.RemoveEmptyEntries)
                    .Last();

                string fileExt = fileName
                .Split('.', StringSplitOptions.RemoveEmptyEntries)
                .Last();

                FileInfo fileInfo = new FileInfo(fileName);

                if (!dict.ContainsKey(fileExt))
                {
                    dict.Add(fileExt, new Dictionary<string, double>());
                }

                if (!dict[fileExt].ContainsKey(fileName))
                {
                    dict[fileExt].Add(fileName, fileInfo.Length);
                }

            }

            foreach (var edp in dict.OrderByDescending(x => x.Value.Count).ThenBy(n => n.Key))
            {
                Console.WriteLine($".{edp.Key }");
                foreach (var nsp in edp.Value.OrderBy(x => x.Value))
                {
                    Console.WriteLine($"--{nsp.Key}.{edp.Key} - {(nsp.Value / 1024):F3}kb");
                }

            }

        }
    }
}
