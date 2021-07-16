using System;
using System.IO;

namespace FileManager
{
    static class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory;
            var command = string.Empty;
            Functions.Header();
            currentDirectory = FileManagerr.Properties.Settings.Default.lastDirectory ?? @"C:\"; 
            Functions.DirectoryViewer(currentDirectory);
            while (command.ToUpper() != "QUIT")
            {
                Console.WriteLine("COMMAND: ");
                command = Console.ReadLine();
                Functions.KeyHandler(command);
            }
        }
    }
}