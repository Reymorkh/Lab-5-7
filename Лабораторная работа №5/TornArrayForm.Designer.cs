namespace Лабораторная_работа__5
{
  partial class TornArrayForm
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
      HeightBox = new TextBox();
      LengthButton = new Button();
      MainLabel = new Label();
      ConfirmationButton = new Button();
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
      // HeightBox
      // 
      HeightBox.Location = new Point(15, 12);
      HeightBox.Name = "HeightBox";
      HeightBox.Size = new Size(100, 23);
      HeightBox.TabIndex = 0;
      HeightBox.KeyDown += LengthEnterTextBox_KeyDown;
      // 
      // LengthButton
      // 
      LengthButton.Location = new Point(40, 5);
      LengthButton.Name = "LengthButton";
      LengthButton.Size = new Size(151, 23);
      LengthButton.TabIndex = 3;
      LengthButton.Text = "Утвердить длину";
      LengthButton.UseVisualStyleBackColor = true;
      LengthButton.Visible = false;
      LengthButton.Click += LengthButton_Click;
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
      // ConfirmationButton
      // 
      ConfirmationButton.Location = new Point(40, 5);
      ConfirmationButton.Name = "ConfirmationButton";
      ConfirmationButton.Size = new Size(151, 23);
      ConfirmationButton.TabIndex = 5;
      ConfirmationButton.Text = "Утвердить";
      ConfirmationButton.UseVisualStyleBackColor = true;
      ConfirmationButton.Visible = false;
      ConfirmationButton.Click += ConfirmationButton_Click;
      // 
      // TornArrayForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      AutoScroll = true;
      AutoSize = true;
      AutoSizeMode = AutoSizeMode.GrowAndShrink;
      ClientSize = new Size(476, 89);
      Controls.Add(MainLabel);
      Controls.Add(LengthButton);
      Controls.Add(HeightBox);
      Controls.Add(HeightButton);
      Controls.Add(ConfirmationButton);
      MaximumSize = new Size(816, 489);
      Name = "TornArrayForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Рваный массив";
      FormClosing += TornArrayForm_FormClosing;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Button HeightButton;
    private TextBox HeightBox;
    private Button LengthButton;
    private Label MainLabel;
    private Button ConfirmationButton;
  }
}