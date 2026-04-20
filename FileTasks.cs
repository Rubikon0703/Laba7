
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

      
        public struct BaggageItem
        {
            public string Name;
            public double Weight;
        }

        public class PassengerBaggage
        {
            public BaggageItem[] Items;
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