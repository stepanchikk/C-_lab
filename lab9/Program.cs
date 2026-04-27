using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Lab9T2 lab9 = new Lab9T2();
            lab9.Run();
        }
    }

    public class Lab9T2
    {
        public void Run()
        {
            InitializeFiles();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА №9 (Варіант 23) ===");
                Console.WriteLine("1. Завдання 1.3: Stack");
                Console.WriteLine("2. Завдання 2.3: Queue");
                Console.WriteLine("3. Завдання 3: ArrayList");
                Console.WriteLine("4. Завдання 4: Hashtable (Інтерактивний каталог)");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВаш вибір: ");

                string choice = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch (choice)
                {
                    case "1": ExecuteTask1Stack(); break;
                    case "2": ExecuteTask2Queue(); break;
                    case "3": ExecuteTask3ArrayList(); break;
                    case "4": ExecuteTask4Hashtable(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний пункт меню."); break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу...");
                Console.ReadKey();
            }
        }

        // Створення базових файлів при першому запуску
        private void InitializeFiles()
        {
            bool created = false;
            if (!File.Exists("t.txt"))
            {
                File.WriteAllText("t.txt", "Привіт світ\nПрограмування на C#\nСтек працює", Encoding.UTF8);
                created = true;
            }
            if (!File.Exists("words.txt"))
            {
                File.WriteAllText("words.txt", "яблуко банан апельсин груша евкаліпт слива ірис", Encoding.UTF8);
                created = true;
            }
            if (created)
            {
                Console.WriteLine("Файли 't.txt' та 'words.txt' успішно створено.");
                Console.ReadKey();
            }
        }

        private void ExecuteTask1Stack()
        {
            Stack stack = new Stack();
            string[] lines = File.ReadAllLines("t.txt", Encoding.UTF8);

            foreach (string line in lines)
            {
                foreach (char ch in line) stack.Push(ch);

                Console.Write("Реверс: ");
                while (stack.Count > 0) Console.Write(stack.Pop());
                Console.WriteLine();
            }
        }

        private void ExecuteTask2Queue()
        {
            Queue vowelQueue = new Queue();
            Queue consonantQueue = new Queue();
            string vowels = "аеєиіїоуюяАЕЄИІЇОУЮЯ";

            string[] words = File.ReadAllText("words.txt", Encoding.UTF8)
                .Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (vowels.Contains(word[0].ToString())) vowelQueue.Enqueue(word);
                else consonantQueue.Enqueue(word);
            }

            Console.Write("Голосні: ");
            while (vowelQueue.Count > 0) Console.Write(vowelQueue.Dequeue() + " ");

            Console.Write("\nПриголосні: ");
            while (consonantQueue.Count > 0) Console.Write(consonantQueue.Dequeue() + " ");
            Console.WriteLine();
        }

        private void ExecuteTask3ArrayList()
        {
            ArrayList vowelList = new ArrayList();
            ArrayList consonantList = new ArrayList();
            string vowels = "аеєиіїоуюяАЕЄИІЇОУЮЯ";

            string[] words = File.ReadAllText("words.txt", Encoding.UTF8)
                .Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (vowels.Contains(word[0].ToString())) vowelList.Add(word);
                else consonantList.Add(word);
            }

            Console.Write("Голосні (ArrayList): ");
            foreach (string w in vowelList) Console.Write(w + " ");

            Console.Write("\nПриголосні (ArrayList): ");
            foreach (string w in consonantList) Console.Write(w + " ");
            Console.WriteLine();
        }

        // Інтерактивний музичний каталог на базі Hashtable
        private void ExecuteTask4Hashtable()
        {
            Hashtable catalog = new Hashtable();
            // Базове наповнення для зручності тестування
            catalog.Add("Rock", new ArrayList { "AC/DC - Thunderstruck", "Queen - Bohemian Rhapsody" });
            catalog.Add("Pop", new ArrayList { "Michael Jackson - Billie Jean" });

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ІНТЕРАКТИВНИЙ КАТАЛОГ ДИСКІВ (Hashtable) ===");
                Console.WriteLine("1. Переглянути весь каталог");
                Console.WriteLine("2. Переглянути окремий диск");
                Console.WriteLine("3. Додати новий диск");
                Console.WriteLine("4. Видалити диск");
                Console.WriteLine("5. Додати пісню на диск");
                Console.WriteLine("6. Видалити пісню з диска");
                Console.WriteLine("7. Пошук пісень за виконавцем");
                Console.WriteLine("0. Повернутися до головного меню");
                Console.Write("\nВаш вибір: ");

                string choice = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        foreach (DictionaryEntry disk in catalog)
                        {
                            Console.WriteLine($"Диск: [{disk.Key}]");
                            foreach (string song in (ArrayList)disk.Value) Console.WriteLine($"  ♪ {song}");
                        }
                        if (catalog.Count == 0) Console.WriteLine("Каталог порожній.");
                        break;

                    case "2":
                        Console.Write("Введіть назву диска: ");
                        string dName = Console.ReadLine() ?? "";
                        if (catalog.ContainsKey(dName))
                        {
                            Console.WriteLine($"Диск: [{dName}]");
                            foreach (string song in (ArrayList)catalog[dName]) Console.WriteLine($"  ♪ {song}");
                        }
                        else Console.WriteLine("Диск не знайдено.");
                        break;

                    case "3":
                        Console.Write("Введіть назву нового диска: ");
                        string newDisk = Console.ReadLine() ?? "";
                        if (!catalog.ContainsKey(newDisk) && !string.IsNullOrWhiteSpace(newDisk))
                        {
                            catalog.Add(newDisk, new ArrayList());
                            Console.WriteLine("Диск успішно додано.");
                        }
                        else Console.WriteLine("Такий диск вже існує або назва порожня.");
                        break;

                    case "4":
                        Console.Write("Введіть назву диска для видалення: ");
                        string delDisk = Console.ReadLine() ?? "";
                        if (catalog.ContainsKey(delDisk))
                        {
                            catalog.Remove(delDisk);
                            Console.WriteLine("Диск видалено.");
                        }
                        else Console.WriteLine("Диск не знайдено.");
                        break;

                    case "5":
                        Console.Write("Введіть назву диска: ");
                        string targetDisk = Console.ReadLine() ?? "";
                        if (catalog.ContainsKey(targetDisk))
                        {
                            Console.Write("Введіть назву пісні (напр. Artist - Song): ");
                            string newSong = Console.ReadLine() ?? "";
                            ((ArrayList)catalog[targetDisk]).Add(newSong);
                            Console.WriteLine("Пісню додано.");
                        }
                        else Console.WriteLine("Диск не знайдено.");
                        break;

                    case "6":
                        Console.Write("Введіть назву диска: ");
                        string tDisk = Console.ReadLine() ?? "";
                        if (catalog.ContainsKey(tDisk))
                        {
                            Console.Write("Введіть точну назву пісні для видалення: ");
                            string delSong = Console.ReadLine() ?? "";
                            ArrayList songs = (ArrayList)catalog[tDisk];
                            if (songs.Contains(delSong))
                            {
                                songs.Remove(delSong);
                                Console.WriteLine("Пісню видалено.");
                            }
                            else Console.WriteLine("Пісню не знайдено на цьому диску.");
                        }
                        else Console.WriteLine("Диск не знайдено.");
                        break;

                    case "7":
                        Console.Write("Введіть ім'я виконавця для пошуку: ");
                        string artist = Console.ReadLine() ?? "";
                        bool found = false;
                        foreach (DictionaryEntry disk in catalog)
                        {
                            foreach (string song in (ArrayList)disk.Value)
                            {
                                if (song.ToLower().Contains(artist.ToLower()))
                                {
                                    Console.WriteLine($"Знайдено: {song} (Диск: {disk.Key})");
                                    found = true;
                                }
                            }
                        }
                        if (!found) Console.WriteLine("Записів цього виконавця не знайдено.");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу...");
                Console.ReadKey();
            }
        }
    }
}
