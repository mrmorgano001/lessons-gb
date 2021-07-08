using System;
using System.Diagnostics;

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
                Console.WriteLine("4. Закрыть программу");
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    {
                        var processes = Process.GetProcesses();
                        var length = processes.Length;
                        Console.WriteLine("Введите ID процесса");
                        var id = Convert.ToInt32(Console.ReadLine());
                        var success = false;
                        foreach (var i in processes)
                        {
                            if (i.Id != id) continue;
                            i.Kill();
                            success = true;
                        }
                        Console.WriteLine(success ? $"Процесс №{id} успешно завершен!" : "Такого процесса не найдено!");
                        break;
                    }
                    case 2:
                    {
                        var processes = Process.GetProcesses();
                        Console.WriteLine("Введите имя процесса: ");
                        var name = Console.ReadLine();
                        var success = false;
                        foreach (var i in processes)
                        {
                            if (i.ProcessName != name) continue;
                            i.Kill();
                            success = true;
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
                        Console.WriteLine("Выход...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такой команды нет. Попробуйте еще раз.");
                        break;
                }
            } while (true);
                
        }
    }
}