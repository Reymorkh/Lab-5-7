using System.CodeDom.Compiler;
using System.Security.Policy;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static MyLibStructWF.ArrayManagementWF;

namespace Лабораторная_работа__5
{
  public partial class MainMenu : Form
  {
    public static int arrayHeight = 0;
    public static OneDim arrayMainOne = new OneDim();
    public static TwoDim arrayMainTwo = new TwoDim();
    public static Torn arrayMainTorn = new Torn();
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
      arrayMainOne.Show(OneDimForm.isInitialized, MainWindow);
    }

    private void TwoDimCreateButton_Click(object sender, EventArgs e)
    {
      TwoDimForm form = new TwoDimForm();
      FormInit(form);
      arrayMainTwo.Show(TwoDimForm.isInitialized, MainWindow);
    }

    private void TornCreateButton_Click(object sender, EventArgs e)
    {
      TornArrayForm form = new TornArrayForm();
      FormInit(form);
      arrayMainTorn.Show(TornArrayForm.isInitialized, MainWindow);
    }

    private void OneDimPrintButton_Click(object sender, EventArgs e)
    {
      arrayMainOne.Show(OneDimForm.isInitialized, MainWindow);
    }

    private void TwoDimPrintButton_Click(object sender, EventArgs e)
    {
      arrayMainTwo.Show(TwoDimForm.isInitialized, MainWindow);
    }


    private void TornPrintButton_Click(object sender, EventArgs e)
    {
      arrayMainTorn.Show(TornArrayForm.isInitialized, MainWindow);
    }

    private void OneDimFillButton_Click(object sender, EventArgs e)
    {
      if (OneDimForm.isInitialized)
      {
        for (int i = 0; i < arrayMainOne.Length(); i++)
          arrayMainOne.array[i] = random.Next(-100, 100);
        arrayMainOne.Show(OneDimForm.isInitialized, MainWindow);
      }
      else
        MessageBox.Show("Массив не инициализирован.", "Ошибка");
    }

    private void TwoDimFillButton_Click(object sender, EventArgs e)
    {
      if (TwoDimForm.isInitialized)
      {
        for (int i = 0; i < arrayMainTwo.Length(0); i++)
          for (int j = 0; j < arrayMainTwo.Length(1); j++)
            arrayMainTwo.array[i, j] = random.Next(-100, 100);
        arrayMainTwo.Show(TwoDimForm.isInitialized, MainWindow);
      }
      else
        MessageBox.Show("Массив не инициализирован.", "Ошибка");
    }

    private void TornFillButton_Click(object sender, EventArgs e)
    {
      if (TornArrayForm.isInitialized)
      {
        for (int i = 0; i < arrayMainTorn.Length(); i++)
          for (int j = 0; j < arrayMainTorn.array[i].Length; j++)
            arrayMainTorn.array[i][j] = random.Next(-100, 100);
        arrayMainTorn.Show(TornArrayForm.isInitialized, MainWindow);
      }
      else
        MessageBox.Show("Массив не инициализирован.", "Ошибка");
    }

    private void Task1Button_Click(object sender, EventArgs e)
    {
      if (OneDimForm.isInitialized)
      {
        arrayMainOne.Task1(ref OneDimForm.isInitialized);
        arrayMainOne.Show(OneDimForm.isInitialized, MainWindow);
      }
      else
        MessageBox.Show("Массив не инициализирован.", "Ошибка");
    }

    private void Task2Button_Click(object sender, EventArgs e)
    {
      int x;
      if (TwoDimForm.isInitialized && int.TryParse(textBox1.Text, out x) && x > 0 && x < arrayMainTwo.Length(0) + 1)
      {
        arrayMainTwo.Task2(x);
        arrayMainTwo.Show(TwoDimForm.isInitialized, MainWindow);
      }
    }

    private void Task3Button_Click(object sender, EventArgs e)
    {
      if (TornArrayForm.isInitialized)
      {

        arrayMainTorn.Task3();
        if (arrayMainTorn.Length() == 0)
          TornArrayForm.isInitialized = false;
        arrayMainTorn.Show(TornArrayForm.isInitialized, MainWindow);
      }
      else
        MessageBox.Show("Не с чем работать.", "Ошибка");
    }

    private void OneDimSaveButton_Click(object sender, EventArgs e)
    {
      if (OneDimForm.isInitialized)
      {
        arrayMainOne.Save();
      }
      else
        MessageBox.Show("Записывать нечего.", "Ошибка");
    }

    private void TwoDimSaveButton_Click(object sender, EventArgs e)
    {
      if (TwoDimForm.isInitialized)
      {
        arrayMainTwo.Save();
      }
      else
        MessageBox.Show("Записывать нечего.", "Ошибка");
    }

    private void TornSaveButton_Click(object sender, EventArgs e)
    {
      if (TornArrayForm.isInitialized)
      {
        arrayMainTorn.Save();
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
        arrayMainOne.Show(OneDimForm.isInitialized, MainWindow);
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
        arrayMainTwo.Show(TwoDimForm.isInitialized, MainWindow);
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
        arrayMainTorn.Show(TornArrayForm.isInitialized, MainWindow);
        isEdit3 = false;
      }
      else
        MessageBox.Show("Не с чем работать.", "Ошибка");
    }

    private void OneDimLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (arrayMainOne.IsFileCorrect(fileContent))
      {
        int errorNumber = arrayMainOne.Load(fileContent);
        OneDimForm.arrayOne.array = arrayMainOne.Copy();
        OneDimForm.isInitialized = true;
        arrayMainOne.Show(OneDimForm.isInitialized, MainWindow);
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как одномерный массив целых чисел в пределах типа integer.", "Ошибка");
    }

    private void TwoDimLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (arrayMainTwo.IsFileCorrect(fileContent))
      {
        int errorNumber = arrayMainTwo.Load(fileContent);
        TwoDimForm.arrayTwo.array = arrayMainTwo.Copy();
        TwoDimForm.isInitialized = true;
        arrayMainTwo.Show(TwoDimForm.isInitialized, MainWindow);
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как двумерный массив целых чисел в пределах типа integer.", "Ошибка");
    }

    private void TornLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (arrayMainTorn.IsFileCorrect(fileContent))
      {
        int errorNumber = arrayMainTorn.Load(fileContent);
        TornArrayForm.arrayTorn.array = arrayMainTorn.Copy();
        TornArrayForm.isInitialized = true;
        arrayMainTorn.Show(TornArrayForm.isInitialized, MainWindow);
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как рваный массив целых чисел в пределах типа integer.", "Ошибка");
    }
  }
}