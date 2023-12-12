using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using Label = System.Windows.Forms.Label;
using static MyLibStructWF.ArrayTypes;
using static Лабораторная_работа__5.BusinessLogic;

namespace Лабораторная_работа__5
{
  public partial class OneDimForm : Form
  {
    public OneDimForm()
    {
      InitializeComponent();
      if (MainMenu.isEdit == true)
      {
        OneDimTemp.array = Copy(OneDimMain.array);
        LengthEnterButton.Visible = false;
        LengthEnterTextBox.Visible = false;
        LengthEnterLabel.Visible = false;
        ConfirmationButton.Visible = true;
        Printer();
      }
    }

    public void Printer()
    {
      PrintBoxes(OneDimTemp.array);
      foreach (var s in textBoxes)
        Controls.Add(s);
      foreach (var s in labels)
        Controls.Add(s);
    }

    private void LengthEnterButton_Click(object sender, EventArgs e)
    {
      if (int.TryParse(LengthEnterTextBox.Text, out int length) && length > -1)
      {
        OneDimTemp.array = SetArrayLength(length);
        if (length == 0)
        {
          OneDimMain = OneDimTemp;
          this.Close();
        }
        LengthEnterLabel.Visible = false;
        LengthEnterTextBox.Visible = false;
        LengthEnterButton.Visible = false;
        ConfirmationButton.Visible = true;
        Printer();
      }
      else
        MessageBox.Show("Integer больше нуля, пожалуйста.", "Ошибка");
    }

    private void LengthEnterTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        LengthEnterButton_Click(sender, e);
      }
    }

    private void ConfirmationButton_Click(object sender, EventArgs e)
    {
      if (OneDimBoxesCheck)
      {
        BoxesToArray(OneDimTemp.array);
        OneDimMain.array = Copy(OneDimTemp.array);
        this.Close();
      }
      else
      {
        DialogResult dialogResult = MessageBox.Show("Вы хотите записать введённые параметры в элементы массива? Значения не типа integer будут записаны как нули.", "Предупреждение", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
          BoxesToArray(OneDimTemp.array);
          OneDimMain.array = Copy(OneDimTemp.array);
          this.Close();
        }
      }
    }

    private void OneDimForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      textBoxes.Clear();
      labels.Clear();
      this.Dispose();
    }
  }
}