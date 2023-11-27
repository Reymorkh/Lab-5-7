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
using static MyLibStructWF.ArrayManagementWF;

namespace Лабораторная_работа__5
{
  public partial class TornArrayForm : Form
  {
    public static bool isInitialized;
    public static Torn arrayTorn = new Torn();
    public static int arrayHeight = MainMenu.arrayHeight;

    public void Printer()
    {
      arrayTorn.PrintBoxes();
      foreach (var s in textBoxes)
        Controls.Add(s);
      foreach (var s in labels)
        Controls.Add(s);
    }

    public static int[][] arrayTornHeight(int x)
    {
      int[][] array = new int[x][];
      return array;
    }

    public static void arrayTornLength(int x, int y)
    {
      arrayTorn.array[x] = new int[y];
    }

    public TornArrayForm()
    {
      InitializeComponent();
      if (MainMenu.isEdit3 == true)
      {
        arrayTorn.array = MainMenu.arrayMainTorn.Copy;
        HeightButton.Visible = false;
        textBox1.Visible = false;
        MainLabel.Visible = true;
        Printer();
        MainLabel.Text = "Введите элементы массива.";
        PseudoMainButton.Visible = true;
      }
    }

    private void HeightButton_Click(object sender, EventArgs e)
    {
      int temp;
      if (int.TryParse(textBox1.Text, out temp))
      {
        if (temp == 0)
        {
          arrayTornHeight(0);
          MainMenu.arrayMainTorn.array = new int[0][];
          this.Close();
        }
        else if (temp > 0 && temp < 100)
        {
          arrayTorn.array = arrayTornHeight(temp);
          HeightButton.Visible = false;
          textBox1.Visible = false;
          LengthButton.Visible = true;
          MainLabel.Visible = true;
          AddLabel(0, -0.8, 1);
          for (int i = 0; i < arrayTorn.Length(); i++)
          {
            AddBox(0, i);
            AddLabel(-0.5, i, i + 1);
          }
          foreach (var textbox in textBoxes)
            Controls.Add(textbox);
          foreach (var label in labels)
            Controls.Add(label);
        }
        else
          MessageBox.Show("Число должно быть в пределах -1 < x < 100", "Ошибка");
      }
      else
        MessageBox.Show("Попробуйте ввести целое число.", "Ошибка");
    }

    private void LengthButton_Click(object sender, EventArgs e)
    {
      bool isCorrect = true;
      foreach (var x in textBoxes)
      {
        int y;
        if (!int.TryParse(x.Text, out y) || y < 0)
        {
          isCorrect = false;
          break;
        }
      }

      if (isCorrect)
      {
        foreach (var x in textBoxes)
        {
          arrayTornLength(textBoxes.IndexOf(x), Convert.ToInt32(x.Text));
        }
        //if (MainMenu.arrayMainTorn.OldArrayCheck(arrayTorn.array))
        //  WriteOldArrayInButton.Visible = true;
        textBoxEraser();
        Printer();
        LengthButton.Visible = false;
        MainLabel.Text = "Введите элементы массива.";
        PseudoMainButton.Visible = true;
      }
      else
        MessageBox.Show("Не все введённые данные соответствуют типу int или являются больше нуля.", "Ошибка");
    }

    private void ConfirmArrayButton_Click(object sender, EventArgs e)
    {
      bool isCorrect = true;
      foreach (var x in textBoxes)
      {
        int y;
        if (!int.TryParse(x.Text, out y))
        {
          isCorrect = false;
          break;
        }
      }

      if (isCorrect)
      {
        arrayTorn.BoxesToArray();
        MainMenu.arrayMainTorn.array = arrayTorn.Copy;
        isInitialized = true;
        this.Close();
      }
      else
      {
        DialogResult dialogResult = MessageBox.Show("Вы хотите записать введённые параметры в элементы массива? Значения не типа integer будут записаны как нули.", "Предупреждение", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
          arrayTorn.BoxesToArray();
          MainMenu.arrayMainTorn.array = arrayTorn.Copy;
          isInitialized = true;
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
  }
}