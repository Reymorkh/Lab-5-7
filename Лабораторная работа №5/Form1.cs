using System.CodeDom.Compiler;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;

namespace Лабораторная_работа__5
{
    public partial class Form1 : Form
    {
        public const int fromTop = 40, fromLeft = 60;
        public static int arrayHeight = 0;
        public static int[] arrayMainOne;
        public static int[,] arrayMainTwo;
        public static int[][] arrayMainTorn;
        public static bool isEdit1 = false, isEdit2 = false, isEdit3 = false;
        public static Random random = new Random();
        //public static List <string> StringLoadList = new List <string> ();


        public Form1()
        {
            InitializeComponent();
        }

        private void FillTornArray_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            f.Dispose();
            Form2.textBoxes.Clear();
            Form2.labels.Clear();
            if (Form2.isInitialized)
                TornPrint();
        }

        private void OneDimPrintButton_Click(object sender, EventArgs e)
        {
            OneDimPrint();
        }

        public void OneDimPrint()
        {
            MainWindow.Text = "Одномерный массив массив:";
            if (Form3.isInitialized)
            {
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
            else
                MessageBox.Show("Массив пока не инициализирован.", "Ошибка");
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
            Form3.textBoxes.Clear();
            Form3.labels.Clear();
            if (Form3.isInitialized)
                OneDimPrint();
        }

        private void TwoDimPrintButton_Click(object sender, EventArgs e)
        {
            TwoDimPrint();
        }

        public void TwoDimPrint()
        {
            MainWindow.Text = "Двумерный массив:";
            if (Form4.isInitialized && arrayMainTwo.GetLength(0) > 0 && arrayMainTwo.GetLength(1) > 0)
            {
                for (int i = 0; i < arrayMainTwo.GetLength(0); i++)
                {
                    MainWindow.Text += Environment.NewLine;
                    for (int j = 0; j < arrayMainTwo.GetLength(1); j++)
                        MainWindow.Text += Convert.ToString(arrayMainTwo[i, j]) + " ";
                }
            }
            else
                MessageBox.Show("Массив пока не инициализирован.", "Ошибка");
        }

        private void TwoDimCreateButton_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
            f.Dispose();
            Form4.textBoxes.Clear();
            Form4.labels.Clear();
            if (Form4.isInitialized)
                TwoDimPrint();
        }

        private void TornPrintButton_Click(object sender, EventArgs e)
        {
            TornPrint();
        }

        public void TornPrint()
        {
            MainWindow.Text = "Рваный массив:";
            if (Form2.isInitialized)
            {
                for (int i = 0; i < arrayMainTorn.Length; i++)
                {
                    MainWindow.Text += Environment.NewLine;
                    for (int j = 0; j < arrayMainTorn[i].Length; j++)
                        MainWindow.Text += arrayMainTorn[i][j] + " ";
                }
            }
            else
                MessageBox.Show("Массив не инициализирован.", "Ошибка");
        }

        private void OneDimFillButton_Click(object sender, EventArgs e)
        {
            if (Form3.isInitialized && arrayMainOne.Length > 0)
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
            if (Form4.isInitialized && arrayMainTwo.Length > 0)
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
            if (Form2.isInitialized && arrayMainTorn.Length > 0)
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
            if (Form3.isInitialized)
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
            else
                MessageBox.Show("Массив не инициализирован.", "Ошибка");
        }

        public static void SwapInt(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private void Task2Button_Click(object sender, EventArgs e)
        {
            int x;
            if (Form4.isInitialized && int.TryParse(textBox1.Text, out x) && x > 0 && x < arrayMainTwo.GetLength(0) + 1)
            {
                x -= 1;
                int index1 = arrayMainTwo.GetLength(0), index2 = arrayMainTwo.GetLength(1), z = 0;
                int[,] temp = new int[index1 + 1, index2];
                for (int i = 0; i < index1; i++) //i - строки, j - содержимое строк
                {
                    for (int j = 0; j < index2; j++)
                    {
                        temp[z, j] = arrayMainTwo[i, j];
                    }
                    z++;
                    if (i + 1 == x)
                        z++;
                }
                arrayMainTwo = temp;
                TwoDimPrint();
            }
        }

        private void Task3Button_Click(object sender, EventArgs e)
        {
            if (Form2.isInitialized)
            {
                int maxLength = 0, maxLengthIndex = 0;
                for (int i = 0; i < arrayMainTorn.Length; i++)  // индекс самой длинной строки массива
                {
                    if (maxLength < arrayMainTorn[i].Length)
                    {
                        maxLength = arrayMainTorn[i].Length;
                        maxLengthIndex = i;
                    }
                }
                arrayMainTorn = Task3(arrayMainTorn, maxLengthIndex);
                if (arrayMainTorn.Length == 0)
                    Form2.isInitialized = false;
                TornPrint();
            }
            else
                MessageBox.Show("Не с чем работать.", "Ошибка");
        }

        public static int[][] Task3(int[][] arrayMain, int idx)
        {
            int[][] arrayTemp = new int[arrayMain.Length - 1][];
            int k = 0;
            for (int i = 0; i < arrayMain.Length; i++)
            {
                if (i != idx)
                    arrayTemp[k++] = arrayMain[i];
            }
            return arrayTemp;
        }

        private void OneDimSaveButton_Click(object sender, EventArgs e)
        {
            if (Form3.isInitialized)
            {
                FullSaver("One Dimensional Array.txt");
            }
            else
                MessageBox.Show("Записывать нечего.", "Ошибка");
        }

        private void TwoDimSaveButton_Click(object sender, EventArgs e)
        {
            if (Form4.isInitialized)
            {
                FullSaver("Two Dimensional Array.txt");
            }
            else
                MessageBox.Show("Записывать нечего.", "Ошибка");
        }

        private void TornSaveButton_Click(object sender, EventArgs e)
        {
            if (Form2.isInitialized)
            {
                FullSaver("Torn Array.txt");
            }
            else
                MessageBox.Show("Записывать нечего.", "Ошибка");
        }

        public void FullSaver(string path)
        {
            if (!File.Exists(path))
            {
                var fie = File.Create(path);
                fie.Close();
            }
            else
                File.WriteAllText(path, string.Empty);
            StreamWriter file = new StreamWriter(path);
            switch(path)
            {
                case "One Dimensional Array.txt":
                    for (int i = 0; i < arrayMainOne.Length; i++)
                    {
                        if (i != arrayMainOne.Length - 1)
                            file.Write(arrayMainOne[i] + " ");
                        else
                            file.Write(arrayMainOne[i]);
                    }
                    break;
                case "Two Dimensional Array.txt":
                    for (int i = 0; i < arrayMainTwo.GetLength(0); i++)
                    {
                        for (int j = 0; j < arrayMainTwo.GetLength(1); j++)
                            if (j != arrayMainTwo.GetLength(1) - 1)
                                file.Write(arrayMainTwo[i, j] + " ");
                            else
                                file.WriteLine(arrayMainTwo[i, j]);
                    }
                    break;
                case "Torn Array.txt":
                    for (int i = 0; i < arrayMainTorn.Length; i++)
                    {
                        for (int j = 0; j < arrayMainTorn[i].Length; j++)
                            if (j != arrayMainTorn[i].Length - 1)
                                file.Write(arrayMainTorn[i][j] + " ");
                            else
                                file.WriteLine(arrayMainTorn[i][j]);
                    }
                    break;
            }
            file.Close();
            MessageBox.Show("Массив записан");
        }

        private void OneDimEditButton_Click(object sender, EventArgs e)
        {
            if (Form3.isInitialized)
            {
                isEdit1 = true;
                Form3 f = new Form3();
                f.ShowDialog();
                f.Dispose();
                Form3.textBoxes.Clear();
                Form3.labels.Clear();
                if (arrayMainOne.Length > 0)
                    OneDimPrint();
                isEdit1 = false;
            }
            else
                MessageBox.Show("Не с чем работать.", "Ошибка");
        }

        private void TwoDimEditButton_Click(object sender, EventArgs e)
        {
            if (Form4.isInitialized)
            {
                isEdit2 = true;
                Form4 f = new Form4();
                f.ShowDialog();
                f.Dispose();
                Form4.textBoxes.Clear();
                Form4.labels.Clear();
                if (arrayMainTwo.GetLength(0) > 0 && arrayMainTwo.GetLength(1) > 0)
                    TwoDimPrint();
                isEdit2 = false;
            }
            else
                MessageBox.Show("Не с чем работать.", "Ошибка");
        }

        private void TornEditButton_Click(object sender, EventArgs e)
        {
            if (Form2.isInitialized)
            {
                isEdit3 = true;
                Form2 f = new Form2();
                f.ShowDialog();
                f.Dispose();
                Form2.textBoxes.Clear();
                Form2.labels.Clear();
                if (Form2.isInitialized)
                    TornPrint();
                isEdit3 = false;
            }
            else
                MessageBox.Show("Не с чем работать.", "Ошибка");
        }

        public static string FileReader()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "E:\\stuff\\Проекты VS\\Лабораторная работа №5\\Лабораторная работа №5\\bin\\Debug\\net7.0-windows";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            return fileContent;
        }

        public static bool Qualifier(string text, int isArray)
        {
            string[] arrStrings = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (isArray == 1)
                if (arrStrings.Length != 1)
                    return false;
                else
                    return true;

            int length, lastLength = 0;

            foreach (string s in arrStrings)
            {
                string[] temp = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                length = temp.Length;
                if (Array.IndexOf(arrStrings, s) == 0)
                    lastLength = length;
                if (length != lastLength)
                    switch (isArray)
                    {
                        case 2:
                            return false;
                        case 3:
                            return true;
                    }
                lastLength = length;
            }
            if (isArray == 2)
                return true;
            if (isArray == 3)
                return true;
            return false;
        }

        private void OneDimLoadButton_Click(object sender, EventArgs e)
        {
            string fileContent = FileReader();
            if (Qualifier(fileContent, 1))
            {
                string[] oneLine = fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] OneDimArray = new int [oneLine.Length];
                for (int i = 0; i < oneLine.Length; i++)
                {
                    int x;
                    if (int.TryParse(oneLine[i], out x))
                        OneDimArray[i] = x;
                }
                arrayMainOne = OneDimArray;
                Form3.isInitialized = true;
                OneDimPrint();
            }
            else
                MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как одномерный массив целых чисел в пределах типа integer.", "Ошибка");
        }

        private void TwoDimLoadButton_Click(object sender, EventArgs e)
        {
            string fileContent = FileReader();
            if (Qualifier(fileContent, 2))
            {
                string[] lineNumber = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] columnNubmer = lineNumber[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[,] TwoDimArray = new int[lineNumber.Length,columnNubmer.Length];

                for (int i = 0; i < lineNumber.Length; i++)
                {
                    columnNubmer = lineNumber[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < columnNubmer.Length; j++)
                    {
                        int x;
                        if (int.TryParse(columnNubmer[j], out x))
                            TwoDimArray[i,j] = x;
                    }
                }
                arrayMainTwo = TwoDimArray;
                Form4.isInitialized = true;
                TwoDimPrint();
            }
            else
                MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как двумерный массив целых чисел в пределах типа integer.", "Ошибка");
        }

        private void TornLoadButton_Click(object sender, EventArgs e)
        {
            string fileContent = FileReader();
            if (Qualifier(fileContent, 3))
            {
                string[] lineNumber = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] columnNubmer;
                int[][] TornArray = new int[lineNumber.Length][];
                for (int i = 0; i < lineNumber.Length; i++)
                {
                    columnNubmer = lineNumber[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    TornArray[i] = new int[columnNubmer.Length];
                    for (int j = 0; j < TornArray[i].Length; j++)
                    {
                        int x;
                        if (int.TryParse(columnNubmer[j], out x))
                            TornArray[i][j] = x;
                    }
                }
                arrayMainTorn = TornArray;
                Form2.isInitialized = true;
                TornPrint();
            }
            else
                MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как рваный массив целых чисел в пределах типа integer.", "Ошибка");
        }
    }
}