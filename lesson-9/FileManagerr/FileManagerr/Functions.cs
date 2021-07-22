using System;
using System.IO;
using System.Linq;

namespace FileManager
{
    public static class Functions
    {
        /// <summary>
        /// Метод построения верхней "шапки"
        /// </summary>
        private static void Header()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(121, 30);
            Console.WriteLine("┌─────────────────────────────────────────────────────FILE-MANAGER─────────────────────────────────────────────────────┐");
            Console.WriteLine("│ COMMANDS:                                                                                                            │");
            Console.WriteLine("│ ls <path> - Просмотр файлов каталога                                cp <path1> <path2> - Копирование файла (каталога)│");
            Console.WriteLine("│                                                                                                                      │");
            Console.WriteLine("│ dir <path> - Информация о катаголе                                  clear - для очистки консоли                      │");
            Console.WriteLine("│                                                                                                                      │");
            Console.WriteLine("│ rm <path> - Удаление каталога(рекурсивно)/файла                     file <file> - Вывод информации о файле           │");
            Console.WriteLine("│                                                                                                                      │");
            Console.WriteLine("│ Введите quit, q, exit для выхода                                                                                     │");
            Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
        }
        /// <summary>
        /// Метод сохранения конфигурационного файла "config.cfg"
        /// </summary>
        public static void SerializeConf()
        {
            var filename = "config.cfg";
            var lastDir = FileManagerr.Properties.Settings.Default.lastDirectory;
            var pageCount = FileManagerr.Properties.Settings.Default.pageCount;
            var confString = new[] {"lastDirectory = " + lastDir,"pageCount = " + pageCount.ToString()};
            File.WriteAllLines(filename,confString);
        }
        /// <summary>
        /// Метод открытия конфигурационного файла "config.cfg" и применения изменения согласно файлу
        /// </summary>
        public static void DeserializeConf()
        {
            try
            {
                var filename = "config.cfg";
                var confString = File.ReadAllLines(filename);
                var lastDir = confString[0].Split(' ');
                var pageCount = confString[1].Split(' ');
                FileManagerr.Properties.Settings.Default.lastDirectory = lastDir[2];
                FileManagerr.Properties.Settings.Default.pageCount = int.Parse(pageCount[2]);
            }
            catch (FileNotFoundException) //обработка исключения отсутствия файла
            {
                SerializeConf();
            }
            

        }
        /// <summary>
        /// Просмотр дерева каталогов
        /// </summary>
        /// <param name="currentDirectory"></param>
        /// <param name="page"></param>
        public static void DirectoryViewer(string currentDirectory,int page)
        {
            Header();
            var pageCount = FileManagerr.Properties.Settings.Default.pageCount;
            try
            {
                var viewDirectories = Directory.GetDirectories(currentDirectory).ToList();
                var result = viewDirectories.Skip(page * pageCount).Take(pageCount);
                foreach (var directoryName in result)
                {
                    Console.WriteLine("──" + directoryName);
                    FileViewer(directoryName);
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
        /// <summary>
        /// Просмотр файлов каталога
        /// </summary>
        /// <param name="targetDirectory"></param>
        private static void FileViewer(string targetDirectory)
        { 
            try
            {
                var getFiles = Directory.GetFiles(targetDirectory);
                foreach (var filename in getFiles)
                {
                    Console.WriteLine("└────" + filename);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("   └──" + "Отказано в доступе");
            }
            
        }
        /// <summary>
        /// Обработчик консольных комманд
        /// </summary>
        /// <param name="command"></param>
        public static void CommandHandler(string command)
        {
            var switchArray = command.Split(' ');
            if (switchArray[0].ToUpper() == "LS") //Обработка команды перехода в директорию
            {
                Console.Clear();
                if (switchArray.Length < 2)
                {
                    Console.WriteLine("Введите путь");
                }
                else
                {
                    if (switchArray.Length == 2)
                    {
                        DirectoryViewer(switchArray[1],0);
                    }
                    else
                    {
                        if (switchArray.Length >= 3)
                        {
                            if (switchArray[2].ToUpper() == "-P") //Обработка параметра постраничного вывода
                            {
                                try
                                {
                                    DirectoryViewer(switchArray[1], int.Parse(switchArray[3]));
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("Введите верный параметр");
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("Введите число");
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Введите число");
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Введите корректный номер страницы");
                                }

                            } else Console.WriteLine("Введите корректный параметр");
                        }
                    }
                }
            }

            if (switchArray[0].ToUpper() == "CP") //Обработка команды копирования файла/каталога
            {
                try
                {
                    if (switchArray.Length == 3)
                    {
                        if (Directory.Exists(switchArray[1]) && Directory.Exists(switchArray[2])) //Проверка на наличие каталога, иначе вызов метода работы с файлом
                        {
                            CopyCatalog(switchArray[1], switchArray[2]);
                        }
                        else
                        {
                            
                            CopyFile(switchArray[1], switchArray[2]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Укажите начальный и конечный файл/папку");
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл или папка не найдены");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Введите имя папки/файла");
                }
            }

            if (switchArray[0].ToUpper() == "FILE") //обработка команды вывода информации о файле
            {
                try
                {
                    FileInformation(switchArray[1]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Введите корректное имя файла");
                }
            }

            if (switchArray[0].ToUpper() == "DIR") //Обработка команды вывода информации о директории
            {
                try
                {
                    DirectoryInfo(switchArray[1]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Введите имя папки");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Введите имя папки");
                }
            }

            if (switchArray[0].ToUpper() == "CLEAR") //Обработка команды очистки консоли
            {
                Console.Clear();
                Header();
            }

            if (switchArray[0].ToUpper() == "RM") // Обработка команды удаления
            {
                if (File.Exists(switchArray[1]))
                {
                    DeleteFile(switchArray[1]);
                }
                else
                {
                    DeleteDirectory(switchArray[1]);
                }
            }
        }
        /// <summary>
        /// Метод копирования файла
        /// </summary>
        /// <param name="firstFile"></param>
        /// <param name="secondFile"></param>
        private static void CopyFile(string firstFile, string secondFile)
        {
            File.Copy(firstFile, secondFile);
            Console.WriteLine($"Файл {firstFile} успешно скопирован");
        }
        /// <summary>
        /// Метод копирования каталога
        /// </summary>
        /// <param name="firstCatalog"></param>
        /// <param name="secondCatalog"></param>
        private static void CopyCatalog(string firstCatalog, string secondCatalog)
        {
            foreach (var directory in Directory.GetDirectories(firstCatalog,"*",SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(directory.Replace(firstCatalog, secondCatalog));
            }

            foreach (var file in Directory.GetFiles(firstCatalog, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(file, file.Replace(firstCatalog, secondCatalog),true);
            }
        }
        /// <summary>
        /// Вывод информации о директории
        /// </summary>
        /// <param name="directoryPath"></param>
        private static void DirectoryInfo(string directoryPath)
        {
            try
            {
                var creationTime = Directory.GetCreationTime(directoryPath);
                var lastWriteTime = Directory.GetLastWriteTime(directoryPath);
                var filesCount = Directory.GetFiles(directoryPath).Length;
                var directoriesCount = Directory.GetDirectories(directoryPath).Length;
                Console.WriteLine($"Дата создания директории: {creationTime}");
                Console.WriteLine($"Дата последней записи: {lastWriteTime}");
                Console.WriteLine($"Количество файлов: {filesCount}");
                Console.WriteLine($"Количество папок: {directoriesCount}");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Директория не найдена");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Введите корректное имя папки");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Имя папки не может быть пустое");
            }
        }
        /// <summary>
        /// Удаление директории (рекурсивно)
        /// </summary>
        /// <param name="directoryPath"></param>
        private static void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                try
                {
                    Console.WriteLine($"Вы уверены что хотите удалить {directoryPath} Yes/No? В ней могут находиться файлы!");
                    var choose = Console.ReadLine();
                    if (choose != null && (choose.ToUpper() == "Y" || choose.ToUpper() == "YES"))
                    { 
                        Directory.Delete(directoryPath,true);
                        Console.WriteLine($"Каталог {directoryPath} успешно удален!");
                    } else Console.WriteLine("Удаление каталога отменено.");
               
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Вы не можете удалить этот каталог"); 
                } 
            }
            else
            {
                Console.WriteLine("Такой директории не существует.");
            }
            
        }
        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="filename"></param>
        private static void DeleteFile(string filename)
        {
            try
            {
                Console.WriteLine($"Вы уверены что хотите удалить {filename}? Yes/No");
                var choose = Console.ReadLine();
                if (choose != null && (choose.ToUpper() == "Y" || choose.ToUpper() == "YES"))
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
        /// <summary>
        /// Вывод информации о файле
        /// </summary>
        /// <param name="filename"></param>
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
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }
        }
    }
}