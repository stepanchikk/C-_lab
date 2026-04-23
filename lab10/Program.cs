using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab10
{
    // Оголошення делегата
    public delegate void FacultyEventHandler(object sender, FacultyEventArgs e);

    // 1. ПРІОРИТЕТ: Перелічення для пріоритетів подій
    public enum EventPriority
    {
        Low,
        Normal,
        High
    }

    // Клас аргументів події
    public class FacultyEventArgs : EventArgs
    {
        public int Day { get; }
        public string EventName { get; }
        public EventPriority Priority { get; } // Додано пріоритет
        public string Result { get; set; } = string.Empty;

        public FacultyEventArgs(int day, string eventName, EventPriority priority)
        {
            Day = day;
            EventName = eventName;
            Priority = priority;
        }
    }

    // Клас факультету
    public class Faculty
    {
        public string Name { get; }
        public int Days { get; }

        public event FacultyEventHandler? FacultyEvent;

        private Random rnd = new Random();
        private List<string> resultServices = new List<string>();

        // 2. ЧЕРГА: Черга для очікування обробки подій
        private Queue<FacultyEventArgs> eventQueue = new Queue<FacultyEventArgs>();

        // 4. СТАТИСТИКА: Словник для збереження кількості подій
        public Dictionary<string, int> Statistics { get; } = new Dictionary<string, int>();

        public Faculty(string name, int days)
        {
            Name = name;
            Days = days;
        }

        // 3. АСИНХРОННІСТЬ: Асинхронний метод обробки однієї події
        protected async Task ProcessEventAsync(FacultyEventArgs e)
        {
            Console.WriteLine($"\n--- День {e.Day} | Пріоритет: [{e.Priority}] | На факультеті '{Name}' розпочалася подія: [{e.EventName}] ---");

            if (FacultyEvent != null)
            {
                Delegate[] handlers = FacultyEvent.GetInvocationList();
                resultServices.Clear();

                foreach (FacultyEventHandler handler in handlers)
                {
                    handler(this, e);
                    if (!string.IsNullOrEmpty(e.Result))
                    {
                        resultServices.Add(e.Result);
                        e.Result = string.Empty; // Очищаємо для наступного слухача
                    }
                }

                // Виводимо реакції
                foreach (string res in resultServices)
                {
                    Console.WriteLine(res);
                }
            }

            // Імітуємо час, потрібний на проведення події
            await Task.Delay(500);
        }

        // Асинхронне моделювання життя факультету
        public async Task LifeOurFacultyAsync()
        {
            // Події тепер мають закріплений пріоритет
            var possibleEvents = new List<(string Name, EventPriority Priority)>
            {
                ("Модульний контроль", EventPriority.High),
                ("Студентська вечірка", EventPriority.Low),
                ("Перевірка з деканату", EventPriority.High),
                ("Наукова конференція", EventPriority.Normal)
            };

            for (int day = 1; day <= Days; day++)
            {
                List<FacultyEventArgs> todaysEvents = new List<FacultyEventArgs>();

                // З імовірністю 50% генеруємо від 1 до 3 подій за день
                if (rnd.NextDouble() < 0.5)
                {
                    int eventsCount = rnd.Next(1, 3);
                    for (int i = 0; i < eventsCount; i++)
                    {
                        var ev = possibleEvents[rnd.Next(possibleEvents.Count)];
                        todaysEvents.Add(new FacultyEventArgs(day, ev.Name, ev.Priority));
                    }
                }

                if (todaysEvents.Count > 0)
                {
                    // Сортуємо події дня за пріоритетом (від High до Low)
                    todaysEvents = todaysEvents.OrderByDescending(e => e.Priority).ToList();

                    // Додаємо відсортовані події у ЧЕРГУ
                    foreach (var ev in todaysEvents)
                    {
                        eventQueue.Enqueue(ev);

                        // Записуємо статистику
                        if (!Statistics.ContainsKey(ev.EventName))
                            Statistics[ev.EventName] = 0;
                        Statistics[ev.EventName]++;
                    }
                }
                else
                {
                    Console.WriteLine($"День {day}: Звичайний навчальний день. Усі на парах.");
                    await Task.Delay(300); // Імітація часу звичайного дня
                }

                // Обробляємо події з черги асинхронно
                while (eventQueue.Count > 0)
                {
                    var currentEvent = eventQueue.Dequeue();
                    await ProcessEventAsync(currentEvent);
                }
            }
        }
    }

    public abstract class FacultyMember
    {
        protected Faculty faculty;
        protected Random rnd = new Random();

        public FacultyMember(Faculty faculty)
        {
            this.faculty = faculty;
        }

        public void On()
        {
            faculty.FacultyEvent += new FacultyEventHandler(HandleEvent);
        }

        public void Off()
        {
            faculty.FacultyEvent -= new FacultyEventHandler(HandleEvent);
        }

        public abstract void HandleEvent(object sender, FacultyEventArgs e);
    }

    public class Student : FacultyMember
    {
        public Student(Faculty faculty) : base(faculty) { }

        public override void HandleEvent(object sender, FacultyEventArgs e)
        {
            if (e.EventName == "Модульний контроль")
                e.Result = rnd.Next(0, 10) > 3 ? "  > Студенти: Більшість успішно здали модулі!" : "  > Студенти: Доведеться йти на перездачу...";
            else if (e.EventName == "Студентська вечірка")
                e.Result = "  > Студенти: Чудово відпочили після пар!";
            else
                e.Result = "";
        }
    }

    public class Professor : FacultyMember
    {
        public Professor(Faculty faculty) : base(faculty) { }

        public override void HandleEvent(object sender, FacultyEventArgs e)
        {
            if (e.EventName == "Модульний контроль")
                e.Result = "  > Викладачі: Перевіряють гори робіт та виставляють бали.";
            else if (e.EventName == "Наукова конференція")
                e.Result = "  > Викладачі: Виступають з цікавими доповідями.";
            else
                e.Result = "";
        }
    }

    public class Deanery : FacultyMember
    {
        public Deanery(Faculty faculty) : base(faculty) { }

        public override void HandleEvent(object sender, FacultyEventArgs e)
        {
            if (e.EventName == "Перевірка з деканату")
                e.Result = rnd.Next(0, 10) > 4 ? "  > Деканат: Зауважень немає, навчальний процес іде за планом." : "  > Деканат: Виявлено порушення відвідуваності!";
            else
                e.Result = "";
        }
    }

    public class Lab10T
    {
        // Змінено на асинхронний запуск
        public async Task RunAsync()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Проект: Життя факультету (Асинхронна версія з чергами) ===\n");

            Faculty itFaculty = new Faculty("Інформаційних Технологій", 10);

            Student students = new Student(itFaculty);
            Professor professors = new Professor(itFaculty);
            Deanery deanery = new Deanery(itFaculty);

            students.On();
            professors.On();
            deanery.On();

            // Чекаємо завершення симуляції
            await itFaculty.LifeOurFacultyAsync();

            // Виведення статистики
            Console.WriteLine("\n================ СТАТИСТИКА ЗА ПЕРІОД ================");
            if (itFaculty.Statistics.Count == 0)
            {
                Console.WriteLine("За цей період не відбулося жодної події.");
            }
            else
            {
                foreach (var stat in itFaculty.Statistics.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"- {stat.Key}: {stat.Value} раз(ів)");
                }
            }
            Console.WriteLine("======================================================");

            Console.WriteLine("\nМоделювання завершено.");
        }
    }

    class Program
    {
        // Головний метод тепер асинхронний
        static async Task Main(string[] args)
        {
            Lab10T lab10task = new Lab10T();
            await lab10task.RunAsync();

            Console.ReadLine();
        }
    }
}
