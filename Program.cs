using Laba7;
using System;
using System.Text;

namespace LaboratoryWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine
                    ("ЛАБОРАТОРНАЯ РАБОТА");
                Console.WriteLine
                    ("ЗАДАНИЯ 1-5");
                Console.WriteLine
                    ("1 - Задание 1 " +
                    "(разность половин)");
                Console.WriteLine
                    ("2 - Задание 2 " +
                    "(сумма чисел)");
                Console.WriteLine
                    ("3 - Задание 3 " +
                    "(короткая/длинная строка)");
                Console.WriteLine
                    ("4 - Задание 4 " +
                    "(чётные числа)");
                Console.WriteLine
                    ("5 - Задание 5 " +
                    "(багаж)");
                Console.WriteLine
                    ("\nЗАДАНИЯ 6-10");
                Console.WriteLine
                    ("6 - Задание 6 " +
                    "(List: удаление элемента)");
                Console.WriteLine
                    ("7 - Задание 7 " +
                    "(LinkedList: обратный порядок)");
                Console.WriteLine
                    ("8 - Задание 8 " +
                    "(HashSet: фирмы)");
                Console.WriteLine
                    ("9 - Задание 9 " +
                    "(HashSet: звонкие согласные)");
                Console.WriteLine
                    ("10 - Задание 10 " +
                    "(Dictionary: логины из файла)");
                Console.WriteLine
                    ("0 - Выход");
                Console.Write("> ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": FileTasks.Task1(); break;
                    case "2": FileTasks.Task2(); break;
                    case "3": FileTasks.Task3(); break;
                    case "4": FileTasks.Task4(); break;
                    case "5": FileTasks.Task5(); break;
                    case "6": CollectionTasks.Task6(); break;
                    case "7": CollectionTasks.Task7(); break;
                    case "8": CollectionTasks.Task8(); break;
                    case "9": CollectionTasks.Task9(); break;
                    case "10": CollectionTasks.Task10(); break;
                    case "0": exit = true; break;
                    default:
                        {
                            Console.WriteLine("Неверный ввод.");
                            Console.ReadKey(); break;
                        }
                }
            }
        }
    }
}