using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лабораторная_работа__5
{
    public partial class Form4 : Form
    {
        public static bool isInitialized;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text, strIndex1 = "", strIndex2 = "";
            int index1, index2, i;
            for (i = 0; i < temp.Length; i++)
            {
                if (temp[i] != Convert.ToChar(",") && !Char.IsWhiteSpace(temp[i]))
                    strIndex1 += Convert.ToChar(temp[i]);
                else
                    break;
            }

            for (i = i; i < temp.Length; i++)
            {
                if (temp[i] != Convert.ToChar(",") || !Char.IsWhiteSpace(temp[i]))
                    break;
            }
            i++;
            for (i = i; i < temp.Length; i++)
            {
                if (temp[i] != Convert.ToChar(",") && !Char.IsWhiteSpace(temp[i]))
                    strIndex2 += Convert.ToChar(temp[i]);
                else
                    break;
            }

            if (int.TryParse(strIndex1, out index1) && int.TryParse(strIndex2, out index2))
            {
                Form1.arrayMainTwo = new int[index1, index2];
                isInitialized = true;
                this.Close();
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
    }
}
