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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(872, 340);
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
    }
}