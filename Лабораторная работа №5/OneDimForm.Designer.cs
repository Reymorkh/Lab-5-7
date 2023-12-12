namespace Лабораторная_работа__5
{
  partial class OneDimForm
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
      LengthEnterLabel = new Label();
      ConfirmationButton = new Button();
      SuspendLayout();
      // 
      // LengthEnterButton
      // 
      LengthEnterButton.Location = new Point(222, 45);
      LengthEnterButton.Name = "LengthEnterButton";
      LengthEnterButton.Size = new Size(75, 23);
      LengthEnterButton.TabIndex = 1;
      LengthEnterButton.Text = "Ввод";
      LengthEnterButton.UseVisualStyleBackColor = true;
      LengthEnterButton.Click += LengthEnterButton_Click;
      // 
      // LengthEnterTextBox
      // 
      LengthEnterTextBox.Location = new Point(12, 45);
      LengthEnterTextBox.Name = "LengthEnterTextBox";
      LengthEnterTextBox.Size = new Size(204, 23);
      LengthEnterTextBox.TabIndex = 0;
      LengthEnterTextBox.KeyDown += LengthEnterTextBox_KeyDown;
      // 
      // LengthEnterLabel
      // 
      LengthEnterLabel.AutoSize = true;
      LengthEnterLabel.Location = new Point(39, 18);
      LengthEnterLabel.Name = "LengthEnterLabel";
      LengthEnterLabel.Size = new Size(135, 15);
      LengthEnterLabel.TabIndex = 2;
      LengthEnterLabel.Text = "Введите длину массива";
      // 
      // ConfirmationButton
      // 
      ConfirmationButton.Location = new Point(12, 10);
      ConfirmationButton.Name = "ConfirmationButton";
      ConfirmationButton.Size = new Size(93, 23);
      ConfirmationButton.TabIndex = 3;
      ConfirmationButton.Text = "Утвердить";
      ConfirmationButton.UseVisualStyleBackColor = true;
      ConfirmationButton.Visible = false;
      ConfirmationButton.Click += ConfirmationButton_Click;
      // 
      // OneDimForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      AutoScroll = true;
      AutoSize = true;
      ClientSize = new Size(305, 101);
      Controls.Add(ConfirmationButton);
      Controls.Add(LengthEnterLabel);
      Controls.Add(LengthEnterTextBox);
      Controls.Add(LengthEnterButton);
      MaximumSize = new Size(600, 150);
      Name = "OneDimForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Одномерный массив";
      FormClosing += OneDimForm_FormClosing;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Button LengthEnterButton;
    private TextBox LengthEnterTextBox;
    private Label LengthEnterLabel;
    private Button ConfirmationButton;
  }
}