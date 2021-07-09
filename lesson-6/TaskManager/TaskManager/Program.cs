using System;
using System.Diagnostics;
using System.IO;
using static System.Int32;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите вариант из меню: ");
            do
            {
                Console.WriteLine("1. Завершить процесс по ID");
                Console.WriteLine("2. Завершить процесс по имени");
                Console.WriteLine("3. Вывести все процессы на экран");
                Console.WriteLine("4. Выгрузить список процессов в файл");
                Console.WriteLine("5. Закрыть программу");
                if (TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                {
                    case 1:
                    {
                        var processes = Process.GetProcesses();
                        var length = processes.Length;
                        Console.Write("Введите ID процесса: ");
                        if (TryParse(Console.ReadLine(), out var id))
                        {
                            var success = false;
                            try
                            {
                                foreach (var i in processes)
                                {
                                    if (i.Id != id) continue;
                                    i.Kill();
                                    success = true;
                                }
                                Console.WriteLine(success ? $"Процесс №{id} успешно завершен!" : "Такого процесса не найдено!");
                            }
                            catch
                            {
                                Console.WriteLine("Что-то пошло не так...Либо этот процесс нельзя завершить, выберите другой.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Необходимо ввести ID, а не имя.");
                        }
                        break;
                    }
                    case 2:
                    {
                        var processes = Process.GetProcesses();
                        Console.Write("Введите имя процесса: ");
                        var name = Console.ReadLine();
                        var success = false;
                        try
                        {
                            foreach (var i in processes)
                            {
                                if (i.ProcessName != name) continue;
                                i.Kill();
                                success = true;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Что-то пошло не так...Либо этот процесс нельзя завершить, выберите другой.");
                        }
                        Console.WriteLine(success ? $"Процесс {name} успешно завершен!":"Такого процесса не найдено!");
                        break;
                    }
                    case 3:
                    {
                        var processes = Process.GetProcesses();
                        foreach (var i in processes)
                        {
                            Console.WriteLine("Name: " + i + " ID: " + i.Id);
                        }
                        break;
                    }
                    case 4:
                    {
                        var filename = "process_list.txt";
                        var processes = Process.GetProcesses();
                        File.WriteAllText(filename,string.Empty);
                        foreach (var i in processes)
                        {
                            File.AppendAllText(filename, Environment.NewLine + i.ToString() + " ID: " + i.Id);
                        }
                        break;
                    }
                    case 5:
                        Console.WriteLine("Выход...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такой команды нет. Попробуйте еще раз.");
                        break; 
                } 
                }
                else
                {
                    Console.WriteLine("Введите корректную цифру меню.");
                }
                
            } while (true);
                
        }
    }
}
