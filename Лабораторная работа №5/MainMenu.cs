using static MyLibWF.ActionsWF;
using System.CodeDom.Compiler;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Лабораторная_работа__5
{
  public partial class MainMenu : Form
  {
    public static int arrayHeight = 0;
    public static int[] arrayMainOne;
    public static int[,] arrayMainTwo;
    public static int[][] arrayMainTorn;
    public static bool isEdit1 = false, isEdit2 = false, isEdit3 = false;
    public static Random random = new Random();

    public MainMenu()
    {
      InitializeComponent();
    }

    private void OneDimCreateButton_Click(object sender, EventArgs e)
    {
      OneDimForm form = new OneDimForm();
      FormInit(form);
      BoxPrint(OneDimForm.isInitialized, MainWindow, arrayMainOne);
    }

    private void TwoDimCreateButton_Click(object sender, EventArgs e)
    {
      TwoDimForm form = new TwoDimForm();
      FormInit(form);
      BoxPrint(TwoDimForm.isInitialized, MainWindow, arrayMainTwo);
    }

    private void TornCreateButton_Click(object sender, EventArgs e)
    {
      TornArrayForm form = new TornArrayForm();
      FormInit(form);
      BoxPrint(TornArrayForm.isInitialized, MainWindow, arrayMainTorn);
    }

    private void OneDimPrintButton_Click(object sender, EventArgs e)
    {
      BoxPrint(OneDimForm.isInitialized, MainWindow, arrayMainOne);
    }

    private void TwoDimPrintButton_Click(object sender, EventArgs e)
    {
      BoxPrint(TwoDimForm.isInitialized, MainWindow, arrayMainTwo);
    }


    private void TornPrintButton_Click(object sender, EventArgs e)
    {
      BoxPrint(TornArrayForm.isInitialized, MainWindow, arrayMainTorn);
    }

    private void OneDimFillButton_Click(object sender, EventArgs e)
    {
      if (OneDimForm.isInitialized)
      {
        for (int i = 0; i < arrayMainOne.Length; i++)
          arrayMainOne[i] = random.Next(-100, 100);
        BoxPrint(OneDimForm.isInitialized, MainWindow, arrayMainOne);
      }
      else
        MessageBox.Show("Массив не инициализирован.", "Ошибка");
    }

    private void TwoDimFillButton_Click(object sender, EventArgs e)
    {
      if (TwoDimForm.isInitialized)
      {
        for (int i = 0; i < arrayMainTwo.GetLength(0); i++)
          for (int j = 0; j < arrayMainTwo.GetLength(1); j++)
            arrayMainTwo[i, j] = random.Next(-100, 100);
        BoxPrint(TwoDimForm.isInitialized, MainWindow, arrayMainTwo);
      }
      else
        MessageBox.Show("Массив не инициализирован.", "Ошибка");
    }

    private void TornFillButton_Click(object sender, EventArgs e)
    {
      if (TornArrayForm.isInitialized)
      {
        for (int i = 0; i < arrayMainTorn.Length; i++)
          for (int j = 0; j < arrayMainTorn[i].Length; j++)
            arrayMainTorn[i][j] = random.Next(-100, 100);
        BoxPrint(TornArrayForm.isInitialized, MainWindow, arrayMainTorn);
      }
      else
        MessageBox.Show("Массив не инициализирован.", "Ошибка");
    }

    private void Task1Button_Click(object sender, EventArgs e)
    {
      if (OneDimForm.isInitialized)
      {
        arrayMainOne = Task1(arrayMainOne, ref OneDimForm.isInitialized, MainWindow);
      }
      else
        MessageBox.Show("Массив не инициализирован.", "Ошибка");
    }

    private void Task2Button_Click(object sender, EventArgs e)
    {
      int x;
      if (TwoDimForm.isInitialized && int.TryParse(textBox1.Text, out x) && x > 0 && x < arrayMainTwo.GetLength(0) + 1)
      {
        arrayMainTwo = Task2(arrayMainTwo, x);
        BoxPrint(TwoDimForm.isInitialized, MainWindow, arrayMainTwo);
      }
    }

    private void Task3Button_Click(object sender, EventArgs e)
    {
      if (TornArrayForm.isInitialized)
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
          TornArrayForm.isInitialized = false;
        BoxPrint(TornArrayForm.isInitialized, MainWindow, arrayMainTorn);
      }
      else
        MessageBox.Show("Не с чем работать.", "Ошибка");
    }

    private void OneDimSaveButton_Click(object sender, EventArgs e)
    {
      if (OneDimForm.isInitialized)
      {
        Saver(arrayMainOne);
      }
      else
        MessageBox.Show("Записывать нечего.", "Ошибка");
    }

    private void TwoDimSaveButton_Click(object sender, EventArgs e)
    {
      if (TwoDimForm.isInitialized)
      {
        Saver(arrayMainTwo);
      }
      else
        MessageBox.Show("Записывать нечего.", "Ошибка");
    }

    private void TornSaveButton_Click(object sender, EventArgs e)
    {
      if (TornArrayForm.isInitialized)
      {
        Saver(arrayMainTorn);
      }
      else
        MessageBox.Show("Записывать нечего.", "Ошибка");
    }


    private void OneDimEditButton_Click(object sender, EventArgs e)
    {
      if (OneDimForm.isInitialized)
      {
        isEdit1 = true;
        OneDimForm form = new OneDimForm();
        FormInit(form);
        BoxPrint(OneDimForm.isInitialized, MainWindow, arrayMainOne);
        isEdit1 = false;
      }
      else
        MessageBox.Show("Не с чем работать.", "Ошибка");
    }

    private void TwoDimEditButton_Click(object sender, EventArgs e)
    {
      if (TwoDimForm.isInitialized)
      {
        isEdit2 = true;
        TwoDimForm form = new TwoDimForm();
        FormInit(form);
        BoxPrint(TwoDimForm.isInitialized, MainWindow, arrayMainTwo);
        isEdit2 = false;
      }
      else
        MessageBox.Show("Не с чем работать.", "Ошибка");
    }

    private void TornEditButton_Click(object sender, EventArgs e)
    {
      if (TornArrayForm.isInitialized)
      {
        isEdit3 = true;
        TornArrayForm form = new TornArrayForm();
        FormInit(form);
        BoxPrint(TornArrayForm.isInitialized, MainWindow, arrayMainTorn);
        isEdit3 = false;
      }
      else
        MessageBox.Show("Не с чем работать.", "Ошибка");
    }

    private void OneDimLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (IsFileCorrect(fileContent, arrayMainOne))
      {
        int errorNumber = Loader(fileContent, ref arrayMainOne);
        OneDimForm.arrayOne = ArrayCopy(arrayMainOne);
        OneDimForm.isInitialized = true;
        BoxPrint(OneDimForm.isInitialized, MainWindow, arrayMainOne);
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как одномерный массив целых чисел в пределах типа integer.", "Ошибка");
    }

    private void TwoDimLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (IsFileCorrect(fileContent, arrayMainTwo))
      {
        int errorNumber = Loader(fileContent, ref arrayMainTwo);
        TwoDimForm.arrayTwo = ArrayCopy(arrayMainTwo);
        TwoDimForm.isInitialized = true;
        BoxPrint(TwoDimForm.isInitialized, MainWindow, arrayMainTwo);
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как двумерный массив целых чисел в пределах типа integer.", "Ошибка");
    }

    private void TornLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (IsFileCorrect(fileContent, arrayMainTorn))
      {
        int errorNumber = Loader(fileContent, ref arrayMainTorn);
        TornArrayForm.arrayTorn = ArrayCopy(arrayMainTorn);
        TornArrayForm.isInitialized = true;
        BoxPrint(TornArrayForm.isInitialized, MainWindow, arrayMainTorn);
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как рваный массив целых чисел в пределах типа integer.", "Ошибка");
    }
  }
}