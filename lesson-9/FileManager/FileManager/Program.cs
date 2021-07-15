using System;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;
            Functions.Header(); 
            var currentDirectory = @"C:\";
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