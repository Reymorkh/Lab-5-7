namespace Лабораторная_работа__5
{
    public partial class Form1 : Form
    {
        public const int fromTop = 40, fromLeft = 60;
        public static int arrayHeight = 0;
        public static int[] arrayMainOne;
        public static int[,] arrayMainTwo;
        public static int[][] arrayMainTorn;
        public static bool firstTime = true;
        public static Random random = new Random();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FillTornArray_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            f.Dispose();
            Form2.textBoxes.Clear();
        }

        private void OneDimPrintButton_Click(object sender, EventArgs e)
        {
            if (Form3.isInitialized)
                OneDimPrint();
            else
                MessageBox.Show("Массив пока не инициализирован.", "Ошибка");
        }
        public void OneDimPrint()
        {
            MainWindow.Text = "Одномерный массив массив:";
            int temp = 0;
            do
            {
                MainWindow.Text += Environment.NewLine;
                if (arrayMainOne.Length % 10 != 0)
                    switch (arrayMainOne.Length - temp > 10)
                    {
                        case (true):
                            OneDimSubPrint(temp, 10);
                            break;

                        case (false):
                            OneDimSubPrint(temp, arrayMainOne.Length - temp);
                            break;
                    }
                else
                    OneDimSubPrint(temp, 10);
                temp += 10;
            }
            while (temp < arrayMainOne.Length);
        }

        public void OneDimSubPrint(int temp, int x)
        {
            for (int i = temp; i < temp + x; i++)
                MainWindow.Text += arrayMainOne[i] + " ";
        }
        private void OneDimCreateButton_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
            f.Dispose();
            if (arrayMainOne.Length > 0)
                OneDimPrint();
        }

        private void TwoDimPrintButton_Click(object sender, EventArgs e)
        {
            if (arrayMainTwo.GetLength(0) > 0 && arrayMainTwo.GetLength(1) > 0)
                TwoDimPrint();
            else
                MessageBox.Show("Массив пока не инициализирован.", "Ошибка");
        }

        public void TwoDimPrint()
        {
            MainWindow.Text = "Двумерный массив";
            for (int i = 0; i < arrayMainTwo.GetLength(0); i++)
            {
                MainWindow.Text += Environment.NewLine;
                for (int j = 0; j < arrayMainTwo.GetLength(1); j++)
                    MainWindow.Text += Convert.ToString(arrayMainTwo[i, j]) + " ";
            }
        }

        private void TwoDimCreateButton_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
            f.Dispose();
            if (arrayMainTwo.GetLength(0) > 0 && arrayMainTwo.GetLength(1) > 0)
                TwoDimPrint();
        }

        private void TornPrintButton_Click(object sender, EventArgs e)
        {
            if (Form2.isInitialized)
                TornPrint();
            else
                MessageBox.Show("Массив пока не инициализирован или вы вышли из меню постройки, не закончив процедуру.", "Ошибка");
        }

        public void TornPrint()
        {
            MainWindow.Text = "Рваный массив:";
            for (int i = 0; i < arrayMainTorn.Length; i++)
            {
                MainWindow.Text += Environment.NewLine;
                for (int j = 0; j < arrayMainTorn[i].Length; j++)
                    MainWindow.Text += arrayMainTorn[i][j] + " ";
            }
        }

        private void OneDimFillButton_Click(object sender, EventArgs e)
        {
            if (arrayMainOne.Length > 0)
            {
                for (int i = 0; i < arrayMainOne.Length; i++)
                    arrayMainOne[i] = random.Next(-100, 100);
                OneDimPrint();
            }
            else
                MessageBox.Show("Массив не инициализирован.", "Ошибка");
        }

        private void TwoDimFillButton_Click(object sender, EventArgs e)
        {
            if (arrayMainTwo.Length > 0)
            {
                for (int i = 0; i < arrayMainTwo.GetLength(0); i++)
                    for (int j = 0; j < arrayMainTwo.GetLength(1); j++)
                        arrayMainTwo[i, j] = random.Next(-100, 100);
                TwoDimPrint();
            }
            else
                MessageBox.Show("Массив не инициализирован.", "Ошибка");
        }

        private void TornFillButton_Click(object sender, EventArgs e)
        {
            if (arrayMainTorn.Length > 0)
            {
                for (int i = 0; i < arrayMainTorn.Length; i++)
                    for (int j = 0; j < arrayMainTorn[i].Length; j++)
                        arrayMainTorn[i][j] = random.Next(-100, 100);
                TornPrint();
            }
            else
                MessageBox.Show("Массив не инициализирован.", "Ошибка");
        }

        private void Task1Button_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < arrayMainOne.Length; i++)
                if (arrayMainOne[i] != 0)
                    if (arrayMainOne[i] % 2 == 0)
                    {
                        arrayMainOne[i] = 0;
                        for (i += 1; i < arrayMainOne.Length; i++)
                            SwapInt(ref arrayMainOne[i - 1], ref arrayMainOne[i]);
                        Array.Resize(ref arrayMainOne, arrayMainOne.Length - 1);
                        OneDimPrint();
                        break;
                    }
            if (i == arrayMainOne.Length)
                MessageBox.Show("Чётных чисел не осталось.", "Предупрежедение");
        }

        public static void SwapInt(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}