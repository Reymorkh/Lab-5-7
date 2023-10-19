namespace Лабораторная_работа__5
{
    public partial class Form1 : Form
    {
        public const int fromTop = 40, fromLeft = 60;
        public static int arrayHeight = 0;
        public static int[] arrayMainOne;
        public static int[,] arrayMainTwo;


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