using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using TextBox = System.Windows.Forms.TextBox;
using static MyLibStructWF.ArrayTypes;
using static Лабораторная_работа__5.BusinessLogic;

namespace Лабораторная_работа__5
{
  public partial class TornArrayForm : Form
  {
    public void Printer()
    {
      PrintBoxes(TornTemp.array);
      foreach (var s in textBoxes)
        Controls.Add(s);
      foreach (var s in labels)
        Controls.Add(s);
    }

    public TornArrayForm()
    {
      InitializeComponent();
      if (MainMenu.isEdit == true)
      {
        TornTemp.array = Copy(TornMain.array);
        HeightButton.Visible = false;
        HeightBox.Visible = false;
        MainLabel.Visible = true;
        Printer();
        MainLabel.Text = "Введите элементы массива.";
        ConfirmationButton.Visible = true;
      }
    }

    private void HeightButton_Click(object sender, EventArgs e)
    {
      if (int.TryParse(HeightBox.Text, out int length1) && length1 > -1)
      {
        if (length1 == 0)
        {
          TornMain.array = SetTornLength();
          this.Close();
        }
        else
        {
          TornTemp.array = SetTornLength(length1);
          HeightButton.Visible = false;
          HeightBox.Visible = false;
          LengthButton.Visible = true;
          MainLabel.Visible = true;
          AddLabel(0, -0.8, 1);
          for (int i = 0; i < TornTemp.Length; i++)
          {
            AddBox(0, i);
            AddLabel(-0.5, i, i + 1);
          }
          foreach (var textbox in textBoxes)
            Controls.Add(textbox);
          foreach (var label in labels)
            Controls.Add(label);
        }
      }
      else
        MessageBox.Show("Число должно быть больше, чем -1", "Ошибка");
    }

    private void LengthButton_Click(object sender, EventArgs e)
    {
      int[] lineLengths = new int[textBoxes.Count];
      if (TornBoxesCheck1(lineLengths))
      {
        for( int i = 0; i < textBoxes.Count;i++)
        {
          SetTornHeight(TornTemp.array, i, lineLengths[i]);
        }
        textBoxEraser();
        Printer();
        LengthButton.Visible = false;
        MainLabel.Text = "Введите элементы массива.";
        ConfirmationButton.Visible = true;
      }
      else
        MessageBox.Show("Не все введённые данные соответствуют типу integer или являются превосходящими ноль числами.", "Ошибка");
    }

    private void ConfirmationButton_Click(object sender, EventArgs e)
    {
      if (TornBoxesCheck2)
      {
        BoxesToArray(TornTemp.array);
        TornMain.array = Copy(TornTemp.array);
        this.Close();
      }
      else
      {
        DialogResult dialogResult = MessageBox.Show("Вы хотите записать введённые параметры в элементы массива? Значения не типа integer будут записаны как нули.", "Предупреждение", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
          BoxesToArray(TornTemp.array);
          TornMain.array = Copy(TornTemp.array);
          this.Close();
        }
      }
    }

    public static void textBoxEraser()
    {
      foreach (var textbox in textBoxes)
        textbox.Dispose();
      textBoxes.Clear();
      foreach (var label in labels)
        label.Dispose();
      labels.Clear();
    }

    private void TornArrayForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      textBoxes.Clear();
      labels.Clear();
      this.Dispose();
    }
  }
}