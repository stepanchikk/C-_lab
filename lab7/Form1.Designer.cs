namespace lab7
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnHex = new System.Windows.Forms.Button();
            this.btnBin = new System.Windows.Forms.Button();
            this.btnDec = new System.Windows.Forms.Button();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnResetImage = new System.Windows.Forms.Button();
            this.groupBoxInvert = new System.Windows.Forms.GroupBox();
            this.rbBlue = new System.Windows.Forms.RadioButton();
            this.rbGreen = new System.Windows.Forms.RadioButton();
            this.rbRed = new System.Windows.Forms.RadioButton();
            this.rbFull = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddDraw = new System.Windows.Forms.Button();
            this.txtFigureText = new System.Windows.Forms.TextBox();
            this.cbFigureType = new System.Windows.Forms.ComboBox();
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);

            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxInvert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            this.SuspendLayout();

            // tabControl1
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 461);
            this.tabControl1.TabIndex = 0;

            // tabPage1
            this.tabPage1.Controls.Add(this.btnHex);
            this.tabPage1.Controls.Add(this.btnBin);
            this.tabPage1.Controls.Add(this.btnDec);
            this.tabPage1.Controls.Add(this.lblSeconds);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Завдання 1";
            this.tabPage1.UseVisualStyleBackColor = true;

            // btnHex
            this.btnHex.Location = new System.Drawing.Point(500, 200);
            this.btnHex.Name = "btnHex";
            this.btnHex.Size = new System.Drawing.Size(150, 40);
            this.btnHex.TabIndex = 3;
            this.btnHex.Text = "Шістнадцятковий";
            this.btnHex.UseVisualStyleBackColor = true;

            // btnBin
            this.btnBin.Location = new System.Drawing.Point(300, 200);
            this.btnBin.Name = "btnBin";
            this.btnBin.Size = new System.Drawing.Size(150, 40);
            this.btnBin.TabIndex = 2;
            this.btnBin.Text = "Бінарний";
            this.btnBin.UseVisualStyleBackColor = true;

            // btnDec
            this.btnDec.Location = new System.Drawing.Point(100, 200);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(150, 40);
            this.btnDec.TabIndex = 1;
            this.btnDec.Text = "Десятковий";
            this.btnDec.UseVisualStyleBackColor = true;

            // lblSeconds
            this.lblSeconds.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSeconds.Location = new System.Drawing.Point(100, 80);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(550, 50);
            this.lblSeconds.TabIndex = 0;
            this.lblSeconds.Text = "Час: ";
            this.lblSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // tabPage2
            this.tabPage2.Controls.Add(this.btnResetImage);
            this.tabPage2.Controls.Add(this.groupBoxInvert);
            this.tabPage2.Controls.Add(this.btnApply);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.btnLoad);
            this.tabPage2.Controls.Add(this.pictureBoxImage);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Завдання 2";
            this.tabPage2.UseVisualStyleBackColor = true;

            // btnResetImage
            this.btnResetImage.Location = new System.Drawing.Point(550, 250);
            this.btnResetImage.Name = "btnResetImage";
            this.btnResetImage.Size = new System.Drawing.Size(200, 40);
            this.btnResetImage.TabIndex = 5;
            this.btnResetImage.Text = "Початковий стан";
            this.btnResetImage.UseVisualStyleBackColor = true;

            // groupBoxInvert
            this.groupBoxInvert.Controls.Add(this.rbBlue);
            this.groupBoxInvert.Controls.Add(this.rbGreen);
            this.groupBoxInvert.Controls.Add(this.rbRed);
            this.groupBoxInvert.Controls.Add(this.rbFull);
            this.groupBoxInvert.Location = new System.Drawing.Point(550, 20);
            this.groupBoxInvert.Name = "groupBoxInvert";
            this.groupBoxInvert.Size = new System.Drawing.Size(200, 150);
            this.groupBoxInvert.TabIndex = 4;
            this.groupBoxInvert.TabStop = false;
            this.groupBoxInvert.Text = "Режим інверсії";

            // rbBlue
            this.rbBlue.AutoSize = true;
            this.rbBlue.Location = new System.Drawing.Point(15, 110);
            this.rbBlue.Name = "rbBlue";
            this.rbBlue.Size = new System.Drawing.Size(121, 19);
            this.rbBlue.TabIndex = 3;
            this.rbBlue.Text = "Інверсія синього";
            this.rbBlue.UseVisualStyleBackColor = true;

            // rbGreen
            this.rbGreen.AutoSize = true;
            this.rbGreen.Location = new System.Drawing.Point(15, 85);
            this.rbGreen.Name = "rbGreen";
            this.rbGreen.Size = new System.Drawing.Size(124, 19);
            this.rbGreen.TabIndex = 2;
            this.rbGreen.Text = "Інверсія зеленого";
            this.rbGreen.UseVisualStyleBackColor = true;

            // rbRed
            this.rbRed.AutoSize = true;
            this.rbRed.Location = new System.Drawing.Point(15, 60);
            this.rbRed.Name = "rbRed";
            this.rbRed.Size = new System.Drawing.Size(130, 19);
            this.rbRed.TabIndex = 1;
            this.rbRed.Text = "Інверсія червоного";
            this.rbRed.UseVisualStyleBackColor = true;

            // rbFull
            this.rbFull.AutoSize = true;
            this.rbFull.Checked = true;
            this.rbFull.Location = new System.Drawing.Point(15, 35);
            this.rbFull.Name = "rbFull";
            this.rbFull.Size = new System.Drawing.Size(108, 19);
            this.rbFull.TabIndex = 0;
            this.rbFull.TabStop = true;
            this.rbFull.Text = "Повна інверсія";
            this.rbFull.UseVisualStyleBackColor = true;

            // btnApply
            this.btnApply.Location = new System.Drawing.Point(550, 190);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(200, 40);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Застосувати інверсію";
            this.btnApply.UseVisualStyleBackColor = true;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(550, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;

            // btnLoad
            this.btnLoad.Location = new System.Drawing.Point(550, 310);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(200, 40);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Завантажити";
            this.btnLoad.UseVisualStyleBackColor = true;

            // pictureBoxImage
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImage.Location = new System.Drawing.Point(20, 20);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.Size = new System.Drawing.Size(500, 380);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;

            // tabPage3
            this.tabPage3.Controls.Add(this.btnClear);
            this.tabPage3.Controls.Add(this.btnAddDraw);
            this.tabPage3.Controls.Add(this.txtFigureText);
            this.tabPage3.Controls.Add(this.cbFigureType);
            this.tabPage3.Controls.Add(this.pictureBoxCanvas);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(776, 433);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Завдання 3";
            this.tabPage3.UseVisualStyleBackColor = true;

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(600, 160);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 40);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Очистити";
            this.btnClear.UseVisualStyleBackColor = true;

            // btnAddDraw
            this.btnAddDraw.Location = new System.Drawing.Point(600, 110);
            this.btnAddDraw.Name = "btnAddDraw";
            this.btnAddDraw.Size = new System.Drawing.Size(150, 40);
            this.btnAddDraw.TabIndex = 3;
            this.btnAddDraw.Text = "Додати та Намалювати";
            this.btnAddDraw.UseVisualStyleBackColor = true;

            // txtFigureText
            this.txtFigureText.Location = new System.Drawing.Point(600, 70);
            this.txtFigureText.Name = "txtFigureText";
            this.txtFigureText.PlaceholderText = "Текст для прямокутника";
            this.txtFigureText.Size = new System.Drawing.Size(150, 23);
            this.txtFigureText.TabIndex = 2;

            // cbFigureType
            this.cbFigureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFigureType.FormattingEnabled = true;
            this.cbFigureType.Items.AddRange(new object[] {
            "Коло",
            "Квадрат",
            "Прямокутник з текстом"});
            this.cbFigureType.Location = new System.Drawing.Point(600, 30);
            this.cbFigureType.Name = "cbFigureType";
            this.cbFigureType.Size = new System.Drawing.Size(150, 23);
            this.cbFigureType.TabIndex = 1;

            // pictureBoxCanvas
            this.pictureBoxCanvas.BackColor = System.Drawing.Color.White;
            this.pictureBoxCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(20, 20);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(550, 380);
            this.pictureBoxCanvas.TabIndex = 0;
            this.pictureBoxCanvas.TabStop = false;

            // timer1
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Лабораторна робота 7 (Варіант 23)";

            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBoxInvert.ResumeLayout(false);
            this.groupBoxInvert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnHex;
        private System.Windows.Forms.Button btnBin;
        private System.Windows.Forms.Button btnDec;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnResetImage; // Додано кнопку скидання
        private System.Windows.Forms.GroupBox groupBoxInvert;
        private System.Windows.Forms.RadioButton rbBlue;
        private System.Windows.Forms.RadioButton rbGreen;
        private System.Windows.Forms.RadioButton rbRed;
        private System.Windows.Forms.RadioButton rbFull;
        private System.Windows.Forms.PictureBox pictureBoxCanvas;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddDraw;
        private System.Windows.Forms.TextBox txtFigureText;
        private System.Windows.Forms.ComboBox cbFigureType;
        private System.Windows.Forms.Timer timer1;
    }
}
