namespace Лабораторная_работа__5
{
  partial class Form4
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      button1 = new Button();
      textBox1 = new TextBox();
      label1 = new Label();
      button2 = new Button();
      SuspendLayout();
      // 
      // button1
      // 
      button1.Location = new Point(155, 42);
      button1.Name = "button1";
      button1.Size = new Size(75, 23);
      button1.TabIndex = 0;
      button1.Text = "Ввод";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // textBox1
      // 
      textBox1.Location = new Point(12, 42);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(137, 23);
      textBox1.TabIndex = 1;
      textBox1.KeyDown += textBox1_KeyDown;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(12, 9);
      label1.Name = "label1";
      label1.Size = new Size(242, 15);
      label1.TabIndex = 2;
      label1.Text = "Введите параметры массива через пробел";
      // 
      // button2
      // 
      button2.Location = new Point(12, 9);
      button2.Name = "button2";
      button2.Size = new Size(75, 23);
      button2.TabIndex = 3;
      button2.Text = "Утвердить";
      button2.UseVisualStyleBackColor = true;
      button2.Visible = false;
      button2.Click += button2_Click;
      // 
      // Form4
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      AutoScroll = true;
      AutoSize = true;
      ClientSize = new Size(283, 82);
      Controls.Add(button2);
      Controls.Add(label1);
      Controls.Add(textBox1);
      Controls.Add(button1);
      MaximumSize = new Size(520, 320);
      Name = "Form4";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Form4";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Button button1;
    private TextBox textBox1;
    private Label label1;
    private Button button2;
  }
}