using System;

namespace Lab5
{
    // Клас запечатаний (sealed) та частковий (partial)
    public sealed partial class Rectangle
    {
        // Змінні класу
        private int a, b;
        private int c;

        // Конструктори
        public Rectangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Rectangle() : this(0, 0, 0) { }
        public Rectangle(int size) : this(size, size, 1) { }
    }
}
