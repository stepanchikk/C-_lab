using System;

namespace Lab5
{
    public sealed partial class Rectangle
    {
        // Індексатор
        public int this[int index]
        {
            get
            {
                if (index == 0) return a;
                if (index == 1) return b;
                if (index == 2) return c;
                throw new IndexOutOfRangeException("Помилка: невірний індекс!");
            }
            set
            {
                if (index == 0) a = value;
                else if (index == 1) b = value;
                else if (index == 2) c = value;
                else throw new IndexOutOfRangeException("Помилка: невірний індекс!");
            }
        }

        // Перевантаження операторів
        public static Rectangle operator ++(Rectangle r) { r.a++; r.b++; return r; }
        public static Rectangle operator --(Rectangle r) { r.a--; r.b--; return r; }
        public static bool operator true(Rectangle r) => r.a == r.b;
        public static bool operator false(Rectangle r) => r.a != r.b;
        public static Rectangle operator *(Rectangle r, int scalar) => new Rectangle(r.a * scalar, r.b * scalar, r.c);

        // Перетворення типів
        public static implicit operator string(Rectangle r) => $"{r.a},{r.b},{r.c}";
        public static explicit operator Rectangle(string s)
        {
            var parts = s.Split(',');
            return new Rectangle(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
        }

        public override string ToString() => $"Прямокутник {a}x{b}, колір {c}";
    }
}
