using System;

namespace FileManager
{
    static class Program
    {
        static void Main(string[] args)
        {
            Functions.DeserializeConf();
            string currentDirectory;
            var command = string.Empty;
            currentDirectory = FileManagerr.Properties.Settings.Default.lastDirectory ?? @"C:\"; 
            Functions.DirectoryViewer(currentDirectory,0);
            while (command.ToUpper() != "QUIT" && command.ToUpper() != "Q" && command.ToUpper() != "EXIT")
            {
                Console.Write(": ");
                command = Console.ReadLine();
                Functions.CommandHandler(command);
            }
            Functions.SerializeConf();
        }
    }
}