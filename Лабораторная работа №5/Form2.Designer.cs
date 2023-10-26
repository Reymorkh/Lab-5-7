namespace Лабораторная_работа__5
{
  partial class Form2
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
      HeightButton = new Button();
      textBox1 = new TextBox();
      MainButton = new Button();
      MainLabel = new Label();
      PseudoMainButton = new Button();
      SuspendLayout();
      // 
      // HeightButton
      // 
      HeightButton.Location = new Point(121, 12);
      HeightButton.Name = "HeightButton";
      HeightButton.Size = new Size(108, 28);
      HeightButton.TabIndex = 1;
      HeightButton.Text = "Ввод параметра";
      HeightButton.UseVisualStyleBackColor = true;
      HeightButton.Click += HeightButton_Click;
      // 
      // textBox1
      // 
      textBox1.Location = new Point(15, 12);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(100, 23);
      textBox1.TabIndex = 2;
      // 
      // MainButton
      // 
      MainButton.Location = new Point(40, 5);
      MainButton.Name = "MainButton";
      MainButton.Size = new Size(151, 23);
      MainButton.TabIndex = 3;
      MainButton.Text = "Утвердить элементы";
      MainButton.UseVisualStyleBackColor = true;
      MainButton.Visible = false;
      MainButton.Click += MainButton_Click;
      // 
      // MainLabel
      // 
      MainLabel.AutoSize = true;
      MainLabel.Location = new Point(197, 9);
      MainLabel.Name = "MainLabel";
      MainLabel.Size = new Size(220, 15);
      MainLabel.TabIndex = 4;
      MainLabel.Text = "Введите длину каждой строки массива";
      MainLabel.Visible = false;
      // 
      // PseudoMainButton
      // 
      PseudoMainButton.Location = new Point(40, 5);
      PseudoMainButton.Name = "PseudoMainButton";
      PseudoMainButton.Size = new Size(151, 23);
      PseudoMainButton.TabIndex = 5;
      PseudoMainButton.Text = "Утвердить";
      PseudoMainButton.UseVisualStyleBackColor = true;
      PseudoMainButton.Visible = false;
      PseudoMainButton.Click += PseudoMainButton_Click;
      // 
      // Form2
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      AutoScroll = true;
      AutoSize = true;
      AutoSizeMode = AutoSizeMode.GrowAndShrink;
      ClientSize = new Size(476, 89);
      Controls.Add(PseudoMainButton);
      Controls.Add(MainLabel);
      Controls.Add(MainButton);
      Controls.Add(textBox1);
      Controls.Add(HeightButton);
      MaximumSize = new Size(816, 489);
      Name = "Form2";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Form2";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Button HeightButton;
    private TextBox textBox1;
    private Button MainButton;
    private Label MainLabel;
    private Button PseudoMainButton;
  }
}