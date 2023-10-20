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
    public partial class Form3 : Form
    {
        public static bool isInitialized = false;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(textBox1.Text, out temp) && temp > 0)
            {
                Form1.arrayMainOne = new int[temp];
                isInitialized = true;
                this.Close();
            }
            else
                MessageBox.Show("Integer больше нуля, пожалуйста.", "Ошибка");
        }
    }
}
