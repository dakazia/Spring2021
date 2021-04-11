using System;
using System.Collections.Generic;
using System.IO;
using FileSystem;

namespace SearchEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            // может вынести в отдельный метод? with messages
            string path;
            do
            {
                Console.WriteLine(@"Please enter a correct path (for example c:\Windows):");
                // path = @"c:\Intel";
                path = Console.ReadLine();

            } while (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path) || !Directory.Exists(path));

            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor();
            IEnumerable<string> fileSystemItem = fileSystemVisitor.FileSystemScan(path);

            foreach (var item in fileSystemItem)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
