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
using MyLibWF;

namespace Лабораторная_работа__5
{
  public partial class Form4 : Form
  {
    public static bool isInitialized;
    public const double fromTop = 30, fromLeft = 60, startLeft = 40, startTop = 60;
    public static int tabindex = 8;
    public static int[,] arrayTwo;
    public static List<TextBox> textBoxes = ActionsWF.textBoxes;
    public static List<Label> labels = ActionsWF.labels;

    public void Printer()
    {
      ActionsWF.Print(arrayTwo);
      foreach (var s in textBoxes)
        Controls.Add(s);
      foreach (var s in labels)
        Controls.Add(s);
    }

    public Form4()
    {
      InitializeComponent();
      if (Form1.isEdit2 == true)
      {
        button1.Visible = false;
        textBox1.Visible = false;
        label1.Visible = false;
        button2.Visible = true;
        Printer();
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string temp = textBox1.Text, strIndex1 = "", strIndex2 = "";
      string[] numbers = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      int index1, index2;
      if(int.TryParse(numbers[0], out index1) && int.TryParse(numbers[1], out index2))
      {
        arrayTwo = new int[index1, index2];
        Form1.arrayMainTwo = arrayTwo;
        isInitialized = true;
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
        ActionsWF.BtA(arrayTwo);
        isInitialized = true;
        this.Close();
      }
      else
      {
        DialogResult dialogResult = MessageBox.Show("Вы хотите записать введённые параметры в элементы массива? Значения не типа integer будут записаны как нули.", "Предупреждение", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.Yes)
        {
          ActionsWF.BtA(arrayTwo);
          isInitialized = true;
          this.Close();
        }
      }
    }
  }
}