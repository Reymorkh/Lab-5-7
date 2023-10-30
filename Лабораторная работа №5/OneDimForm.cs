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
  public partial class OneDimForm : Form
  {
    public static bool isInitialized;
    public static OneDim arrayOne = new OneDim();

    public void Printer()
    {
      arrayOne.PrintBoxes();
      foreach (var s in textBoxes)
        Controls.Add(s);
      foreach (var s in labels)
        Controls.Add(s);
    }

    public OneDimForm()
    {
      InitializeComponent();
      if (MainMenu.isEdit1 == true)
      {
        arrayOne.array = MainMenu.arrayMainOne.Copy();
        button1.Visible = false;
        textBox1.Visible = false;
        label1.Visible = false;
        button2.Visible = true;
        Printer();
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int temp;
      if (int.TryParse(textBox1.Text, out temp) && temp > 0)
      {
        arrayOne.array = new int[temp];
        //if (MainMenu.arrayMainOne.Length() > 0 && MainMenu.arrayMainOne.Length() <= arrayOne.Length())
          WriteOldArrayInButton.Visible = true;
        label1.Visible = false;
        textBox1.Visible = false;
        button1.Visible = false;
        button2.Visible = true;
        Printer();
      }
      else
        MessageBox.Show("Integer больше нуля, пожалуйста.", "Ошибка");
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
      var textBox = sender as TextBox;
      if (e.KeyCode == Keys.Enter)
      {
        button1_Click(sender, e);
      }
    }

    private void button2_Click(object sender, EventArgs e)
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
        arrayOne.BoxesToArray();
        MainMenu.arrayMainOne.array = arrayOne.Copy();
        isInitialized = true;
        this.Close();
      }
      else
      {
        DialogResult dialogResult = MessageBox.Show("Вы хотите записать введённые параметры в элементы массива? Значения не типа integer будут записаны как нули.", "Предупреждение", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
          arrayOne.BoxesToArray();
          MainMenu.arrayMainOne.array = arrayOne.Copy();
          isInitialized = true;
          this.Close();
        }
      }
    }

    private void WriteOldArrayInButton_Click(object sender, EventArgs e)
    {
      MainMenu.arrayMainOne.NumbersToBoxes();
    }
  }
}