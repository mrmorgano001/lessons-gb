using System;
using System.IO;

namespace FileManager
{
    public static class Functions
    {
        public static void Header()
        {
            Console.SetWindowSize(120, 30);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("┌─────────────────────────────────────────────────────FILE-MANAGER───────────────────────────────────────────────────┐");
            Console.WriteLine("│ COMMANDS:                                                                                                          │");
            Console.WriteLine("│ ls <path> - просмотр файлов каталога       cp <path1> <path2> - копирование файла (каталога)                       │");
            Console.WriteLine("│                                                                                                                    │");
            Console.WriteLine("│ rm <path> - удаление каталога(рекурсивно)/файла    file <file> - вывод информации о файле                          │");
            Console.WriteLine("│ введите quit для выхода                                                                                            │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
            
        }
        public static void DirectoryViewer(string currentDirectory)
        {
            Console.Clear();
            Header();
            try
            {
                var viewDirectories = Directory.GetDirectories(currentDirectory);
                foreach (var directoryName in viewDirectories)
                {
                    var currentDir = directoryName;
                    Console.WriteLine("──" + directoryName);
                    FileViewer(currentDir);
                }
                FileManagerr.Properties.Settings.Default.lastDirectory = currentDirectory;
                FileManagerr.Properties.Settings.Default.Save();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Такой директории не найдено.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Недопустимые знаки.");
            } 
        }

        private static void FileViewer(string targetDirectory)
        { 
            try
            {
                var getFiles = Directory.GetFiles(targetDirectory);
                foreach (var filename in getFiles)
                {
                    Console.WriteLine("   └──" + filename);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("   └──" + "Отказано в доступе");
            }
            
        }
        public static void KeyHandler(string command)
        {
            var subs = command.Split(' ');
            if (command != String.Empty)
            {
                try
                {
                    if (subs[0].ToUpper() == "LS")
                        DirectoryViewer(subs[1]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Header();
                    Console.WriteLine("Укажите директорию.");
                }
                
                if (subs[0].ToUpper() == "CP")
                    CopyFile(subs[1], subs[2]);
                if (subs[0].ToUpper() == "RM")
                    DeleteFile(subs[1]);
                if (subs[0].ToUpper() == "FILE")
                    FileInformation(subs[1]);
            }
            else
            {
                Console.WriteLine("Команда не может быть пустая.");
            }

        }
        private static void CopyFile(string firstCatalog, string secondCatalog)
        {
            File.Copy(firstCatalog, secondCatalog);
        }
        private static void DeleteFile(string filename)
        {
            File.Delete(filename);
        }

        private static void FileInformation(string filename)
        {
            var fileInfo = new FileInfo(filename);
            var size = fileInfo.Length;
            var path = fileInfo.DirectoryName;
            var extension = fileInfo.Extension;
            var creationTimeDate = fileInfo.CreationTime.Date;
            var lastWriteTime = fileInfo.LastWriteTimeUtc.Date;
            Console.WriteLine("Размер: " + size + " байт");
            Console.WriteLine("Размещение: " + path);
            Console.WriteLine("Расширение: " + extension);
            Console.WriteLine("Дата создания: " + creationTimeDate);
            Console.WriteLine("Дата последнего изменения: " + lastWriteTime);
        }
    }
}