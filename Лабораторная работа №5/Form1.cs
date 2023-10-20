namespace Лабораторная_работа__5
{
    public partial class Form1 : Form
    {
        public const int fromTop = 40, fromLeft = 60;
        public static int arrayHeight = 0;
        public static int[] arrayMainOne;
        public static int[][] arrayMainTwo;
        public static bool firstTime = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FillArray_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            f.Dispose();
            MainWindow.Text = "Рваный массив:";
            for (int i = 0; i < Form2.arrayMainTwo.Length; i++)
            {
                MainWindow.Text += Environment.NewLine;
                for (int j = 0; j < Form2.arrayMainTwo[i].Length; j++)
                    MainWindow.Text += Form2.arrayMainTwo[i][j] + " ";
            }
            Form2.textBoxesTemp.Clear();
            //Form2.buttonsPresent = Form2.buttonsTemp;
            //Form2.ButtonEraser();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            int temp;
            if (int.TryParse(HeightBox.Text, out temp))
                arrayHeight = temp;
        }
    }
}