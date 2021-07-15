using System;
using System.IO;

namespace FileManager
{
    public class Functions
    {
        public static void Header()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("┌─────────────────────────────────────────────────────FILE-MANAGER───────────────────────────────────────────────────┐");
            Console.WriteLine("│ COMMANDS:                                                                                                          │");
            Console.WriteLine("│ ls <path> - просмотр файлов каталога       cp <path1> <path2> - копирование файла (каталога)                       │");
            Console.WriteLine("│                                                                                                                    │");
            Console.WriteLine("│ rm <path> - удаление каталога(рекурсивно)/файла    file <file> - вывод информации о файле                          │");
            Console.WriteLine("│ введите quitя выхода                                                                                               │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
            Console.SetWindowSize(120,30);
        }
        public static void DirectoryViewer(string currentDirectory)
        {
            Console.Clear();
            Header();
            var viewDirectories = Directory.GetDirectories(currentDirectory);
            foreach (var directoryName in viewDirectories)
            {
                var currentDir = directoryName; 
                Console.WriteLine("──" + directoryName);
            }
        }

        public static void FileViewer(string targetDirectory)
        {
            var getFiles = Directory.GetFiles(targetDirectory);
            foreach (var filename in getFiles)
            {
                Console.WriteLine("   └──" + filename);
            }
        }
        public static void KeyHandler(string command)
        {
            string[] subs = command.Split(" ");
            if (command != String.Empty)
            {
                if (subs[0].ToUpper() == "LS")
                    DirectoryViewer(subs[1]);
                if (subs[0].ToUpper() == "CP")
                    CopyFile(subs[1], subs[2]);
                if (subs[0].ToUpper() == "RM")
                    DeleteFile(subs[1]);
            }
            else
            {
                Console.WriteLine("Команда не может быть пустая.");
            }

        }
        private static void CopyFile(string firstCatalog, string secondCatalog)
        {
            File.Copy(firstCatalog,secondCatalog);
        }
        private static void DeleteFile(string filename)
        {
            File.Delete(filename);
        }
    }
}