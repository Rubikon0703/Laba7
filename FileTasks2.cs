using System.Text;

namespace Laba7
{
    public static class CollectionTasks
    {
       
        public static void Task6()
        {
            Console.WriteLine(
                "\n Задание 6: удаление элемента из List ");
            List<int> list = new List<int>();
            Console.Write("Введите целые числа через пробел: ");
            string[] parts = Console.ReadLine().Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string p in parts)
                if (int.TryParse(p, out int num))
                    list.Add(num);
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                Console.WriteLine(
                  "\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
            Console.Write("Введите элемент E для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int e))
            {
                Console.WriteLine("Некорректное число.");
                Console.WriteLine(
                  "\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
        
            for (int i = list.Count - 1; i >= 0; i--)
                if (list[i] == e)
                    list.RemoveAt(i);
            Console.WriteLine
                ("Результат: " + string.Join(" ", list));
            Console.WriteLine(
                "\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

    
        public static void Task7()
        {
            Console.WriteLine(
                "\nЗадание 7: LinkedList в обратном порядке");
            LinkedList<int> linkedList = new LinkedList<int>();
            Console.Write("Введите целые числа через пробел: ");
            string[] parts = Console.ReadLine().Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            foreach (string p in parts)
                if (int.TryParse(p, out int num))
                    linkedList.AddLast(num);
            if (linkedList.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                Console.WriteLine(
                 "\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
            Console.Write("Обратный порядок: ");
            LinkedListNode<int> current = linkedList.Last;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Previous;
            }
            Console.WriteLine();
            Console.WriteLine(
                "\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public static void Task8()
        {
            Console.WriteLine(
                "\n Задание 8: фирмы и учебные заведения");
            Console.Write
                ("Введите список всех фирм через пробел: ");
            string[] allFirms = Console.ReadLine().Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            HashSet<string> allFirmsSet = new HashSet<string>();
            foreach (string f in allFirms)
                allFirmsSet.Add(f);
            if (allFirmsSet.Count == 0)
            {
                Console.WriteLine("Список фирм пуст.");
                Console.WriteLine(
                  "\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                return;
            }
            int n = InputValidator.GetPositiveInt(
                "Введите количество учебных заведений: ");
            List<HashSet<string>> schoolsPurchases =
                new List<HashSet<string>>();
            for (int i = 0; i < n; i++)
            {
                Console.Write(
                    $"Заведение {i + 1}: " +
                    $"введите фирмы (через пробел): ");
                string[] buys = Console.ReadLine().Split(
                    new char[] { ' ', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);
                HashSet<string> schoolSet =
                    new HashSet<string>();
                foreach (string b in buys)
                    if (allFirmsSet.Contains(b))
                        schoolSet.Add(b);
                    else
                        Console.WriteLine(
                            $"Фирма '{b}' " +
                            $"не в общем списке, пропущена.");
                schoolsPurchases.Add(schoolSet);
            }
          
            Console.WriteLine(
                "\n1) Фирмы, где закупало каждое заведение:");
            for (int i = 0; i < schoolsPurchases.Count; i++)
            {
                Console.Write($"   Заведение {i + 1}: ");
                if (schoolsPurchases[i].Count == 0)
                    Console.WriteLine("не закупало нигде");
                else
                {
                    List<string> list =
                        new List<string>(schoolsPurchases[i]);
                    Console.WriteLine(string.Join(", ", list));
                }
            }
           
            HashSet<string> union = new HashSet<string>();
            foreach (var set in schoolsPurchases)
                foreach (string firm in set)
                    union.Add(firm);
            Console.WriteLine(
                "\n2) Фирмы, где закупало" +
                " хотя бы одно заведение:");
            if (union.Count == 0)
                Console.WriteLine("   нет таких");
            else
            {
                List<string> unionList = 
                    new List<string>(union);
                Console.WriteLine
                    ("   " + string.Join(", ", unionList));
            }
           
            HashSet<string> notBought =
                new HashSet<string>(allFirmsSet);
            foreach (string firm in union)
                notBought.Remove(firm);
            Console.WriteLine(
                "\n3) Фирмы, где ни одно" +
                " заведение не закупало:");
            if (notBought.Count == 0)
                Console.WriteLine(
                    "   нет таких" +
                    " (все фирмы были использованы)");
            else
            {
                List<string> notList =
                    new List<string>(notBought);
                Console.WriteLine
                    ("   " + string.Join(", ", notList));
            }
            Console.WriteLine(
              "\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public static void Task9()
        {
            Console.WriteLine(
                "\nЗадание 9: звонкие согласные в тексте ");
            string filePath = 
                InputValidator.GetExistingFilePath(
                "Укажите путь к текстовому файлу: ");
            string text;
            using (StreamReader sr = new StreamReader(
                filePath, Encoding.UTF8))
                text = sr.ReadToEnd();
            char[] separators = {
                ' ', '\t', '\n', '\r', 
                ',', '.', '!', '?', ';', ':',
                '(', ')', '[', ']', 
                '{', '}', '"', '\'', '–', '—'
            };
            string[] words = text.Split(separators,
                StringSplitOptions.RemoveEmptyEntries);
            char[] voicedConsonants = {
                'б', 'в', 'г', 'д', 'ж', 'з',
                'й', 'л', 'м', 'н', 'р'
            };
            HashSet<char> voicedSet = new HashSet<char>();
            foreach (char c in voicedConsonants)
                voicedSet.Add(c);
            HashSet<char> foundLetters = new HashSet<char>();
            foreach (string word in words)
            {
                foreach (char ch in word.ToLower())
                {
                    if (voicedSet.Contains(ch))
                        foundLetters.Add(ch);
                }
            }
          
            List<char> sortedLetters = 
                new List<char>(foundLetters);
            for (int i = 0; i < sortedLetters.Count - 1; i++)
            {
                for (int j = 0; j <
                    sortedLetters.Count - 1 - i; j++)
                {
                    if (sortedLetters[j] > sortedLetters[j + 1])
                    {
                        char temp = sortedLetters[j];
                        sortedLetters[j] = sortedLetters[j + 1];
                        sortedLetters[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine(
                "Звонкие согласные, " +
                "встречающиеся хотя бы в одном слове:");
            if (sortedLetters.Count == 0)
                Console.WriteLine("   не найдены");
            else
                Console.WriteLine("   " + 
                    string.Join(", ", sortedLetters));
            Console.WriteLine(
              "\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

       
        public static void Task10()
        {
            Console.WriteLine(
                "\nЗадание 10: " +
                "формирование логинов по фамилиям");
            int n = InputValidator.GetPositiveInt(
                "Введите количество учеников: ");
            Dictionary<string, int> surnameCount =
                new Dictionary<string, int>();
            List<string> logins = new List<string>();
            for (int i = 0; i < n; i++)
            {
                Console.Write
                    ($"Ученик {i + 1} (Фамилия Имя): ");
                string line = Console.ReadLine().Trim();
                string[] parts = line.Split(
                    new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 2)
                {
                    Console.WriteLine(
                        "   Ошибка: " +
                        "нужны фамилия и имя. Пропуск.");
                    logins.Add("?");
                    continue;
                }
                string surname = parts[0];
                if (!surnameCount.ContainsKey(surname))
                {
                    surnameCount[surname] = 1;
                    logins.Add(surname);
                }
                else
                {
                    surnameCount[surname]++;
                    logins.Add(surname + surnameCount[surname]);
                }
            }
            Console.WriteLine("\nСформированные логины:");
            for (int i = 0; i < logins.Count; i++)
                Console.WriteLine($"   {i + 1}. {logins[i]}");
            Console.WriteLine(
                "\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}