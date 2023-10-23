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

namespace Лабораторная_работа__5
{
    public partial class Form2 : Form
    {
        public string a = "-101", b = "-101";
        public static int index1 = -1, index2 = -1;
        public static List<TextBox> textBoxes = new List<TextBox>();
        public static List<Label> labels = new List<Label>();
        //public static List<List> spisokSpiskov = new List<List>();
        public const double fromTop = 30, fromLeft = 60, startLeft = 40, startTop = 60;
        public static int tabindex = 8;
        public static int[] arrayMainOne;
        public static int[][] arrayTorn;
        public static int arrayHeight = Form1.arrayHeight;
        public static bool isInitialized;

        public static int[][] arrayTornHeight(int x)
        {
            int[][] array = new int[x][];
            return array;
        }
        public static void arrayTornLength(int x, int y)
        {
            arrayTorn[x] = new int[y];
        }



        public Form2()
        {
            InitializeComponent();
            if (Form1.isEdit3 == true)
            {
                HeightButton.Visible = false;
                textBox1.Visible = false;
                MainLabel.Visible = true;
                Printer();
                TextToBoxes();
                MainLabel.Text = "Введите элементы массива.";
                PseudoMainButton.Visible = true;
            }
        }

        public void TextBoxPrinter(double multiplierLeft, double multiplierTop)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Location = new Point(Convert.ToInt32(Math.Round(startLeft + fromLeft * multiplierLeft, 0)), Convert.ToInt32(Math.Round(startTop + fromTop * multiplierTop, 0)));
            textBoxes.Add(newTextBox);
            newTextBox.Size = new Size(40, 20);
            newTextBox.TabIndex = tabindex;
            tabindex++;
            newTextBox.MaxLength = 5;
            newTextBox.TextAlign = HorizontalAlignment.Center;
            Controls.Add(newTextBox);
        }

        public void LabelPrinter(double multiplierLeft, double multiplierTop, int number)
        {
            Label newLabel = new Label();
            newLabel.Location = new Point(Convert.ToInt32(Math.Round(startLeft + fromLeft * multiplierLeft, 0)), Convert.ToInt32(Math.Round(startTop + fromTop * multiplierTop, 0)));
            newLabel.Text = Convert.ToString(number);
            newLabel.Size = new Size(20, 20);
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            newLabel.AutoSize = true;
            labels.Add(newLabel);
            Controls.Add(newLabel);
        }

        public void Printer()
        {
            int length = 0;
            for (int i = 0; i < arrayTorn.Length; i++)
            {
                LabelPrinter(-0.5, i, i + 1);
                if (length < arrayTorn[i].Length)
                    length = arrayTorn[i].Length;
                for (int j = 0; j < arrayTorn[i].Length; j++)
                    TextBoxPrinter(j, i);
            }
            for (int i = 0; i < length; i++)
                LabelPrinter(i, -0.8, i + 1);
        }

        private void HeightButton_Click(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(textBox1.Text, out temp))
            {
                if (temp > 0 && temp < 100)
                {
                    arrayTorn = arrayTornHeight(temp);
                    HeightButton.Visible = false;
                    textBox1.Visible = false;
                    MainButton.Visible = true;
                    MainLabel.Visible = true;
                    for (int i = 0; i < arrayTorn.Length; i++)
                    {
                        TextBoxPrinter(0, i);
                        LabelPrinter(-0.5, i, i + 1);
                    }
                }
                else
                    MessageBox.Show("Число должно быть в пределах 0 < x < 100", "Ошибка");
            }
            else
                MessageBox.Show("Попробуйте другое число.", "Ошибка");
        }

        private void MainButton_Click(object sender, EventArgs e)
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
                textBoxEraser();
                Printer();
                MainButton.Visible = false;
                MainLabel.Text = "Введите элементы массива.";
                PseudoMainButton.Visible = true;
            }
            else
                MessageBox.Show("Не все введённые данные соответствуют типу int или являются больше нуля.", "Ошибка");
        }

        private void PseudoMainButton_Click(object sender, EventArgs e)
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
                BoxesToArray();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Вы хотите записать введённые параметры в элементы массива? Значения не типа integer будут записаны как нули.", "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    BoxesToArray();
            }
        }

        public void BoxesToArray()
        {
            int boxIndex = 0, temp;
            for (int i = 0; i < arrayTorn.Length; i++)
            {
                for (int j = 0; j < arrayTorn[i].Length; j++)
                {
                    if (int.TryParse(textBoxes[boxIndex].Text, out temp))
                        arrayTorn[i][j] = temp;
                    else
                        arrayTorn[i][j] = 0;
                    boxIndex++;
                }
            }
            Form1.arrayMainTorn = arrayTorn;
            isInitialized = true;
            this.Close();
        }

        public void TextToBoxes()
        {
            int boxIndex = 0, temp;
            for (int i = 0; i < arrayTorn.Length; i++)
            {
                for (int j = 0; j < arrayTorn[i].Length; j++)
                {
                    if (arrayTorn[i][j] != 0)
                        textBoxes[boxIndex].Text = Convert.ToString(arrayTorn[i][j]);
                    boxIndex++;
                }
            }
        }

        public static void textBoxEraser()
        {
            foreach (var textbox in textBoxes)
                textbox.Dispose();
            textBoxes.Clear();
        }
    }
}
