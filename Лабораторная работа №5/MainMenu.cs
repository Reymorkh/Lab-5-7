using System.CodeDom.Compiler;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static MyLibStructWF.ArrayTypes;
using static Лабораторная_работа__5.BusinessLogic;

namespace Лабораторная_работа__5
{
  public partial class MainMenu : Form
  {
    public static bool isEdit1 = false, isEdit2 = false, isEdit3 = false;
    public static Random random = new Random();

    public MainMenu()
    {
      InitializeComponent();
    }

    #region Array Init
    private void OneDimCreateButton_Click(object sender, EventArgs e)
    {
      OneDimForm form = new OneDimForm();
      form.ShowDialog();
      MainWindow.Text = OneDimMain.Show;
    }

    private void TwoDimCreateButton_Click(object sender, EventArgs e)
    {
      TwoDimForm form = new TwoDimForm();
      form.ShowDialog();
      MainWindow.Text = TwoDimMain.Show;
    }

    private void TornCreateButton_Click(object sender, EventArgs e)
    {
      TornArrayForm form = new TornArrayForm();
      form.ShowDialog();
      MainWindow.Text = TornMain.Show;
    }
    #endregion

    #region Array Print
    private void OneDimPrintButton_Click(object sender, EventArgs e)
    {
      MainWindow.Text = OneDimMain.Show;
    }

    private void TwoDimPrintButton_Click(object sender, EventArgs e)
    {
      MainWindow.Text = TwoDimMain.Show;
    }


    private void TornPrintButton_Click(object sender, EventArgs e)
    {
      MainWindow.Text = TornMain.Show;
    }
    #endregion

    #region Random Fill
    private void OneDimFillButton_Click(object sender, EventArgs e)
    {
      RandomFill_OneDim();
      MainWindow.Text = OneDimMain.Show;
    }

    private void TwoDimFillButton_Click(object sender, EventArgs e)
    {
      RandomFill_TwoDim();
      MainWindow.Text = TwoDimMain.Show;
    }

    private void TornFillButton_Click(object sender, EventArgs e)
    {
      RandomFill_Torn();
      MainWindow.Text = TornMain.Show;
    }
    #endregion

    #region Major Tasks
    private void Task1Button_Click(object sender, EventArgs e)
    {
      Task1();
      MainWindow.Text = OneDimMain.Show;
    }

    private void Task2Button_Click(object sender, EventArgs e)
    {
      if (TwoDimMain.Length(0) != 0 && int.TryParse(Task2TextBox.Text, out int lineNumber) && lineNumber > 0 && lineNumber <= TwoDimMain.Length(0))
      {
        Task2(lineNumber);
        MainWindow.Text = TwoDimMain.Show;
      }
      else
        MessageBox.Show("Ввод некорректен, введите число в пределах количества строк массива", "Ошибка");
    }

    private void Task3Button_Click(object sender, EventArgs e)
    {
      if (TornMain.Length != 0)
      {
        Task3();
      }
      MainWindow.Text = TornMain.Show;
    }
    #endregion

    #region Edit Buttons
    private void OneDimEditButton_Click(object sender, EventArgs e)
    {
      if (OneDimMain.Length != 0)
      {
        isEdit1 = true;
        OneDimForm form = new OneDimForm();
        form.ShowDialog();
        MainWindow.Text = OneDimMain.Show;
        isEdit1 = false;
      }
      else
        MessageBox.Show("Массив пуст.", "Ошибка");
    }

    private void TwoDimEditButton_Click(object sender, EventArgs e)
    {
      if (TwoDimMain.Length(0) != 0)
      {
        isEdit2 = true;
        TwoDimForm form = new TwoDimForm();
        form.ShowDialog();
        MainWindow.Text = TwoDimMain.Show;
        isEdit2 = false;
      }
      else
        MessageBox.Show("Массив пуст.", "Ошибка");
    }

    private void TornEditButton_Click(object sender, EventArgs e)
    {
      if (TornMain.Length != 0)
      {
        isEdit3 = true;
        TornArrayForm form = new TornArrayForm();
        form.ShowDialog();
        MainWindow.Text = TornMain.Show;
        isEdit3 = false;
      }
      else
        MessageBox.Show("Массив пуст.", "Ошибка");
    }
    #endregion

    #region Save
    private void OneDimSaveButton_Click(object sender, EventArgs e)
    {
      if (OneDimMain.Length != 0)
      {
        Save(OneDimMain.array);
      }
      else
        MessageBox.Show("Массив пуст, записывать нечего.", "Ошибка");
    }

    private void TwoDimSaveButton_Click(object sender, EventArgs e)
    {
      if (TwoDimMain.Length(0) != 0)
      {
        Save(TwoDimMain.array);
      }
      else
        MessageBox.Show("Массив пуст, записывать нечего.", "Ошибка");
    }

    private void TornSaveButton_Click(object sender, EventArgs e)
    {
      if (TornMain.Length != 0)
      {
       Save(TornMain.array);
      }
      else
        MessageBox.Show("Массив пуст, записывать нечего.", "Ошибка");
    }
    #endregion

    #region Load
    private void OneDimLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (IsFileCorrect_OneDim(fileContent))
      {
        int errorNumber = Load_OneDim(fileContent);
        MainWindow.Text = OneDimMain.Show;
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как одномерный массив целых чисел в пределах типа integer.", "Ошибка");
    }

    private void TwoDimLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (IsFileCorrect_TwoDim(fileContent))
      {
        int errorNumber = Load_TwoDim(fileContent);
        MainWindow.Text = TwoDimMain.Show;
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как двумерный массив целых чисел в пределах типа integer.", "Ошибка");
    }

    private void TornLoadButton_Click(object sender, EventArgs e)
    {
      string fileContent = FileReader();
      if (IsFileCorrect_Torn(fileContent))
      {
        int errorNumber = Load_Torn(fileContent);
        MainWindow.Text = TornMain.Show;
        if (errorNumber > 0)
          MessageBox.Show($"При выполнении записи из файла возникли ошибки в количестве: {errorNumber}.\nОни все были записаны как нули.", "Ошибка");
      }
      else
        MessageBox.Show("Загруженный файл не является набором данных, который можно было бы идентифицировать как рваный массив целых чисел в пределах типа integer.", "Ошибка");
    }
    #endregion
  }
}