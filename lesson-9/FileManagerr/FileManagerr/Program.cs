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
            if (FileManagerr.Properties.Settings.Default.lastDirectory != null)
            {
                currentDirectory = FileManagerr.Properties.Settings.Default.lastDirectory;
            }
            else
                currentDirectory = @"C:\"; 
            Functions.DirectoryViewer(currentDirectory);
            Console.WriteLine("Введите команду: ");

            while (command.ToUpper() != "QUIT")
            {
                command = Console.ReadLine();
                Functions.KeyHandler(command);
            }
        }
    }
}