using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    public static class Functions
    {
        public static void Header()
        {
            Console.SetWindowSize(150, 30);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("┌─────────────────────────────────────────────────────FILE-MANAGER───────────────────────────────────────────────────┐");
            Console.WriteLine("│ COMMANDS:                                                                                                          │");
            Console.WriteLine("│ ls <path> - Просмотр файлов каталога                             cp <path1> <path2> - Копирование файла (каталога) │");
            Console.WriteLine("│                                                                                                                    │");
            Console.WriteLine("│ dir <path> - Информация о катаголе                                                                                 │");
            Console.WriteLine("│                                                                                                                    │");
            Console.WriteLine("│ rm <path> - Удаление каталога(рекурсивно)/файла                             file <file> - Вывод информации о файле │");
            Console.WriteLine("│                                                                                                                    │");
            Console.WriteLine("│ Введите quit, q, exit для выхода                                                                                   │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
            
        }
        public static void DirectoryViewer(string currentDirectory)
        {
            try
            {
                var viewDirectories = Directory.GetDirectories(currentDirectory);
                foreach (var directoryName in viewDirectories)
                { 
                    var currentDir = directoryName;
                    Console.WriteLine("──" + directoryName);
                    FileViewer(currentDir);
                    try
                    {
                        Console.Write("└──");
                        DirectoryViewer(directoryName);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Отказано в доступе");
                    }
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

        public static void Paginator(string line)
        {
            List<string> lines = new List<string>();
            lines.Add(line);
        }

        private static void FileViewer(string targetDirectory)
        { 
            try
            {
                var getFiles = Directory.GetFiles(targetDirectory);
                foreach (var filename in getFiles)
                {
                    Console.WriteLine("└──────" + filename);
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
                {
                    DeleteFile(subs[1]);
                    //DeleteDirectory(subs[1]);
                }
                if (subs[0].ToUpper() == "FILE")
                    FileInformation(subs[1]);
                if (subs[0].ToUpper() == "DIR")
                    DirectoryInfo(subs[1]);
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

        private static void DirectoryInfo(string directoryPath)
        {
            var creationTime = Directory.GetCreationTime(directoryPath);
            var lastWriteTime = Directory.GetLastWriteTime(directoryPath);
            var filesCount = Directory.GetFiles(directoryPath).Length;
            Console.WriteLine($"Дата создания директории: {creationTime}");
            Console.WriteLine($"Дата последней записи: {lastWriteTime}");
            Console.WriteLine($"Количество файлов: {filesCount}");
        }
        private static void DeleteDirectory(string directoryPath)
        {
            Directory.Delete(directoryPath);
        }
        private static void DeleteFile(string filename)
        {
            try
            {
                Console.WriteLine($"Вы уверены что хотите удалить {filename}? Yes/No");
                var choose = Console.ReadLine();
                if (choose == "Y" || choose == "Yes")
                {
                    File.Delete(filename);
                    Console.WriteLine($"{filename} успешно удален!");
                }
                else
                    Console.WriteLine("Удаление файла отменено.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Вы не можете удалить этот файл");
            }
        }

        private static void FileInformation(string filename)
        {
            try
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
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("");
            }
        }
    }
}