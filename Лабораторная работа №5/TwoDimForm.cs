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
using static MyLibStructWF.ArrayManagementWF;

namespace Лабораторная_работа__5
{
  public partial class TwoDimForm : Form
  {
    public static bool isInitialized;
    public static TwoDim arrayTwo = new TwoDim();

    public void Printer()
    {
      arrayTwo.PrintBoxes();
      foreach (var s in textBoxes)
        Controls.Add(s);
      foreach (var s in labels)
        Controls.Add(s);
    }

    public TwoDimForm()
    {
      InitializeComponent();
      if (MainMenu.isEdit2 == true)
      {
        arrayTwo.array = MainMenu.arrayMainTwo.Copy;
        button1.Visible = false;
        textBox1.Visible = false;
        label1.Visible = false;
        button2.Visible = true;
        Printer();
      }
    }

    private void SetLength_Click(object sender, EventArgs e)
    {
      string temp = textBox1.Text;
      string[] numbers = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      int length1, length2;
      if (int.TryParse(numbers[0], out length1))
        if (length1 == 0)
          arrayTwo.array = new int[0, 0];
        else if (numbers.Length > 1 && int.TryParse(numbers[1], out length2))
        {
          arrayTwo.array = new int[length1, length2];
          //if (MainMenu.arrayMainTwo.Length(0) > 0 && MainMenu.arrayMainTwo.Length(1) > 0 && MainMenu.arrayMainTwo.Length(0) <= arrayTwo.Length(0) && MainMenu.arrayMainTwo.Length(1) <= arrayTwo.Length(1))
          //   WriteOldArrayInButton.Visible = true;
          button2.Visible = true;
          button1.Visible = false;
          label1.Visible = false;
          textBox1.Visible = false;
          Printer();
        }
        else
          MessageBox.Show("Попробуйте другой ввод.", "Ошибка");
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      var textBox = sender as TextBox;
      if (e.KeyCode == Keys.Enter)
      {
        SetLength_Click(sender, e);
      }
    }

    private void SetElements_Click(object sender, EventArgs e)
    {
      if (arrayTwo.Length(0) != 0)
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
          arrayTwo.BoxesToArray();
          MainMenu.arrayMainTwo.array = arrayTwo.Copy;
          isInitialized = true;
          this.Close();
        }
        else
        {
          DialogResult dialogResult = MessageBox.Show("Вы хотите записать введённые параметры в элементы массива? Значения не типа integer будут записаны как нули.", "Предупреждение", MessageBoxButtons.YesNo);
          if (dialogResult == DialogResult.Yes)
          {
            arrayTwo.BoxesToArray();
            MainMenu.arrayMainTwo.array = arrayTwo.Copy;
            isInitialized = true;
            this.Close();
          }
        }
      }
    }

    private void WriteOldArrayInButton_Click(object sender, EventArgs e)
    {
      MainMenu.arrayMainTwo.NumbersToBoxes();
    }
  }
}