using System;
using System.Collections.Generic;

namespace lab10
{
  //Оголошення делегата, на основі якого буде визначена подія 
    public delegate void FacultyEventHandler(object sender, FacultyEventArgs e);

    //Клас, що задає вхідні й вихідні аргументи події 
    public class FacultyEventArgs : EventArgs
    {
        public int Day { get; }
        public string EventName { get; }
        public string Result { get; set; }

        public FacultyEventArgs(int day, string eventName)
        {
            Day = day;
            EventName = eventName;
        }
    }

    //Клас, у якім ініціюється подія
    public class Faculty
    {
        public string Name { get; }
        public int Days { get; }

       // Оголошення події з event
        public event FacultyEventHandler FacultyEvent;

        private Random rnd = new Random();
        private List<string> resultServices;

        public Faculty(string name, int days)
        {
            Name = name;
            Days = days;
        }

        // Метод, де запалюється подія і викликаються оброблювачі
        protected virtual void OnFacultyEvent(FacultyEventArgs e)
        {
            Console.WriteLine($"\n--- День {e.Day}: На факультеті '{Name}' розпочалася подія: [{e.EventName}] ---");

            if (FacultyEvent != null)
            {
              
                Delegate[] handlers = FacultyEvent.GetInvocationList();
                resultServices = new List<string>();

                foreach (FacultyEventHandler handler in handlers)
                {
                    handler(this, e); 
                    if (!string.IsNullOrEmpty(e.Result))
                    {
                        resultServices.Add(e.Result);
                    }
                }
            }
        }

        // Моделювання життя факультету
        public void LifeOurFaculty()
        {
            string[] possibleEvents = { "Модульний контроль", "Студентська вечірка", "Перевірка з деканату", "Наукова конференція" };

            for (int day = 1; day <= Days; day++)
            {
                // З імовірністю 40% кожного дня щось відбувається
                if (rnd.NextDouble() < 0.4)
                {
                    string randomEvent = possibleEvents[rnd.Next(possibleEvents.Length)];
                    FacultyEventArgs e = new FacultyEventArgs(day, randomEvent);
                    OnFacultyEvent(e);

                    if (resultServices != null)
                    {
                        foreach (string res in resultServices)
                        {
                            Console.WriteLine(res);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"День {day}: Звичайний навчальний день. Усі на парах.");
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

      // Підключення до спостереження за подіями 
        public void On()
        {
            faculty.FacultyEvent += new FacultyEventHandler(HandleEvent);
        }

        // Відключення 
        public void Off()
        {
            faculty.FacultyEvent -= new FacultyEventHandler(HandleEvent);
        }

        public abstract void HandleEvent(object sender, FacultyEventArgs e);
    }

    //Конкретні підписники, які реагують на події

    public class Student : FacultyMember
    {
        public Student(Faculty faculty) : base(faculty) { }

        public override void HandleEvent(object sender, FacultyEventArgs e)
        {
            if (e.EventName == "Модульний контроль")
            {
                e.Result = rnd.Next(0, 10) > 3 ? "  > Студенти: Більшість успішно здали модулі!" : "  > Студенти: Доведеться йти на перездачу...";
            }
            else if (e.EventName == "Студентська вечірка")
            {
                e.Result = "  > Студенти: Чудово відпочили після пар!";
            }
            else
            {
                e.Result = "";
            }
        }
    }

    public class Professor : FacultyMember
    {
        public Professor(Faculty faculty) : base(faculty) { }

        public override void HandleEvent(object sender, FacultyEventArgs e)
        {
            if (e.EventName == "Модульний контроль")
            {
                e.Result = "  > Викладачі: Перевіряють гори робіт та виставляють бали.";
            }
            else if (e.EventName == "Наукова конференція")
            {
                e.Result = "  > Викладачі: Виступають з цікавими доповідями.";
            }
            else
            {
                e.Result = "";
            }
        }
    }

    public class Deanery : FacultyMember
    {
        public Deanery(Faculty faculty) : base(faculty) { }

        public override void HandleEvent(object sender, FacultyEventArgs e)
        {
            if (e.EventName == "Перевірка з деканату")
            {
                e.Result = rnd.Next(0, 10) > 4 ? "  > Деканат: Зауважень немає, навчальний процес іде за планом." : "  > Деканат: Виявлено порушення відвідуваності!";
            }
            else
            {
                e.Result = "";
            }
        }
    }

   
    public class Lab10T
    {
        public void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Проект: Життя факультету ===\n");

            
            Faculty itFaculty = new Faculty("Інформаційних Технологій", 10);

           
            Student students = new Student(itFaculty);
            Professor professors = new Professor(itFaculty);
            Deanery deanery = new Deanery(itFaculty);

           
            students.On();
            professors.On();
            deanery.On();

           
            itFaculty.LifeOurFaculty();

            Console.WriteLine("\nМоделювання завершено.");
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
           
            Lab10T lab10task = new Lab10T();
            lab10task.Run();

            Console.ReadLine();
        }
    }
}
