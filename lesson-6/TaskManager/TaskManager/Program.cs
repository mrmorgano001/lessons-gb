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
                int choice;
                if (Int32.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                {
                    case 1:
                    {
                        var processes = Process.GetProcesses();
                        var length = processes.Length;
                        Console.WriteLine("Введите ID процесса");
                        int id;
                        if (Int32.TryParse(Console.ReadLine(), out id))
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
                        Console.WriteLine("Введите имя процесса: ");
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