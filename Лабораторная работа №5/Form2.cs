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
            if (Form1.firstTime == false)
            {
                HeightButton.Visible = false;
                textBox1.Visible = false;
            }
            else
            {
                HeightButton.Visible = true;
                textBox1.Visible = true;
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

        private void Form2_Load(object sender, EventArgs e)
        {
            isInitialized = false;
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
                        TextBoxPrinter(i, 0);
                        LabelPrinter(i, -0.8, i + 1);
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
                int j, i, length = 0;
                for (i = 0; i < arrayTorn.Length; i++)
                {
                    LabelPrinter(-0.5, i, i + 1);
                    if (length < arrayTorn[i].Length)
                        length = arrayTorn[i].Length;
                    for (j = 0; j < arrayTorn[i].Length; j++)
                        TextBoxPrinter(j, i);
                }

                for (i = 0; i < length; i++)
                    LabelPrinter(i, -0.8, i + 1);
                MainButton.Visible = false;
                MainLabel.Text = "Введите элементы массива.";
                PseudoMainButton.Visible = true;
            }
            else
                MessageBox.Show("Не все введённые данные соответствуют типу int или являются больше нуля." + Environment.NewLine + "При закрытии окна сохранятся длины строк, но не элементы внутри них.", "Ошибка");
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
            int j, slozhno = 0, temp;
            for (int i = 0; i < arrayTorn.Length; i++)
            {
                for (j = 0; j < arrayTorn[i].Length; j++)
                {
                    if (int.TryParse(textBoxes[slozhno].Text, out temp))
                        arrayTorn[i][j] = temp;
                    else
                        arrayTorn[i][j] = 0;
                    slozhno++;
                }
            }
            Form1.arrayMainTorn = arrayTorn;
            isInitialized = true;
            this.Close();
        }
        public static void textBoxEraser()
        {
            foreach (var textbox in textBoxes)
                textbox.Dispose();
            textBoxes.Clear();
        }

        //private void textBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    var textBox = sender as TextBox;
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        textBoxMain(sender, e);
        //    }
        //}
        //public static void textBoxMain(object sender, KeyEventArgs e)
        //{
        //    var textBox = sender as TextBox;
        //    int temp;
        //    int x = 0, y = 0;
        //    if (int.TryParse(textBox.Text, out temp))
        //    {
        //        arrayTorn[x][y] = Convert.ToInt32(textBox.Text);
        //    }
        //}
        //public void ButtonRewrite()
        //{
        //    for (int i = 0; i < Form1.arrayLength; i++)
        //    {
        //        //MessageBox.Show(Convert.ToString(i) + "   " + Convert.ToString(Form1.arrayLength), "");
        //        buttons[i].Text = Convert.ToString(Form1.arrayMain[i]);
        //    }
        //} // что-то делает // ничо не делает снова

        //private void ButtonOnClick(object sender, EventArgs eventArgs)
        //        {
        //            var button = (Button)sender;
        //            DialogResult dialogResult = MessageBox.Show("Вы хотите перезаписать значение выбранного элемента массива?" + Environment.NewLine +
        //                "При выборе варианта нет кнопка будет отмечена для обмена значениями." + Environment.NewLine +
        //                "При выборе отмены это окно закроется.", "Ща будет сложно", MessageBoxButtons.YesNoCancel);
        //            if (dialogResult == DialogResult.No)
        //            {

        //                if (button != null)
        //                {
        //                    buttons.IndexOf(button);


        //                    if (a == "-101")
        //                    {
        //                        a = button.Text;
        //                        index1 = buttons.IndexOf(button);
        //                    }
        //                    else
        //                    if (b == "-101")
        //                    {
        //                        b = button.Text;
        //                        index2 = buttons.IndexOf(button);
        //                    }
        //                    if (a != "-101" && b != "-101")
        //                    {
        //                        Form1.SwapInt(ref Form1.arrayMain[index1], ref Form1.arrayMain[index2]);
        //                        SwapButton(buttons[index1], buttons[index2]);


        //                        a = "-101";
        //                        b = "-101";
        //                        index1 = -1;
        //                        index2 = -1;
        //                    }
        //                }
        //            }
        //            if (dialogResult == DialogResult.Yes)
        //            {
        //                Form3.index = buttons.IndexOf(button);
        //                Form3 gg = new Form3();
        //                gg.ShowDialog();
        //                gg.Dispose();
        //                ButtonRewrite();
        //                //ButtonEraser();
        //                //ButtonPrinter();
        //            }
        //        }
        //public static void NewButtonOnLeave(object sender, EventArgs eventArgs)
        //{
        //    var button = (Button)sender;
        //    if (button.Text)

        //}
        //int[][] array = new int[10][];
        //    for (int i = 0; i< 10;  i++)
        //    {
        //        array[i] = new int[i]; //объявление количества столбцов в строке рваного массива
        //        Console.Write(array[i] + " ");
        //    }
    }
}
