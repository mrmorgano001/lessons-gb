using System;

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
            while (command.ToUpper() != "QUIT" && command.ToUpper() != "Q" && command.ToUpper() != "EXIT")
            {
                Console.Write(": ");
                command = Console.ReadLine();
                Functions.KeyHandler(command);
            }
        }
    }
}