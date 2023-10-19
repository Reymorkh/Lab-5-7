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
            FillArray = new Button();
            HeightBox = new TextBox();
            EnterButton = new Button();
            SuspendLayout();
            // 
            // FillArray
            // 
            FillArray.Location = new Point(606, 284);
            FillArray.Name = "FillArray";
            FillArray.Size = new Size(75, 23);
            FillArray.TabIndex = 0;
            FillArray.Text = "Заполнить";
            FillArray.UseVisualStyleBackColor = true;
            FillArray.Click += FillArray_Click;
            // 
            // HeightBox
            // 
            HeightBox.Location = new Point(157, 314);
            HeightBox.Name = "HeightBox";
            HeightBox.Size = new Size(148, 23);
            HeightBox.TabIndex = 1;
            // 
            // EnterButton
            // 
            EnterButton.Location = new Point(311, 314);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(75, 23);
            EnterButton.TabIndex = 2;
            EnterButton.Text = "Enter";
            EnterButton.UseVisualStyleBackColor = true;
            EnterButton.Click += EnterButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(EnterButton);
            Controls.Add(HeightBox);
            Controls.Add(FillArray);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button FillArray;
        private TextBox HeightBox;
        private Button EnterButton;
    }
}