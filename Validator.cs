
namespace Laba7
{
        public static class InputValidator
        {
            public static int GetPositiveInt(string prompt)
            {
                int result;
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out result) 
                    && result > 0)
                    {
                        return result;
                    }
                    Console.WriteLine
                    ("Ошибка: " +
                    "введите целое положительное число.");
                }
            }

            public static int GetEvenPositiveInt(string prompt)
            {
                int result;
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out result) &&
                    result > 0 &&
                    result % 2 == 0)
                    {
                        return result;
                    }
                    Console.WriteLine
                    ("Ошибка:" +
                    " введите чётное положительное число.");
                }
            }

            public static double GetNonNegativeDouble
            (string prompt)
            {
                double result;
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out result) &&
                        result >= 0)
                    {
                        return result;
                    }
                    Console.WriteLine
                    ("Ошибка: введите неотрицательное число.");
                }
            }

            public static string GetNonEmptyString
            (string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        return input;
                    }
                    Console.WriteLine
                    ("Ошибка: строка не может быть пустой.");
                }
            }

            
            public static string GetExistingFilePath
            (string prompt)
            {
                while (true)
                {
                    string path = GetNonEmptyString(prompt);
                    if (File.Exists(path))
                    {
                        return path;
                    }
                    Console.WriteLine("Ошибка: " +
                        "файл не существует. " +
                        "Укажите существующий файл.");
                }
            }
        }
    
}