using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab6_Variant23
{
    // ВЛАСНИЙ КЛАС ВИНЯТКУ Завдання 3.3
    [Serializable]
    public class VectorInvalidIndexException : ApplicationException
    {
        public VectorInvalidIndexException() { }
        public VectorInvalidIndexException(string message) : base(message) { }
    }


    // ЗАВДАННЯ 1: ІНТЕРФЕЙСИ ТА ПАТТЕРНИ ТИПІВ (Місце, область, місто, мегаполіс)

    // Базові інтерфейси користувача
    public interface ILocation
    {
        string Name { get; set; }
        void Show();
    }

    public interface IDemographics
    {
        int Population { get; set; }
    }

    // Абстрактний базовий клас реалізує інтерфейси
    public abstract class Place : ILocation, IDemographics
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public Place(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public abstract void Show();
        public virtual void PrintCategory() => Console.WriteLine("Категорія: Невизначена локація");

  
        public void PrintBaseInfo() => Console.WriteLine($"[Базова інфо] Назва: {Name}, Населення: {Population}");

       
        ~Place()
        {
            Console.WriteLine($"Деструктор: об'єкт {Name} видалено з пам'яті.");
        }
    }

    // Похідні класи з особливими методами
    public class Region : Place
    {
        public int DistrictsCount { get; set; }
        public Region(string name, int population, int districtsCount) : base(name, population)
        { DistrictsCount = districtsCount; }

        public override void Show() => Console.WriteLine($"[Область] {Name}, Населення: {Population}");

        // Особливий метод
        public void ShowDistrictsInfo() => Console.WriteLine($"--> В області {Name} є {DistrictsCount} районів.");
    }

    public class City : Place
    {
        public bool HasAirport { get; set; }
        public City(string name, int population, bool hasAirport) : base(name, population)
        { HasAirport = hasAirport; }

        public override void Show() => Console.WriteLine($"[Місто] {Name}, Населення: {Population}");

        // Особливий метод
        public void ShowAirportInfo() => Console.WriteLine($"--> Аеропорт у місті {Name}: {(HasAirport ? "Присутній" : "Відсутній")}.");
    }

    public class Megalopolis : City
    {
        public int MetroStations { get; set; }
        public Megalopolis(string name, int population, bool hasAirport, int metroStations) : base(name, population, hasAirport)
        { MetroStations = metroStations; }

        public override void Show() => Console.WriteLine($"[Мегаполіс] {Name}, Населення: {Population}");

        // Особливий метод
        public void ShowMetroInfo() => Console.WriteLine($"--> Мегаполіс {Name} має {MetroStations} станцій метро.");
    }

    // ЗАВДАННЯ 2: ІНТЕРФЕЙСИ ТА ЇХ УСПАДКУВАННЯ ВІД .NET (Видання)

    // Інтерфейс, який успадковує стандартний інтерфейс IComparable
    public interface IPublication : IComparable<IPublication>
    {
        string Title { get; }
        string AuthorSurname { get; }
        void ShowInfo();
        bool IsAuthor(string surname);
    }

    public class Book : IPublication
    {
        public string Title { get; set; }
        public string AuthorSurname { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }

        public Book(string title, string author, int year, string publisher)
        { Title = title; AuthorSurname = author; Year = year; Publisher = publisher; }

        public void ShowInfo() => Console.WriteLine($"Книга: '{Title}', Автор: {AuthorSurname}, Рік: {Year}, Видавництво: {Publisher}");
        public bool IsAuthor(string surname) => AuthorSurname.Equals(surname, StringComparison.OrdinalIgnoreCase);

        public int CompareTo(IPublication other) => string.Compare(this.Title, other?.Title);
    }

    public class Article : IPublication
    {
        public string Title { get; set; }
        public string AuthorSurname { get; set; }
        public string Journal { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }

        public Article(string title, string author, string journal, int number, int year)
        { Title = title; AuthorSurname = author; Journal = journal; Number = number; Year = year; }

        public void ShowInfo() => Console.WriteLine($"Стаття: '{Title}', Автор: {AuthorSurname}, Журнал: {Journal} #{Number}, Рік: {Year}");
        public bool IsAuthor(string surname) => AuthorSurname.Equals(surname, StringComparison.OrdinalIgnoreCase);

        public int CompareTo(IPublication other) => string.Compare(this.Title, other?.Title);
    }

    public class ElectronicResource : IPublication
    {
        public string Title { get; set; }
        public string AuthorSurname { get; set; }
        public string Link { get; set; }
        public string Annotation { get; set; }

        public ElectronicResource(string title, string author, string link, string annotation)
        { Title = title; AuthorSurname = author; Link = link; Annotation = annotation; }

        public void ShowInfo() => Console.WriteLine($"Ел.ресурс: '{Title}', Автор: {AuthorSurname}, URL: {Link}");
        public bool IsAuthor(string surname) => AuthorSurname.Equals(surname, StringComparison.OrdinalIgnoreCase);

        public int CompareTo(IPublication other) => string.Compare(this.Title, other?.Title);
    }


  
    // ЗАВДАННЯ 3.3 та 4: ВИНЯТКОВІ СИТУАЦІЇ ТА IENUMERABLE (Клас з Лаби 4)
 

    // Клас VectorShort реалізує IEnumerable для foreach (Завдання 4)
    public class VectorShort : IEnumerable<short>
    {
        private short[] data;

        public VectorShort(short[] arr)
        {
            data = arr;
        }

        // Завдання 3.3: Індексатор, який генерує і стандартний, і власний виняток
        public short this[int index]
        {
            get
            {
                // Власний виняток
                if (index < 0)
                    throw new VectorInvalidIndexException("Індекс вектора не може бути від'ємним!");

                // Стандартний виняток (варіант 3.3)
                if (index >= data.Length)
                    throw new IndexOutOfRangeException("Вихід за межі масиву вектора!");

                return data[index];
            }
            set
            {
                if (index < 0)
                    throw new VectorInvalidIndexException("Індекс вектора не може бути від'ємним!");
                if (index >= data.Length)
                    throw new IndexOutOfRangeException("Вихід за межі масиву вектора!");

                data[index] = value;
            }
        }

        // Завдання 4: Реалізація перелічувача за допомогою yield return
        public IEnumerator<short> GetEnumerator()
        {
            for (int i = 0; i < data.Length; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


    class Program
    {
        // Метод з усіма видами перевірки типів (Завдання 1)
        static void ProcessLocations(ILocation[] locations)
        {
            foreach (var loc in locations)
            {
                loc.Show();

                if (loc is Place p)
                {
                    p.PrintCategory();
                }

                
                if (loc.GetType() == typeof(Megalopolis))
                {
                    Megalopolis m = (Megalopolis)loc;
                    m.ShowMetroInfo();
                }

                
                City c = loc as City;
                if (c != null && loc.GetType() != typeof(Megalopolis)) 
                {
                    c.ShowAirportInfo();
                }

                
                switch (loc)
                {
                    case Region r:
                        r.ShowDistrictsInfo();
                        break;
                }

                Console.WriteLine();
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //ТЕСТУВАННЯ ЗАВДАННЯ 1
            Console.WriteLine("ЗАВДАННЯ 1: ІНТЕРФЕЙСИ ТА ПЕРЕВІРКА ТИПІВ (is, as, typeof, switch)");
            ILocation[] myLocations = new ILocation[]
            {
                new Region("Чернівецька", 900000, 3),
                new City("Львів", 720000, true),
                new Megalopolis("Київ", 2950000, true, 52)
            };
            ProcessLocations(myLocations);


            //ТЕСТУВАННЯ ЗАВДАННЯ 2
            Console.WriteLine("ЗАВДАННЯ 2: ІНТЕРФЕЙСИ ВИДАНЬ ТА ПОШУК");
            IPublication[] catalog = new IPublication[]
            {
                new Book("Програмування на C#", "Лазорик", 2026, "Освіта"),
                new Article("Паттерни типів", "Троelsen", "IT Журнал", 5, 2023),
                new ElectronicResource("Довідник C#", "Лазорик", "docs.microsoft.com", "Офіційна документація")
            };

            Console.WriteLine("Повний каталог (відсортований за назвою завдяки IComparable):");
            Array.Sort(catalog); // Спрацьовує успадкований від .NET інтерфейс IComparable
            foreach (var pub in catalog) pub.ShowInfo();

            Console.WriteLine("\nПошук видань автора 'Лазорик':");
            foreach (var pub in catalog)
            {
                if (pub.IsAuthor("Лазорик"))
                    pub.ShowInfo();
            }


            //ТЕСТУВАННЯ ЗАВДАННЯ 4
            Console.WriteLine("\nЗАВДАННЯ 4: РОБОТА FOREACH (IEnumerable)");
            VectorShort myVector = new VectorShort(new short[] { 10, 20, 30, 40 });

            Console.Write("Елементи вектора (через foreach): ");
            // Спрацьовує завдяки тому, що ми успадкували IEnumerable і написали GetEnumerator()
            foreach (short val in myVector)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine("\n");


            //ТЕСТУВАННЯ ЗАВДАННЯ 3.3
            Console.WriteLine("ЗАВДАННЯ 3.3: ОБРОБКА ВИНЯТКІВ (IndexOutOfRangeException та власного)");

            // ТЕСТ 1: Стандартний виняток (Вихід за межі)
            try
            {
                Console.WriteLine("Спроба звернутися до 5-го елемента (якого не існує)...");
                short value = myVector[5];
            }
            catch (IndexOutOfRangeException ex) // Ловимо стандартний виняток
            {
                Console.WriteLine($"[ПЕРЕХОПЛЕНО СТАНДАРТНИЙ ВИНЯТОК IndexOutOfRangeException]: {ex.Message}");
            }

            // ТЕСТ 2: Власний виняток (Від'ємний індекс)
            try
            {
                Console.WriteLine("\nСпроба звернутися до елемента з індексом -1...");
                short value = myVector[-1];
            }
            catch (VectorInvalidIndexException ex) // Ловлю власний виняток
            {
                Console.WriteLine($"[ПЕРЕХОПЛЕНО ВЛАСНИЙ ВИНЯТОК VectorInvalidIndexException]: {ex.Message}");
            }


            Console.WriteLine("\nОЧИЩЕННЯ ПАМ'ЯТІ (Спрацювання деструкторів)");
            myLocations = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.ReadLine();
        }
    }
}
