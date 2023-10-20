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
        public static List<TextBox> textBoxesTemp = new List<TextBox>();
        //public static List<TextBox> textBoxesPresent = new List<TextBox>();
        //public static List<List> spisokSpiskov = new List<List>();
        public const int fromTop = 60, fromLeft = 60, startLeft = 40, startTop = 30;
        public static int tabindex = 8;
        public static int[] arrayMainOne;
        public static int[][] arrayMainTwo;
        public static int arrayHeight = Form1.arrayHeight;

        public static int[][] arrayTornHeight(int x)
        {
            int[][] array = new int[x][];
            return array;
        }
        public static void arrayTornLength(int x, int y)
        {
            arrayMainTwo[x] = new int[y];
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
            arrayMainTwo = null;
        }

        public void TextBoxPrinter(int multiplierLeft, int multiplierTop)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Location = new Point(startLeft + fromLeft * multiplierLeft, fromTop + startTop * multiplierTop);
            textBoxesTemp.Add(newTextBox);
            newTextBox.Size = new Size(40, 20);
            newTextBox.TabIndex = tabindex;
            tabindex++;
            newTextBox.MaxLength = 5;
            newTextBox.TextAlign = HorizontalAlignment.Center;
            Controls.Add(newTextBox);
            //newTextBox.KeyDown += textBox_KeyDown;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                textBoxMain(sender, e);
            }
        }

        public static void textBoxMain(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            int temp;
            int x = 0, y = 0;
            if (int.TryParse(textBox.Text, out temp))
            {
                arrayMainTwo[x][y] = Convert.ToInt32(textBox.Text);
                //int tempListLength = textBoxesTemp.IndexOf(textBox) + 1;
                //do
                //{
                //    if (tempListLength > arrayMainTwo[x].Length)
                //    {
                //        tempListLength -= arrayMainTwo[x].Length;
                //        x++;
                //    }
                //}
                //while (tempListLength < 0);
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void HeightButton_Click(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(textBox1.Text, out temp))
            {
                if (temp > 0 && temp < 100)
                {
                    arrayMainTwo = arrayTornHeight(temp);
                    HeightButton.Visible = false;
                    textBox1.Visible = false;
                    MainButton.Visible = true;
                    MainLabel.Visible = true;
                    for (int i = 0; i < arrayMainTwo.Length; i++)
                        TextBoxPrinter(i, 0);
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
            foreach (var x in textBoxesTemp)
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
                foreach (var x in textBoxesTemp)
                {
                    arrayTornLength(textBoxesTemp.IndexOf(x), Convert.ToInt32(x.Text));
                }
                textBoxEraser();
                int j, i;
                for (i = 0; i < arrayMainTwo.Length; i++)
                {
                    for (j = 0; j < arrayMainTwo[i].Length; j++)
                        TextBoxPrinter(j, i);
                }
                MainButton.Visible = false;
                MainLabel.Text = "Введите элементы массива. При закрытии окна сохранятся длины строк, но не элементы внутри них.";
                PseudoMainButton.Visible = true;
            }
            else
                MessageBox.Show("Не все введённые данные соответствуют типу int или являются больше нуля.", "Ошибка");
        }

        private void PseudoMainButton_Click(object sender, EventArgs e)
        {
            bool isCorrect = true;
            foreach (var x in textBoxesTemp)
            {
                int y;
                if (!int.TryParse(x.Text, out y))
                {
                    isCorrect = false;
                    MessageBox.Show("Не все введённые данные соответствуют типу int." + Environment.NewLine + "Вы можете оставить пустые поля. Они станут нулями.", "Ошибка");
                    break;
                }
            }

            if (isCorrect)
            {
                int j, slozhno = 0;
                for (int i = 0; i < arrayMainTwo.Length; i++)
                {
                    for (j = 0; j < arrayMainTwo[i].Length; j++)
                    {
                        arrayMainTwo[i][j] = Convert.ToInt32(textBoxesTemp[slozhno].Text);
                        slozhno++;
                    }
                }
                this.Close();
            }
        }

        public static void textBoxEraser()
        {
            foreach (var textbox in textBoxesTemp)
                textbox.Dispose();
            textBoxesTemp.Clear();
        }


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
