using MyLibWF;
using System.CodeDom.Compiler;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;

namespace Лабораторная_работа__5
{
  public partial class Form1 : Form
  {
    public static int arrayHeight = 0;
    public static int[] arrayMainOne;
    public static int[,] arrayMainTwo;
    public static int[][] arrayMainTorn;
    public static bool isEdit1 = false, isEdit2 = false, isEdit3 = false;
    public static Random random = new Random();

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
      ActionsWF.BoxPrint(Form2.isInitialized, MainWindow, arrayMainTorn);
    }

    private void OneDimPrintButton_Click(object sender, EventArgs e)
    {
        ActionsWF.BoxPrint(Form3.isInitialized, MainWindow, arrayMainOne);
    }

    private void OneDimCreateButton_Click(object sender, EventArgs e)
    {
      Form3 f = new Form3();
      f.ShowDialog();
      f.Dispose();
      Form3.textBoxes.Clear();
      Form3.labels.Clear();
      ActionsWF.BoxPrint(Form3.isInitialized, MainWindow, arrayMainOne);
    }

    private void TwoDimPrintButton_Click(object sender, EventArgs e)
    {
      ActionsWF.BoxPrint(Form4.isInitialized, MainWindow, arrayMainTwo);
    }

    private void TwoDimCreateButton_Click(object sender, EventArgs e)
    {
      Form4 f = new Form4();
      f.ShowDialog();
      f.Dispose();
      Form4.textBoxes.Clear();
      Form4.labels.Clear();
      ActionsWF.BoxPrint(Form4.isInitialized, MainWindow, arrayMainTwo);
    }

    private void TornPrintButton_Click(object sender, EventArgs e)
    {
      ActionsWF.BoxPrint(Form2.isInitialized, MainWindow, arrayMainTorn);
    }

    private void OneDimFillButton_Click(object sender, EventArgs e)
    {
      if (Form3.isInitialized && arrayMainOne.Length > 0)
      {
        for (int i = 0; i < arrayMainOne.Length; i++)
          arrayMainOne[i] = random.Next(-100, 100);
        ActionsWF.BoxPrint(Form3.isInitialized, MainWindow, arrayMainOne);
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
        ActionsWF.BoxPrint(Form4.isInitialized, MainWindow, arrayMainTwo);
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
        ActionsWF.BoxPrint(Form2.isInitialized, MainWindow, arrayMainTorn);
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
                (arrayMainOne[i - 1], arrayMainOne[i]) = (arrayMainOne[i], arrayMainOne[i - 1]);
              if (arrayMainOne.Length == 1)
                Form3.isInitialized = false;
              Array.Resize(ref arrayMainOne, arrayMainOne.Length - 1);
              ActionsWF.BoxPrint(Form3.isInitialized, MainWindow, arrayMainOne);
              break;
            }
        if (i == arrayMainOne.Length)
          MessageBox.Show("Чётных чисел не осталось.", "Предупрежедение");
      }
      else
        MessageBox.Show("Массив не инициализирован.", "Ошибка");
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
          if (z == x)
            z++;
          for (int j = 0; j < index2; j++)
          {
            temp[z, j] = arrayMainTwo[i, j];
          }
          if (z == x)
            z++;
          z++;
        }
        arrayMainTwo = temp;
        ActionsWF.BoxPrint(Form4.isInitialized, MainWindow, arrayMainTwo);
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
        ActionsWF.BoxPrint(Form2.isInitialized, MainWindow, arrayMainTorn);
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
      switch (path)
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
        ActionsWF.BoxPrint(Form3.isInitialized, MainWindow, arrayMainOne);
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
        ActionsWF.BoxPrint(Form4.isInitialized, MainWindow, arrayMainTwo);
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
        ActionsWF.BoxPrint(Form2.isInitialized, MainWindow, arrayMainTorn);
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

    public static bool Qualifier(string text, int[] x)
    {
      string[] arrStrings = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
      if (arrStrings.Length == 1)
        return true;
      return false;
    }

    public static bool Qualifier(string text, int[,] x)
    {
      string[] arrStrings = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
      int length = 0, lastLength = 0;
      foreach (string s in arrStrings)
      {
        string[] temp = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        length = temp.Length;
        if (Array.IndexOf(arrStrings, s) == 0) //Чтобы в самом начале приравнять последнюю длину к длине
          lastLength = length;
        if (length != lastLength)
          return false;
      }
      if (length == lastLength)
        return true;
      return false;
    }

    public static bool Qualifier(string text, int[][] x)
    {
      string[] arrStrings = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
      int length, lastLength = 0;
      foreach (string s in arrStrings)
      {
        string[] temp = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        length = temp.Length;
        if (Array.IndexOf(arrStrings, s) == 0) //Чтобы в самом начале приравнять последнюю длину к длине
          lastLength = length;
        if (length != lastLength)
          return true;
      }
      return false;
    }

    private void OneDimLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (Qualifier(fileContent, arrayMainOne))
      {
        int errorNumber = 0;
        string[] oneLine = fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] OneDimArray = new int[oneLine.Length];
        for (int i = 0; i < oneLine.Length; i++)
        {
          int x;
          if (int.TryParse(oneLine[i], out x))
            OneDimArray[i] = x;
          else
            errorNumber++;
        }
        arrayMainOne = OneDimArray;
        Form3.arrayOne = arrayMainOne;
        Form3.isInitialized = true;
        ActionsWF.BoxPrint(Form3.isInitialized, MainWindow, arrayMainOne);
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как одномерный массив целых чисел в пределах типа integer.", "Ошибка");
    }

    private void TwoDimLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (Qualifier(fileContent, arrayMainTwo))
      {
        int errorNumber = 0;
        string[] lineNumber = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        string[] columnNubmer = lineNumber[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[,] TwoDimArray = new int[lineNumber.Length, columnNubmer.Length];

        for (int i = 0; i < lineNumber.Length; i++)
        {
          columnNubmer = lineNumber[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
          for (int j = 0; j < columnNubmer.Length; j++)
          {
            int x;
            if (int.TryParse(columnNubmer[j], out x))
              TwoDimArray[i, j] = x;
            else
              errorNumber++;
          }
        }
        arrayMainTwo = TwoDimArray;
        Form4.arrayTwo = arrayMainTwo;
        Form4.isInitialized = true;
        ActionsWF.BoxPrint(Form4.isInitialized, MainWindow, arrayMainTwo);
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как двумерный массив целых чисел в пределах типа integer.", "Ошибка");
    }

    private void TornLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (Qualifier(fileContent, arrayMainTorn))
      {
        int errorNumber = 0;
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
            else
              errorNumber++;
          }
        }
        arrayMainTorn = TornArray;
        Form2.arrayTorn = arrayMainTorn;
        Form2.isInitialized = true;
        ActionsWF.BoxPrint(Form2.isInitialized, MainWindow, arrayMainTorn);
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как рваный массив целых чисел в пределах типа integer.", "Ошибка");
    }
  }
}