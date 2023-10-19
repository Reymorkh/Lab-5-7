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
        public static List<TextBox> textBoxTemp = new List<TextBox>();
        public static List<TextBox> textBoxPresent = new List<TextBox>();
        //public static List<List> spisokSpiskov = new List<List>();
        public int fromTop = 100, fromLeft = 10, tabindex = 8;
        public static int[] arrayMainOne;
        public static int[][] arrayMainTwo;
        public static int arrayHeight = Form1.arrayHeight;


        //int[][] array = new int[10][];
        //    for (int i = 0; i< 10;  i++)
        //    {
        //        array[i] = new int[i]; //объявление количества столбцов в строке рваного массива
        //        Console.Write(array[i] + " ");
        //    }

        public static int[][] arrayTornHeight(int x)
        {
            int[][] arrayMainTwo = new int[x][];
            return arrayMainTwo;
        }

        public Form2()
        {
            InitializeComponent();
        }

        public void TextBoxPrinter(int fromTop, int fromLeft)
        {
            TextBox newTextBox = new TextBox();
            newTextBox.Location = new Point(fromLeft, fromTop);
            fromLeft += 60;
            textBoxTemp.Add(newTextBox);
            newTextBox.Size = new Size(40, 20);
            newTextBox.TabIndex = tabindex;
            tabindex++;
            newTextBox.KeyDown += textBox_KeyDown;
            newTextBox.Text = Convert.ToString(Form1.arrayMainTwo[i + j]);
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (e.KeyCode == Keys.Enter)
            {
                textBoxMain(sender,e);
            }
        }

        public static void textBoxMain(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            int temp;
            int x = 0, y = 0;
            if (int.TryParse(textBox.Text, out temp))
            {
                int tempListLength = textBoxTemp.IndexOf(textBox) + 1;
                do
                {
                    if (tempListLength > arrayMainTwo[x].Length)
                    {
                        tempListLength -= arrayMainTwo[x].Length;
                        x++;
                    }
                }
                while (tempListLength < 0);
                Form1.arrayMainTwo[x, y] = Convert.ToInt32(textBox.Text);
            }


        }
        public static void NewButtonOnLeave(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            if (button.Text)

        }

        public static void ButtonEraser()
        {
            foreach (var button in buttonsTemp)
            {
                button.Dispose();
            }
            buttonsTemp.Clear();
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            var button = (Button)sender;
            DialogResult dialogResult = MessageBox.Show("Вы хотите перезаписать значение выбранного элемента массива?" + Environment.NewLine +
                "При выборе варианта нет кнопка будет отмечена для обмена значениями." + Environment.NewLine +
                "При выборе отмены это окно закроется.", "Ща будет сложно", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.No)
            {

                if (button != null)
                {
                    buttons.IndexOf(button);


                    if (a == "-101")
                    {
                        a = button.Text;
                        index1 = buttons.IndexOf(button);
                    }
                    else
                    if (b == "-101")
                    {
                        b = button.Text;
                        index2 = buttons.IndexOf(button);
                    }
                    if (a != "-101" && b != "-101")
                    {
                        Form1.SwapInt(ref Form1.arrayMain[index1], ref Form1.arrayMain[index2]);
                        SwapButton(buttons[index1], buttons[index2]);


                        a = "-101";
                        b = "-101";
                        index1 = -1;
                        index2 = -1;
                    }
                }
            }
            if (dialogResult == DialogResult.Yes)
            {
                Form3.index = buttons.IndexOf(button);
                Form3 gg = new Form3();
                gg.ShowDialog();
                gg.Dispose();
                ButtonRewrite();
                //ButtonEraser();
                //ButtonPrinter();
            }
        }

        public void ButtonRewrite()
        {
            for (int i = 0; i < Form1.arrayLength; i++)
            {
                //MessageBox.Show(Convert.ToString(i) + "   " + Convert.ToString(Form1.arrayLength), "");
                buttons[i].Text = Convert.ToString(Form1.arrayMain[i]);
            }
        } // что-то делает




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
                }
                else
                    MessageBox.Show("Число должно быть в пределах 0 < x < 100", "Ошибка");
            }
            else
                MessageBox.Show("Попробуйте другое число.", "Ошибка");
        }
    }
}
