using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        private enum TimeFormat { Decimal, Binary, Hex }
        private TimeFormat currentFormat = TimeFormat.Decimal;

       
        private Bitmap originalImage;
        private Bitmap currentImage;

      
        private List<Figure> figuresList = new List<Figure>();
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            
            timer1.Tick += Timer1_Tick;
            btnDec.Click += (s, e) => { currentFormat = TimeFormat.Decimal; UpdateTime(); };
            btnBin.Click += (s, e) => { currentFormat = TimeFormat.Binary; UpdateTime(); };
            btnHex.Click += (s, e) => { currentFormat = TimeFormat.Hex; UpdateTime(); };

            
            btnLoad.Click += BtnLoad_Click;
            btnSave.Click += BtnSave_Click;
            btnApply.Click += BtnApply_Click;
            btnResetImage.Click += BtnResetImage_Click; 
            rbFull.Checked = true;

            
            btnAddDraw.Click += BtnAddDraw_Click;
            btnClear.Click += BtnClear_Click;
            cbFigureType.SelectedIndex = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            int seconds = DateTime.Now.Second;

            switch (currentFormat)
            {
                case TimeFormat.Decimal:
                    lblSeconds.Text = $"Десятковий: {seconds}";
                    break;
                case TimeFormat.Binary:
                    lblSeconds.Text = $"Бінарний: {Convert.ToString(seconds, 2).PadLeft(6, '0')}";
                    break;
                case TimeFormat.Hex:
                    lblSeconds.Text = $"Шістнадцятковий: {Convert.ToString(seconds, 16).ToUpper()}";
                    break;
            }
        }

      
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "BMP Images|*.bmp|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage = new Bitmap(ofd.FileName);
                    currentImage = new Bitmap(originalImage);
                    pictureBoxImage.Image = currentImage;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentImage == null) return;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "BMP Images|*.bmp";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    currentImage.Save(sfd.FileName, ImageFormat.Bmp);
                }
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

           
            currentImage = new Bitmap(originalImage);

            for (int y = 0; y < currentImage.Height; y++)
            {
                for (int x = 0; x < currentImage.Width; x++)
                {
                    Color p = currentImage.GetPixel(x, y);
                    int r = p.R, g = p.G, b = p.B;

                    if (rbFull.Checked) { r = 255 - r; g = 255 - g; b = 255 - b; }
                    else if (rbRed.Checked) { r = 255 - r; }
                    else if (rbGreen.Checked) { g = 255 - g; }
                    else if (rbBlue.Checked) { b = 255 - b; }

                    currentImage.SetPixel(x, y, Color.FromArgb(p.A, r, g, b));
                }
            }
            pictureBoxImage.Image = currentImage;
        }

        
        private void BtnResetImage_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;

            // Замінюємо поточне зображення чистою копією оригіналу
            currentImage = new Bitmap(originalImage);
            pictureBoxImage.Image = currentImage;
        }

        
        private void BtnAddDraw_Click(object sender, EventArgs e)
        {
            int w = pictureBoxCanvas.Width;
            int h = pictureBoxCanvas.Height;
            if (w == 0 || h == 0) return;


            int x = rand.Next(10, w - 100);
            int y = rand.Next(10, h - 50);
            int size = rand.Next(30, 80);
            Color rndColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            Figure newFigure = null;

           
            if (cbFigureType.SelectedIndex == 0)
                newFigure = new Circle(x, y, size, rndColor);
            else if (cbFigureType.SelectedIndex == 1)
                newFigure = new Square(x, y, size, rndColor);
            else if (cbFigureType.SelectedIndex == 2)
            {
                string txt = string.IsNullOrWhiteSpace(txtFigureText.Text) ? "Текст" : txtFigureText.Text;
                newFigure = new TextRectangle(x, y, size, rndColor, txt);
            }

            if (newFigure != null)
            {
                figuresList.Add(newFigure);
                DrawAllFigures();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            figuresList.Clear();
            pictureBoxCanvas.Image = null;
        }

        private void DrawAllFigures()
        {
            Bitmap bmp = new Bitmap(pictureBoxCanvas.Width, pictureBoxCanvas.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                foreach (var fig in figuresList)
                {
                    fig.Draw(g); // Поліморфний виклик віртуального методу
                }
            }
            pictureBoxCanvas.Image = bmp;
        }
    }

   
    public abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; set; }
        public Color FillColor { get; set; }

        public Figure(int x, int y, int size, Color color)
        {
            X = x; Y = y; Size = size; FillColor = color;
        }

        public abstract void Draw(Graphics g);

        public virtual void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    // Похідний клас: Коло
    public class Circle : Figure
    {
        public Circle(int x, int y, int size, Color color) : base(x, y, size, color) { }

        public override void Draw(Graphics g)
        {
            using (Brush b = new SolidBrush(FillColor))
            {
                g.FillEllipse(b, X, Y, Size, Size);
            }
        }
    }

    // Похідний клас: Квадрат
    public class Square : Figure
    {
        public Square(int x, int y, int size, Color color) : base(x, y, size, color) { }

        public override void Draw(Graphics g)
        {
            using (Brush b = new SolidBrush(FillColor))
            {
                g.FillRectangle(b, X, Y, Size, Size);
            }
        }
    }

    // Похідний клас: Прямокутник з текстом
    public class TextRectangle : Figure
    {
        public string InnerText { get; set; }

        public TextRectangle(int x, int y, int size, Color color, string text) : base(x, y, size, color)
        {
            InnerText = text;
        }

        public override void Draw(Graphics g)
        {
            int rectWidth = Size * 2;

            using (Brush b = new SolidBrush(FillColor))
            {
                g.FillRectangle(b, X, Y, rectWidth, Size);
            }

            using (Brush textBrush = new SolidBrush(Color.Black))
            using (Font font = new Font("Arial", 10, FontStyle.Bold))
            {
                SizeF textSize = g.MeasureString(InnerText, font);
                float textX = X + (rectWidth - textSize.Width) / 2;
                float textY = Y + (Size - textSize.Height) / 2;

                g.DrawString(InnerText, font, textBrush, textX, textY);
            }
        }
    }
}
