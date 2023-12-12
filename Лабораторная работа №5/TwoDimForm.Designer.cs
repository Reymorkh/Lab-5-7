namespace Лабораторная_работа__5
{
  partial class TwoDimForm
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
      LengthEnterButton = new Button();
      LengthEnterTextBox = new TextBox();
      label1 = new Label();
      ConfirmationButton = new Button();
      SuspendLayout();
      // 
      // LengthEnterButton
      // 
      LengthEnterButton.Location = new Point(155, 42);
      LengthEnterButton.Name = "LengthEnterButton";
      LengthEnterButton.Size = new Size(75, 23);
      LengthEnterButton.TabIndex = 1;
      LengthEnterButton.Text = "Ввод";
      LengthEnterButton.UseVisualStyleBackColor = true;
      LengthEnterButton.Click += SetLength_Click;
      // 
      // LengthEnterTextBox
      // 
      LengthEnterTextBox.Location = new Point(12, 42);
      LengthEnterTextBox.Name = "LengthEnterTextBox";
      LengthEnterTextBox.Size = new Size(137, 23);
      LengthEnterTextBox.TabIndex = 0;
      LengthEnterTextBox.KeyDown += LengthEnterTextBox_KeyDown;
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
      // ConfirmationButton
      // 
      ConfirmationButton.Location = new Point(12, 9);
      ConfirmationButton.Name = "ConfirmationButton";
      ConfirmationButton.Size = new Size(75, 23);
      ConfirmationButton.TabIndex = 3;
      ConfirmationButton.Text = "Утвердить";
      ConfirmationButton.UseVisualStyleBackColor = true;
      ConfirmationButton.Visible = false;
      ConfirmationButton.Click += ConfirmationButton_Click;
      // 
      // TwoDimForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      AutoScroll = true;
      AutoSize = true;
      ClientSize = new Size(283, 82);
      Controls.Add(ConfirmationButton);
      Controls.Add(label1);
      Controls.Add(LengthEnterTextBox);
      Controls.Add(LengthEnterButton);
      MaximumSize = new Size(520, 320);
      Name = "TwoDimForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Двумерный массив";
      FormClosing += TwoDimForm_FormClosing;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Button LengthEnterButton;
    private TextBox LengthEnterTextBox;
    private Label label1;
    private Button ConfirmationButton;
  }
}