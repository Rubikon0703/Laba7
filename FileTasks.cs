
using System.Text;
using System.Xml.Serialization;

namespace Laba7
{

    public static class FileTasks
    {
       
        public static int Task1(string inputFilePath)
        {
            List<int> numbers = new List<int>();
            using (StreamReader sr = 
                new StreamReader(inputFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    if (int.TryParse(line, out int num))
                        numbers.Add(num);
            }
            if (numbers.Count % 2 != 0)
                throw new InvalidOperationException(
                    "Количество элементов файла нечётно.");
            int half = numbers.Count / 2;
            int sumFirst = 0, sumSecond = 0;
            for (int i = 0; i < half; i++) sumFirst +=
                    numbers[i];
            for (int i = half; i < numbers.Count; i++)
                sumSecond += numbers[i];
            return sumFirst - sumSecond;
        }
        public static void FillTextFileSingle(string path, int count)
        {
            Random rnd = new Random();
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < count; i++)
                    sw.WriteLine(rnd.Next(-100, 101));
            }
        }

        public static int Task2(string inputFilePath)
        {
            int totalSum = 0;
            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(
                        new char[] { ' ', '\t' },
                        StringSplitOptions.RemoveEmptyEntries);
                    foreach (string part in parts)
                        if (int.TryParse(part, out int num))
                            totalSum += num;
                }
            }
            return totalSum;
        }
        public static void FillTextFileMultiple(string path,
    int lines, int maxNumbersPerLine)
        {
            Random rnd = new Random();
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < lines; i++)
                {
                    int count = rnd.Next(1, maxNumbersPerLine + 1);
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < count; j++)
                    {
                        sb.Append(rnd.Next(-50, 51));
                        if (j < count - 1) sb.Append(' ');
                    }
                    sw.WriteLine(sb.ToString());
                }
            }
        }

        public static void Task3(string inputFilePath,
                                 string outputFilePath)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = 
                new StreamReader(inputFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    lines.Add(line);
            }
            if (lines.Count == 0)
                throw new 
                    InvalidOperationException("Файл пуст.");
            string shortest = lines[0];
            string longest = lines[0];
            for (int i = 1; i < lines.Count; i++)
            {
                if (lines[i].Length < shortest.Length)
                    shortest = lines[i];
                if (lines[i].Length > longest.Length)
                    longest = lines[i];
            }
            using (StreamWriter sw =
                new StreamWriter(outputFilePath))
            {
                sw.WriteLine("Самая короткая строка:");
                sw.WriteLine(shortest);
                sw.WriteLine("Самая длинная строка:");
                sw.WriteLine(longest);
            }
        }

        
        public static void Task4(string inputFilePath,
                                 string outputFilePath)
        {
            List<int> numbers = new List<int>();
            using (BinaryReader br = new BinaryReader(
                File.Open(inputFilePath, FileMode.Open)))
            {
                while (br.BaseStream.Position <
                    br.BaseStream.Length)
                    numbers.Add(br.ReadInt32());
            }
            using (BinaryWriter bw = new BinaryWriter(
                File.Open(outputFilePath, FileMode.Create)))
            {
                foreach (int num in numbers)
                    if (num % 2 == 0)
                        bw.Write(num);
            }
        }
        public static void FillBinaryFileNumbers(string path, int count)
        {
            Random rnd = new Random();
            using (BinaryWriter bw = new BinaryWriter(
                File.Open(path, FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                    bw.Write(rnd.Next(-100, 101));
            }
        }

        public struct BaggageItem
        {
            public string Name;
            public double Weight;
        }

        public class PassengerBaggage
        {
            public BaggageItem[] Items;
        }
        public static void FillBinaryFileBaggage(string path,
    int passengerCount, int maxItemsPerPassenger)
        {
            Random rnd = new Random();
            string[] itemNames = { "Чемодан", "Сумка", "Коробка",
        "Рюкзак", "Саквояж" };
            List<PassengerBaggage> passengers =
                new List<PassengerBaggage>();
            for (int i = 0; i < passengerCount; i++)
            {
                int itemCount = rnd.Next(1, maxItemsPerPassenger + 1);
                BaggageItem[] items = new BaggageItem[itemCount];
                for (int j = 0; j < itemCount; j++)
                {
                    items[j].Name = itemNames[rnd.Next(itemNames.Length)];
                    items[j].Weight = rnd.Next(1, 30) + rnd.NextDouble();
                }
                PassengerBaggage pb = new PassengerBaggage();
                pb.Items = items;
                passengers.Add(pb);
            }
            XmlSerializer serializer = new XmlSerializer(
                typeof(List<PassengerBaggage>));
            using (FileStream fs = new FileStream(path,
                FileMode.Create))
                serializer.Serialize(fs, passengers);
        }
        public static void Task5(string inputFilePath, double m)
        {
            List<PassengerBaggage> passengers;
            XmlSerializer serializer = new XmlSerializer(
                typeof(List<PassengerBaggage>));
            using (FileStream fs = new FileStream(
                inputFilePath, FileMode.Open))
                passengers = (List<PassengerBaggage>)
                    serializer.Deserialize(fs);
            if (passengers == null || passengers.Count == 0)
                throw new InvalidOperationException(
                    "Файл не содержит данных.");
            int totalItems = 0;
            double totalWeight = 0.0;
            foreach (PassengerBaggage pb in passengers)
                foreach (BaggageItem item in pb.Items)
                {
                    totalItems++;
                    totalWeight += item.Weight;
                }
            double overallAvg = totalWeight / totalItems;
            Console.WriteLine(
                $"Общая средняя масса единицы багажа:" +
                $" {overallAvg:F2} кг");
            Console.WriteLine(
                $"Ищем багаж с отклонением не более {m} кг.");
            bool found = false;
            for (int i = 0; i < passengers.Count; i++)
            {
                PassengerBaggage pb = passengers[i];
                double sumWeight = 0.0;
                foreach (BaggageItem item in pb.Items)
                    sumWeight += item.Weight;
                double avg = sumWeight / pb.Items.Length;
                if (Math.Abs(avg - overallAvg) <= m)
                {
                    found = true;
                    Console.WriteLine(
                        $"\nПассажир {i + 1}: " +
                        $"средняя масса = {avg:F2} кг");
                    Console.WriteLine("Состав:");
                    foreach (BaggageItem item in pb.Items)
                        Console.WriteLine(
                            $"  - {item.Name}: " +
                            $"{item.Weight:F2} кг");
                }
            }
            if (!found) Console.WriteLine("Багаж не найден.");
        }
    }
}