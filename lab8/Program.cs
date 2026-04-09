using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            CreateTestFiles();

            Console.WriteLine("=== ЗАВДАННЯ 1 (Електронні адреси) ===");
            new Lab8T1().Run();

            Console.WriteLine("\n=== ЗАВДАННЯ 2 (Максимальне ціле число) ===");
            new Lab8T2().Run();

            Console.WriteLine("\n=== ЗАВДАННЯ 3 (Слова без повторення літер) ===");
            new Lab8T3().Run();

            Console.WriteLine("\n=== ЗАВДАННЯ 4 (Двійкові файли, парні числа) ===");
            new Lab8T4().Run();

            Console.WriteLine("\n=== ЗАВДАННЯ 5 (Файлова система) ===");
            new Lab8T5().Run();

            Console.WriteLine("\nВсі завдання виконані! Натисніть Enter для виходу...");
            Console.ReadLine();
        }

        static void CreateTestFiles()
        {
            File.WriteAllText("input1.txt", "Напишіть мені на email: test@gmail.com або на work-email@ukr.net. Також є старий admin@mail.com.");
            File.WriteAllText("input2.txt", "Сьогодні 2026 рік, температура на вулиці -5 градусів, а на рахунку 15000 гривень. Максимум був 250.");
            File.WriteAllText("input3.txt", "Сонце світить яскраво. Кіт спить. Яблуко смачне. Дім великий.");
        }
    }

    class Lab8T1
    {
        public void Run()
        {
            string inputText = File.ReadAllText("input1.txt");
            Console.WriteLine($"Вихідний текст:\n{inputText}");

            // Пошук та підрахунок email-адрес
            string emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";
            MatchCollection matches = Regex.Matches(inputText, emailPattern);

            Console.WriteLine($"\nЗнайдено електронних адрес: {matches.Count}");

            using (StreamWriter writer = new StreamWriter("output1_emails.txt"))
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine($"- {match.Value}");
                    writer.WriteLine(match.Value);
                }
            }

            Console.Write("\nВведіть домен для заміни (наприклад, ukr.net): ");
            string targetDomain = Console.ReadLine();
            Console.Write("Введіть нове слово замість email: ");
            string replacement = Console.ReadLine();

            // Пошук та заміна адрес із вказаним доменом
            string specificEmailPattern = $@"[a-zA-Z0-9._%+-]+@{targetDomain}\b";
            string modifiedText = Regex.Replace(inputText, specificEmailPattern, replacement);

            Console.WriteLine($"\nТекст після заміни:\n{modifiedText}");
            File.WriteAllText("output1_modified.txt", modifiedText);
        }
    }

    class Lab8T2
    {
        public void Run()
        {
            using (StreamReader reader = new StreamReader("input2.txt"))
            {
                string text = reader.ReadToEnd();
                Console.WriteLine($"Вихідний текст:\n{text}");

                // Пошук усіх цілих чисел (включаючи від'ємні) та знаходження максимального
                Regex numberRegex = new Regex(@"-?\b\d+\b");
                MatchCollection numberMatches = numberRegex.Matches(text);

                if (numberMatches.Count > 0)
                {
                    int maxNumber = int.MinValue;
                    foreach (Match m in numberMatches)
                    {
                        int currentNum = int.Parse(m.Value);
                        if (currentNum > maxNumber)
                        {
                            maxNumber = currentNum;
                        }
                    }

                    Console.WriteLine($"\nМаксимальне ціле число в тексті: {maxNumber}");

                    using (StreamWriter writer = new StreamWriter("output2.txt"))
                    {
                        writer.WriteLine($"Максимальне ціле число: {maxNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("У тексті немає цілих чисел.");
                }
            }
        }
    }

    class Lab8T3
    {
        public void Run()
        {
            string text = File.ReadAllText("input3.txt");
            Console.WriteLine($"Вихідний текст:\n{text}");

            // Розбиття тексту на слова зі збереженням пунктуації
            string[] words = Regex.Split(text, @"(\b[^\s]+\b)");
            string resultText = "";

            foreach (string word in words)
            {
                if (Regex.IsMatch(word, @"^\w+$"))
                {
                    // Фільтрація слів без повторення літер
                    bool hasRepeatingLetters = word.ToLower().GroupBy(c => c).Any(g => g.Count() > 1);
                    if (!hasRepeatingLetters)
                    {
                        resultText += word;
                    }
                }
                else
                {
                    resultText += word;
                }
            }

            resultText = Regex.Replace(resultText, @"\s+", " ").Trim();

            Console.WriteLine($"\nТекст після вилучення слів із повторюваними літерами:\n{resultText}");
            File.WriteAllText("output3.txt", resultText);
        }
    }

    class Lab8T4
    {
        public void Run()
        {
            int[] sequence = { 1, 2, 5, 8, 10, 15, 22, 44, -6, 7 };
            Console.WriteLine($"Вихідна послідовність: {string.Join(", ", sequence)}");

            string binFile = "numbers.dat";

            // Запис та читання парних чисел з двійкового файлу
            using (FileStream fs = new FileStream(binFile, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                foreach (int num in sequence)
                {
                    if (num % 2 == 0) writer.Write(num);
                }
            }

            Console.Write("\nВміст двійкового файлу (парні числа): ");
            using (FileStream fs = new FileStream(binFile, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (fs.Position < fs.Length)
                {
                    Console.Write(reader.ReadInt32() + " ");
                }
            }
            Console.WriteLine();
        }
    }

    class Lab8T5
    {
        public void Run()
        {
            string surname = "Shudrowskiy";
            string basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "temp");

            try
            {
                if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);

                // Створення робочих папок та базових файлів
                string dir1 = Path.Combine(basePath, $"{surname}1");
                string dir2 = Path.Combine(basePath, $"{surname}2");

                Directory.CreateDirectory(dir1);
                Directory.CreateDirectory(dir2);

                string t1Path = Path.Combine(dir1, "t1.txt");
                string t2Path = Path.Combine(dir1, "t2.txt");

                File.WriteAllText(t1Path, "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>");
                File.WriteAllText(t2Path, "<Комар Сергій Федорович, 2000 > року народження, місце проживання <м. Київ>");

                // Об'єднання вмісту файлів
                string t3Path = Path.Combine(dir2, "t3.txt");
                File.WriteAllText(t3Path, File.ReadAllText(t1Path) + Environment.NewLine + File.ReadAllText(t2Path));

                Console.WriteLine("\nІнформація про створені файли:");
                PrintFileInfo(t1Path);
                PrintFileInfo(t2Path);
                PrintFileInfo(t3Path);

                // Копіювання, переміщення файлів та реорганізація каталогів
                string t2NewPath = Path.Combine(dir2, "t2.txt");
                if (File.Exists(t2NewPath)) File.Delete(t2NewPath);
                File.Move(t2Path, t2NewPath);

                string t1NewPath = Path.Combine(dir2, "t1.txt");
                File.Copy(t1Path, t1NewPath, true);

                string dirAll = Path.Combine(basePath, "ALL");
                if (Directory.Exists(dirAll)) Directory.Delete(dirAll, true);

                Directory.Move(dir2, dirAll);
                Directory.Delete(dir1, true);

                Console.WriteLine("\nІнформація про файли в папці ALL:");
                foreach (FileInfo file in new DirectoryInfo(dirAll).GetFiles())
                {
                    Console.WriteLine($"- Файл: {file.Name}, Розмір: {file.Length} байт, Створено: {file.CreationTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка роботи з файловою системою: {ex.Message}");
            }
        }

        private void PrintFileInfo(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            if (info.Exists)
            {
                Console.WriteLine($"- {info.Name}: Шлях: {info.FullName}, Створено: {info.CreationTime}, Розмір: {info.Length} байт");
            }
        }
    }
}
