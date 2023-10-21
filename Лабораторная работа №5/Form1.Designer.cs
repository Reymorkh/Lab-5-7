namespace Лабораторная_работа__5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TornCreateButton = new Button();
            MainWindow = new TextBox();
            OneDimCreateButton = new Button();
            TwoDimCreateButton = new Button();
            label1 = new Label();
            OneDimPrintButton = new Button();
            TwoDimPrintButton = new Button();
            TornPrintButton = new Button();
            label2 = new Label();
            OneDimFillButton = new Button();
            TwoDimFillButton = new Button();
            TornFillButton = new Button();
            label3 = new Label();
            Task1Button = new Button();
            Task2Button = new Button();
            Task3Button = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            SuspendLayout();
            // 
            // TornCreateButton
            // 
            TornCreateButton.Location = new Point(569, 112);
            TornCreateButton.Name = "TornCreateButton";
            TornCreateButton.Size = new Size(92, 23);
            TornCreateButton.TabIndex = 3;
            TornCreateButton.Text = "Рваный";
            TornCreateButton.UseVisualStyleBackColor = true;
            TornCreateButton.Click += FillTornArray_Click;
            // 
            // MainWindow
            // 
            MainWindow.Location = new Point(29, 29);
            MainWindow.Multiline = true;
            MainWindow.Name = "MainWindow";
            MainWindow.ScrollBars = ScrollBars.Both;
            MainWindow.Size = new Size(482, 278);
            MainWindow.TabIndex = 0;
            // 
            // OneDimCreateButton
            // 
            OneDimCreateButton.Location = new Point(569, 54);
            OneDimCreateButton.Name = "OneDimCreateButton";
            OneDimCreateButton.Size = new Size(92, 23);
            OneDimCreateButton.TabIndex = 1;
            OneDimCreateButton.Text = "Одномерный";
            OneDimCreateButton.UseVisualStyleBackColor = true;
            OneDimCreateButton.Click += OneDimCreateButton_Click;
            // 
            // TwoDimCreateButton
            // 
            TwoDimCreateButton.Location = new Point(569, 83);
            TwoDimCreateButton.Name = "TwoDimCreateButton";
            TwoDimCreateButton.Size = new Size(92, 23);
            TwoDimCreateButton.TabIndex = 2;
            TwoDimCreateButton.Text = "Двумерный";
            TwoDimCreateButton.UseVisualStyleBackColor = true;
            TwoDimCreateButton.Click += TwoDimCreateButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(584, 29);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 10;
            label1.Text = "Построить";
            // 
            // OneDimPrintButton
            // 
            OneDimPrintButton.Location = new Point(667, 54);
            OneDimPrintButton.Name = "OneDimPrintButton";
            OneDimPrintButton.Size = new Size(93, 23);
            OneDimPrintButton.TabIndex = 4;
            OneDimPrintButton.Text = "Одномерный";
            OneDimPrintButton.UseVisualStyleBackColor = true;
            OneDimPrintButton.Click += OneDimPrintButton_Click;
            // 
            // TwoDimPrintButton
            // 
            TwoDimPrintButton.Location = new Point(667, 83);
            TwoDimPrintButton.Name = "TwoDimPrintButton";
            TwoDimPrintButton.Size = new Size(93, 23);
            TwoDimPrintButton.TabIndex = 5;
            TwoDimPrintButton.Text = "Двумерный";
            TwoDimPrintButton.UseVisualStyleBackColor = true;
            TwoDimPrintButton.Click += TwoDimPrintButton_Click;
            // 
            // TornPrintButton
            // 
            TornPrintButton.Location = new Point(667, 112);
            TornPrintButton.Name = "TornPrintButton";
            TornPrintButton.Size = new Size(93, 23);
            TornPrintButton.TabIndex = 6;
            TornPrintButton.Text = "Рваный";
            TornPrintButton.UseVisualStyleBackColor = true;
            TornPrintButton.Click += TornPrintButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(691, 32);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 11;
            label2.Text = "Печать";
            // 
            // OneDimFillButton
            // 
            OneDimFillButton.Location = new Point(766, 54);
            OneDimFillButton.Name = "OneDimFillButton";
            OneDimFillButton.Size = new Size(90, 23);
            OneDimFillButton.TabIndex = 7;
            OneDimFillButton.Text = "Одномерный";
            OneDimFillButton.UseVisualStyleBackColor = true;
            OneDimFillButton.Click += OneDimFillButton_Click;
            // 
            // TwoDimFillButton
            // 
            TwoDimFillButton.Location = new Point(766, 83);
            TwoDimFillButton.Name = "TwoDimFillButton";
            TwoDimFillButton.Size = new Size(90, 23);
            TwoDimFillButton.TabIndex = 8;
            TwoDimFillButton.Text = "Двумерный";
            TwoDimFillButton.UseVisualStyleBackColor = true;
            TwoDimFillButton.Click += TwoDimFillButton_Click;
            // 
            // TornFillButton
            // 
            TornFillButton.Location = new Point(766, 112);
            TornFillButton.Name = "TornFillButton";
            TornFillButton.Size = new Size(90, 23);
            TornFillButton.TabIndex = 9;
            TornFillButton.Text = "Рваный";
            TornFillButton.UseVisualStyleBackColor = true;
            TornFillButton.Click += TornFillButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(781, 32);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 12;
            label3.Text = "Заполнить";
            // 
            // Task1Button
            // 
            Task1Button.Location = new Point(766, 207);
            Task1Button.Name = "Task1Button";
            Task1Button.Size = new Size(90, 23);
            Task1Button.TabIndex = 13;
            Task1Button.Text = "Одномерный";
            Task1Button.UseVisualStyleBackColor = true;
            Task1Button.Click += Task1Button_Click;
            // 
            // Task2Button
            // 
            Task2Button.Location = new Point(766, 236);
            Task2Button.Name = "Task2Button";
            Task2Button.Size = new Size(90, 23);
            Task2Button.TabIndex = 14;
            Task2Button.Text = "Двумерный";
            Task2Button.UseVisualStyleBackColor = true;
            // 
            // Task3Button
            // 
            Task3Button.Location = new Point(766, 265);
            Task3Button.Name = "Task3Button";
            Task3Button.Size = new Size(90, 23);
            Task3Button.TabIndex = 15;
            Task3Button.Text = "Рваный";
            Task3Button.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(569, 211);
            label4.Name = "label4";
            label4.Size = new Size(192, 15);
            label4.TabIndex = 16;
            label4.Text = "Удалить первый чётный элемент:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(569, 240);
            label5.Name = "label5";
            label5.Size = new Size(166, 15);
            label5.TabIndex = 17;
            label5.Text = "Добавить строку с номером:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(569, 269);
            label6.Name = "label6";
            label6.Size = new Size(187, 15);
            label6.TabIndex = 18;
            label6.Text = "Удалить самую длинную строку:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(658, 178);
            label7.Name = "label7";
            label7.Size = new Size(114, 15);
            label7.TabIndex = 19;
            label7.Text = "Задания варианта 1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 340);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(Task3Button);
            Controls.Add(Task2Button);
            Controls.Add(Task1Button);
            Controls.Add(label3);
            Controls.Add(TornFillButton);
            Controls.Add(TwoDimFillButton);
            Controls.Add(OneDimFillButton);
            Controls.Add(label2);
            Controls.Add(TornPrintButton);
            Controls.Add(TwoDimPrintButton);
            Controls.Add(OneDimPrintButton);
            Controls.Add(label1);
            Controls.Add(TwoDimCreateButton);
            Controls.Add(OneDimCreateButton);
            Controls.Add(MainWindow);
            Controls.Add(TornCreateButton);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TornCreateButton;
        private TextBox MainWindow;
        private Button OneDimCreateButton;
        private Button TwoDimCreateButton;
        private Label label1;
        private Button OneDimPrintButton;
        private Button TwoDimPrintButton;
        private Button TornPrintButton;
        private Label label2;
        private Button OneDimFillButton;
        private Button TwoDimFillButton;
        private Button TornFillButton;
        private Label label3;
        private Button Task1Button;
        private Button Task2Button;
        private Button Task3Button;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}