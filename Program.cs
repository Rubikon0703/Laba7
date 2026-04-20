
using System.Text;

namespace Laba7
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
                Console.WriteLine(" ЛАБОРАТОРНАЯ РАБОТА №7 ");
                Console.WriteLine("ЗАДАНИЯ 1-5 (ФАЙЛЫ)");
                Console.WriteLine
                    ("1 - Задание 1 (разность половин)");
                Console.WriteLine
                    ("2 - Задание 2 (сумма чисел)");
                Console.WriteLine
                    ("3 - Задание 3 (короткая/длинная строка)");
                Console.WriteLine
                    ("4 - Задание 4 (чётные числа)");
                Console.WriteLine
                    ("5 - Задание 5 (багаж)");
                Console.WriteLine
                    ("\nЗАДАНИЯ 6-10 (КОЛЛЕКЦИИ)");
                Console.WriteLine
                    ("6 - Задание 6 (List: удаление элемента)");
                Console.WriteLine
                    ("7 - Задание 7 (LinkedList: обратный порядок)");
                Console.WriteLine
                    ("8 - Задание 8 (HashSet: фирмы)");
                Console.WriteLine
                    ("9 - Задание 9 (HashSet: звонкие согласные)");
                Console.WriteLine
                    ("10 - Задание 10 (Dictionary: логины)");
                Console.WriteLine
                    ("0 - Выход");
                Console.Write("> ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": RunTask1(); break;
                    case "2": RunTask2(); break;
                    case "3": RunTask3(); break;
                    case "4": RunTask4(); break;
                    case "5": RunTask5(); break;
                    case "6": CollectionTasks.Task6(); break;
                    case "7": CollectionTasks.Task7(); break;
                    case "8": CollectionTasks.Task8(); break;
                    case "9": CollectionTasks.Task9(); break;
                    case "10": CollectionTasks.Task10(); break;
                    case "0": exit = true; break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void RunTask1()
        {
            string fileName = 
                InputValidator.GetExistingFilePath(
                "Укажите путь к текстовому файлу " +
                "(числа по одному): ");
            try
            {
                int result = FileTasks.Task1(fileName);
                Console.WriteLine(
                    $"Разность суммы первой и " +
                    $"второй половин = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }

        static void RunTask2()
        {
            string fileName = 
                InputValidator.GetExistingFilePath(
                    "Укажите путь к " +
                    "текстовому файлу (несколько чисел): ");
            try
            {
                int sum = FileTasks.Task2(fileName);
                Console.WriteLine($"Сумма всех чисел = {sum}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }

        static void RunTask3()
        {
            string inputFile = 
                InputValidator.GetExistingFilePath(
                "Укажите путь к входному текстовому файлу: ");
            string outputFile = 
                InputValidator.GetNonEmptyString(
                "Укажите имя выходного файла: ");
            try
            {
                FileTasks.Task3(inputFile, outputFile);
                Console.WriteLine
                    ($"Результат записан в {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }

        static void RunTask4()
        {
            string inputFile = 
                InputValidator.GetExistingFilePath(
                "Укажите путь к входному бинарному файлу: ");
            string outputFile = 
                InputValidator.GetNonEmptyString(
                "Укажите имя выходного бинарного файла: ");
            try
            {
                FileTasks.Task4(inputFile, outputFile);
                Console.WriteLine(
                    $"Чётные числа скопированы в {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }

        static void RunTask5()
        {
            string fileName = 
                InputValidator.GetExistingFilePath(
                "Укажите путь к XML-файлу с данными багажа: ");
            double m = 
                InputValidator.GetNonNegativeDouble(
                "Введите допустимое отклонение m (кг): ");
            try
            {
                FileTasks.Task5(fileName, m);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}