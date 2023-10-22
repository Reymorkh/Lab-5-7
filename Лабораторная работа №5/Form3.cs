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

namespace Лабораторная_работа__5
{
    public partial class Form3 : Form
    {
        public static bool isInitialized = false;
        public const double fromTop = 30, fromLeft = 60, startLeft = 40, startTop = 60;
        public static int tabindex = 8;
        public static List<TextBox> textBoxes = new List<TextBox>();
        public static List<Label> labels = new List<Label>();

        public Form3()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(textBox1.Text, out temp) && temp > 0)
            {
                Form1.arrayMainOne = new int[temp];
                isInitialized = true;
                label1.Visible = false;
                textBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = true;
                LabelPrinter(-0.5, 0, 0 + 1);
                for (int i = 0; i < Form1.arrayMainOne.Length; i++)
                    TextBoxPrinter(i, 0);
                for (int i = 0; i < Form1.arrayMainOne.Length; i++)
                    LabelPrinter(i, -0.8, i + 1);
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
            int j, boxIndex = 0, temp;
            for (int i = 0; i < Form1.arrayMainOne.Length; i++)
            {
                if (int.TryParse(textBoxes[boxIndex].Text, out temp))
                    Form1.arrayMainOne[i] = temp;
                else
                    Form1.arrayMainOne[i] = 0;
                boxIndex++;
            }
            isInitialized = true;
            this.Close();
        }
    }
}
