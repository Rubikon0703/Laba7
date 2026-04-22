using Laba7;
using System.Text;
using System.Xml.Serialization;

namespace LaboratoryWork7
{
public static class FileTasks
{
    
    public static void Task1()
    {
        Console.WriteLine(
            "\nЗадание 1: разность половин ");
        string path;
        while (true)
        {
            path = InputValidator.GetNonEmptyString(
                "Укажите путь к файлу (или 0 для выхода): ");
                if (path == "0")
                {
                    return;
                }
            if (File.Exists(path)) break;
                {
                    Console.WriteLine(
                "Файл не существует. Попробуйте снова.");
                }
        }
        int count = InputValidator.GetEvenPositiveInt(
            "Введите количество чисел (чётное): ");
        FillTextFileSingle(path, count);
        SolveTask1(path);
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    private static void FillTextFileSingle
            (string path, int count)
    {
        Random rnd = new Random();
            using (StreamWriter sw = new StreamWriter(path))
                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(rnd.Next(-100, 101));
                }
        Console.WriteLine(
            $"Файл {path} заполнен {count} числами.");
    }

    private static void SolveTask1(string path)
    {
        List<int> numbers = new List<int>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                { if (int.TryParse(line, out int num))
                    {
                        numbers.Add(num);
                    }
                }
            }   
            if (numbers.Count % 2 != 0)
            {
                throw new InvalidOperationException(
                "Количество элементов файла нечётно.");
            }
        int half = numbers.Count / 2;
        int sumFirst = 0, sumSecond = 0;
            for (int i = 0; i < half; i++)
            {
                sumFirst += numbers[i];
            }
            for (int i = half; i < numbers.Count; i++)
            {
                sumSecond += numbers[i];
            }
        Console.WriteLine(
            $"Разность суммы первой и второй половин = " +
            $"{sumFirst - sumSecond}");
    }

    public static void Task2()
    {
        Console.WriteLine("\nЗадание 2: сумма чисел");
        string path;
        while (true)
        {
            path = InputValidator.GetNonEmptyString(
                "Укажите путь к файлу (или 0 для выхода): ");
                if (path == "0")
                {
                    return;
                }
                if (File.Exists(path))
                {
                    break;
                }
            Console.WriteLine(
                "Файл не существует. Попробуйте снова.");
        }
        int lines = InputValidator.GetPositiveInt(
            "Введите количество строк: ");
        int maxNum = InputValidator.GetPositiveInt(
            "Введите максимум чисел в строке: ");
        FillTextFileMultiple(path, lines, maxNum);
        SolveTask2(path);
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    private static void FillTextFileMultiple(
        string path, int lines, int maxNum)
    {
        Random rnd = new Random();
        using (StreamWriter sw = new StreamWriter(path))
        {
            for (int i = 0; i < lines; i++)
            {
                int count = rnd.Next(1, maxNum + 1);
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < count; j++)
                {
                    sb.Append(rnd.Next(-50, 51));
                        if (j < count - 1)
                        {
                            sb.Append(' ');
                        }
                }
                sw.WriteLine(sb.ToString());
            }
        }
        Console.WriteLine($"Файл {path} заполнен.");
    }

    private static void SolveTask2(string path)
    {
        int totalSum = 0;
        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                    string[] parts = line.Split(
                    new char[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);
                    foreach (string part in parts)
                    {
                        if (int.TryParse(part, out int num))
                        {
                            totalSum += num;
                        }
                    }
            }
        }
        Console.WriteLine($"Сумма всех чисел = {totalSum}");
    }

  
    public static void Task3()
    {
        Console.WriteLine(
            "\nЗадание 3: самая короткая и " +
            "длинная строки");
        string inputFile;
        while (true)
        {
            inputFile = InputValidator.GetNonEmptyString(
                "Укажите путь к входному файлу " +
                "(или 0 для выхода): ");
            if (inputFile == "0")
            {
                return;
            }
            if (File.Exists(inputFile))
            {
                break;
            }
            Console.WriteLine(
                "Файл не существует. Попробуйте снова.");
        }
        string outputFile = InputValidator.GetNonEmptyString(
            "Укажите имя выходного файла: ");
        SolveTask3(inputFile, outputFile);
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    private static void SolveTask3(
        string inputFile, string outputFile)
    {
        List<string> lines = new List<string>();
        using (StreamReader sr = new StreamReader(inputFile))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        if (lines.Count == 0)
        {
            throw new InvalidOperationException("Файл пуст.");
        }
        string shortest = lines[0];
        string longest = lines[0];
        for (int i = 1; i < lines.Count; i++)
        {
            if (lines[i].Length < shortest.Length)
            {
                shortest = lines[i];
            }
            if (lines[i].Length > longest.Length)
            {
                    longest = lines[i]; 
            }
        }
        using (StreamWriter sw = new StreamWriter(outputFile))
        {
            sw.WriteLine("Самая короткая строка:");
            sw.WriteLine(shortest);
            sw.WriteLine("Самая длинная строка:");
            sw.WriteLine(longest);
        }
        Console.WriteLine(
            $"Результат записан в {outputFile}");
    }


    public static void Task4()
    {
        Console.WriteLine("\nЗадание 4: чётные числа");
        string inputFile;
        while (true)
        {
            inputFile = InputValidator.GetNonEmptyString(
                "Укажите путь к входному бинарному " +
                "файлу (или 0 для выхода): ");
            if (inputFile == "0") return;
            if (File.Exists(inputFile)) break;
            Console.WriteLine(
                "Файл не существует. Попробуйте снова.");
        }
        int count = InputValidator.GetPositiveInt(
            "Введите количество случайных чисел: ");
        FillBinaryFileNumbers(inputFile, count);

        Console.WriteLine(
            "\nСодержимое входного бинарного файла:");
        List<int> inputNumbers = ReadBinaryFile(inputFile);
        foreach (int num in inputNumbers)
            Console.Write(num + " ");
        Console.WriteLine();

        string outputFile = InputValidator.GetNonEmptyString(
            "Укажите имя выходного бинарного файла: ");
        SolveTask4(inputFile, outputFile);

        Console.WriteLine(
            "\nСодержимое выходного бинарного файла " +
            "(чётные числа):");
        List<int> outputNumbers = ReadBinaryFile(outputFile);
        foreach (int num in outputNumbers)
            Console.Write(num + " ");
        Console.WriteLine();

        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    private static void FillBinaryFileNumbers(
        string path, int count)
    {
        Random rnd = new Random();
        using (BinaryWriter bw = new BinaryWriter(
            File.Open(path, FileMode.Create)))
            for (int i = 0; i < count; i++)
                bw.Write(rnd.Next(-100, 101));
        Console.WriteLine(
            $"Файл {path} заполнен {count} числами.");
    }

    private static List<int> ReadBinaryFile(string path)
    {
        List<int> numbers = new List<int>();
        using (BinaryReader br = new BinaryReader(
        File.Open(path, FileMode.Open)))
                while (br.BaseStream.Position <
                        br.BaseStream.Length)
                {
                    numbers.Add(br.ReadInt32());
                }
        return numbers;
    }

    private static void SolveTask4(
        string inputFile, string outputFile)
    {
        List<int> numbers = ReadBinaryFile(inputFile);
            using (BinaryWriter bw = new BinaryWriter(
                File.Open(outputFile, FileMode.Create)))
                foreach (int num in numbers)
                {
                    if (num % 2 == 0)
                    {
                        bw.Write(num);
                    }
                }
        Console.WriteLine(
            $"Чётные числа скопированы в {outputFile}");
    }

   
    public struct BaggageItem
    {
        private string _name;
        private double _weight;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
    }

    public class PassengerBaggage
    {
        public BaggageItem[] items;
    }

    public static void Task5()
    {
        Console.WriteLine("\nЗадание 5: багаж");
        string path;
        while (true)
        {
            path = InputValidator.GetNonEmptyString(
                "Укажите путь к XML-файлу " +
                "(или 0 для выхода): ");
            if (path == "0")
            {
                return;
            }
            if (File.Exists(path))
            {
                break;
            }
                    Console.WriteLine(
                "Файл не существует. Попробуйте снова.");
        }
        int passCount = InputValidator.GetPositiveInt(
            "Введите количество пассажиров: ");
        int maxItems = InputValidator.GetPositiveInt(
            "Введите максимум предметов на пассажира: ");
        FillBaggageFile(path, passCount, maxItems);

        Console.WriteLine(
            "\nИсходные данные (все пассажиры):");
        List<PassengerBaggage> allPassengers =
            ReadBaggageFile(path);
        PrintAllPassengers(allPassengers);

        double m = InputValidator.GetNonNegativeDouble(
            "Введите допустимое отклонение m (кг): ");
        SolveTask5(path, m);
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    public static void FillBaggageFile(
        string path, int passCount, int maxItems)
    {
        Random rnd = new Random();
        string[] itemNames = {
            "Чемодан", "Сумка", "Коробка",
            "Рюкзак", "Саквояж"
        };
        List<PassengerBaggage> passengers =
            new List<PassengerBaggage>();
        for (int i = 0; i < passCount; i++)
        {
            int itemCount = rnd.Next(1, maxItems + 1);
            BaggageItem[] items =
                new BaggageItem[itemCount];
            for (int j = 0; j < itemCount; j++)
            {
                items[j].Name =
                    itemNames[rnd.Next(itemNames.Length)];
                items[j].Weight = Math.Round(
                    rnd.Next(1, 30) + rnd.NextDouble(), 2);
            }
            passengers.Add(
                new PassengerBaggage { items = items });
        }
        XmlSerializer serializer = new XmlSerializer(
            typeof(List<PassengerBaggage>));
        using (FileStream fs = new FileStream(
            path, FileMode.Create))
            serializer.Serialize(fs, passengers);
        Console.WriteLine($"Файл {path} создан.");
    }

    public static List<PassengerBaggage> ReadBaggageFile(
        string path)
    {
        XmlSerializer serializer = new XmlSerializer(
            typeof(List<PassengerBaggage>));
        using (FileStream fs = new FileStream(
            path, FileMode.Open))
            return (List<PassengerBaggage>)
                serializer.Deserialize(fs);
    }

    public static void PrintAllPassengers(
        List<PassengerBaggage> passengers)
    {
        for (int i = 0; i < passengers.Count; i++)
        {
            var pb = passengers[i];
            double sum = 0;
            foreach (var item in pb.items)
            {
                sum += item.Weight;
            }
            double avg = sum / pb.items.Length;
            Console.WriteLine(
                $"Пассажир {i + 1}: предметов = " +
                $"{pb.items.Length}, средняя масса = " +
                $"{avg:F2} кг");
            foreach (var item in pb.items)
                Console.WriteLine(
                    $"   - {item.Name}: {item.Weight:F2} кг");
        }
    }

    public static void SolveTask5(string path, double m)
    {
        List<PassengerBaggage> passengers =
            ReadBaggageFile(path);
        if (passengers == null || passengers.Count == 0)
        {
            throw new InvalidOperationException(
            "Файл не содержит данных.");
        }
        int totalItems = 0;
        double totalWeight = 0.0;
        foreach (var pb in passengers)
        {
            foreach (var item in pb.items)
            {
                totalItems++;
                totalWeight += item.Weight;
            }
        }
        double overallAvg = totalWeight / totalItems;
        Console.WriteLine(
            $"\nОбщая средняя масса единицы багажа: " +
            $"{overallAvg:F2} кг");
        Console.WriteLine(
            $"Ищем багаж с отклонением не более {m} кг.\n");
        bool found = false;
        for (int i = 0; i < passengers.Count; i++)
        {
            var pb = passengers[i];
            double sumWeight = 0.0;
            foreach (var item in pb.items)
            {
                sumWeight += item.Weight;
            }
            double avg = sumWeight / pb.items.Length;
            if (Math.Abs(avg - overallAvg) <= m)
            {
                found = true;
                Console.WriteLine(
                    $"\nПассажир {i + 1}: средняя масса = " +
                    $"{avg:F2} кг");
                Console.WriteLine("Состав:");
                foreach (var item in pb.items)
                {
                    Console.WriteLine(
                    $"  - {item.Name}: {item.Weight:F2} кг");
                }
            }
        }
        if (!found)
        {
            Console.WriteLine(
            "Багаж, удовлетворяющий условию, не найден.");
        }
    }
}
}