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
  public partial class TwoDimForm : Form
  {
    public void Printer()
    {
      PrintBoxes(TwoDimTemp.array);
      foreach (var s in textBoxes)
        Controls.Add(s);
      foreach (var s in labels)
        Controls.Add(s);
    }

    public TwoDimForm()
    {
      InitializeComponent();
      if (MainMenu.isEdit == true)
      {
        TwoDimTemp.array = Copy(TwoDimMain.array);
        LengthEnterButton.Visible = false;
        LengthEnterTextBox.Visible = false;
        label1.Visible = false;
        ConfirmationButton.Visible = true;
        Printer();
      }
    }

    private void SetLength_Click(object sender, EventArgs e)
    {
      if (TwoDimParamCheck(LengthEnterTextBox.Text, out int param1, out int param2))
      {
        if (param1 == 0 | param2 == 0) 
        { 
          TwoDimMain.array = SetArrayLength(param1, param2);
          this.Close();
      }
        TwoDimTemp.array = SetArrayLength(param1, param2);
        LengthEnterButton.Visible = false;
        ConfirmationButton.Visible = true;
        label1.Visible = false;
        LengthEnterTextBox.Visible = false;
        Printer();
      }
      else
        MessageBox.Show("Ввод некорректен, введите 2 параметра длины массива больше нуля и типа integer.", "Ошибка");
      
    }

    private void LengthEnterTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      var textBox = sender as TextBox;
      if (e.KeyCode == Keys.Enter)
      {
        SetLength_Click(sender, e);
      }
    }

    private void ConfirmationButton_Click(object sender, EventArgs e)
    {
      if (TwoDimBoxesCheck)
      {
        BoxesToArray(TwoDimTemp.array);
        TwoDimMain.array = Copy(TwoDimTemp.array);
        this.Close();
      }
      else
      {
        DialogResult dialogResult = MessageBox.Show("Вы хотите записать введённые параметры в элементы массива? Значения не типа integer будут записаны как нули.", "Предупреждение", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
          BoxesToArray(TwoDimTemp.array);
          TwoDimMain.array = Copy(TwoDimTemp.array);
          this.Close();
        }
      }
    }

    private void TwoDimForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      textBoxes.Clear();
      labels.Clear();
      this.Dispose();
    }
  }
}