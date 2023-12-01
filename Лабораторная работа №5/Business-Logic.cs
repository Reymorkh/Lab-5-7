using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyLibStructWF.ArrayTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Лабораторная_работа__5
{
  public struct BusinessLogic
  {
    public static OneDim OneDimMain = new OneDim(0), OneDimTemp = new OneDim(0);
    public static TwoDim TwoDimMain = new TwoDim(0, 0), TwoDimTemp = new TwoDim(0, 0);
    public static Torn TornMain = new Torn(0), TornTemp = new Torn(0);
    public static Random random = new Random();

    #region random fill
    public static void RandomFill_OneDim()
    {
      if (OneDimMain.Length != 0)
      {
        for (int i = 0; i < OneDimMain.Length; i++)
          OneDimMain.array[i] = random.Next(-100, 100);
      }
    }

    public static void RandomFill_TwoDim()
    {
      if (TwoDimMain.Length(0) != 0)
      {
        for (int i = 0; i < TwoDimMain.Length(0); i++)
          for (int j = 0; j < TwoDimMain.Length(1); j++)
            TwoDimMain.array[i, j] = random.Next(-100, 100);
      }
    }

    public static void RandomFill_Torn()
    {
      if (TornMain.Length != 0)
      {
        for (int i = 0; i < TornMain.Length; i++)
          for (int j = 0; j < TornMain.array[i].Length; j++)
            TornMain.array[i][j] = random.Next(-100, 100);
      }
    }
    #endregion

    #region Major Tasks
    public static void Task1() //удаление первого чётного элемента
    {
      if (OneDimMain.Length != 0)
      {
        int i;
        for (i = 0; i < OneDimMain.Length & OneDimMain.array[i] % 2 == 1; i++) ;
        if (OneDimMain.array[i] != 0 && OneDimMain.array[i] % 2 == 0)
        {
          OneDimMain.array[i] = 0;
          for (i += 1; i < OneDimMain.Length; i++)
            (OneDimMain.array[i - 1], OneDimMain.array[i]) = (OneDimMain.array[i], OneDimMain.array[i - 1]);
          Array.Resize(ref OneDimMain.array, OneDimMain.Length - 1);
        }
        else
          MessageBox.Show("Чётных чисел в массиве не осталось.","Предупреждение");
      }
    }

    public static void Task2(int lineNumber)
    {
      lineNumber -= 1;
      int index1 = TwoDimMain.Length(0), index2 = TwoDimMain.Length(1), z = 0;
      int[,] temp = new int[index1 + 1, index2];
      for (int i = 0; i < index1; i++) //i - строки, j - содержимое строк
      {
        if (z == lineNumber)
          z++;
        for (int j = 0; j < index2; j++)
        {
          temp[z, j] = TwoDimMain.array[i, j];
        }
        if (z == lineNumber)
          z++;
        z++;
      }
      TwoDimMain.array = temp;
    }

    public static void Task3()
    {
      int length = TornMain.Length;
      int maxLength = 0, maxLengthIndex = 0;
      for (int i = 0; i < length; i++)  // индекс самой длинной строки массива
      {
        if (maxLength < TornMain.array[i].Length)
        {
          maxLength = TornMain.array[i].Length;
          maxLengthIndex = i;
        }
      }
      int[][] arrayTemp = new int[length - 1][];
      int k = 0;
      for (int i = 0; i < length; i++)
      {
        if (i != maxLengthIndex)
          arrayTemp[k++] = TornMain.array[i];
      }
      TornMain.array = arrayTemp;
    }
    #endregion

    #region Copy
    public static int[] Copy(int[] array) // для случаев, когда надо сделать не перменную-ссылку на другую переменную, а отдельный новый идентичный массив
    {
      int[] newArray = new int[array.Length];
      array.CopyTo(newArray, 0);
      return newArray;
    }

    public static int[,] Copy(int[,] array)
    {
      int length1 = array.GetLength(0), length2 = array.GetLength(1);
      int[,] newArray = new int[length1, length2];
      for (int i = 0; i < length1; i++)
        for (int j = 0; j < length2; j++)
          newArray[i, j] = array[i, j];
      return newArray;
    }

    public static int[][] Copy(int[][] array)
    {
        int length = array.Length;
        int[][] newArray = new int[length][];
        for (int i = 0; i < length; i++)
        {
          newArray[i] = new int[array[i].Length];
          for (int j = 0; j < newArray[i].Length; j++)
            newArray[i][j] = array[i][j];
        }
        return newArray;
    }
    #endregion

    #region Load
    public static string FileReader() //Получение обобщёных данных из файла
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

    public static bool IsFileCorrect_OneDim(string text) //проверка на корректность указанного файла одномерного массива
    {
      string[] arrStrings = text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
      if (arrStrings.Length == 1)
        return true;
      return false;
    }

    public static bool IsFileCorrect_TwoDim(string text) //проверка на корректность указанного файла двумерного массива
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

    public static bool IsFileCorrect_Torn(string text) //проверка на корректность указанного файла рваного массива
    {
      string[] arrStrings = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
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

    public static int Load_OneDim(string fileContent)
    {
      int errorNumber = 0;
      string[] contentLines = fileContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      int[] arrayLocal = new int[contentLines.Length];
      for (int i = 0; i < contentLines.Length; i++)
      {
        int x;
        if (int.TryParse(contentLines[i], out x))
          arrayLocal[i] = x;
        else
          errorNumber++;
      }
      OneDimMain.array = arrayLocal;
      return errorNumber;
    }

    public static int Load_TwoDim(string fileContent)
    {
      int errorNumber = 0;
      string[] contentLines = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
      string[] contentColumns = contentLines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      int[,] arrayLocal = new int[contentLines.Length, contentColumns.Length];

      for (int i = 0; i < contentLines.Length; i++)
      {
        contentColumns = contentLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int j = 0; j < contentColumns.Length; j++)
        {
          int x;
          if (int.TryParse(contentColumns[j], out x))
            arrayLocal[i, j] = x;
          else
            errorNumber++;
        }
      }
      TwoDimMain.array = arrayLocal;
      return errorNumber;
    }

    public static int Load_Torn(string fileContent)
    {
      int errorNumber = 0;
      string[] lineNumber = fileContent.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
      string[] columnNubmer;
      int[][] arrayLocal = new int[lineNumber.Length][];
      for (int i = 0; i < lineNumber.Length; i++)
      {
        columnNubmer = lineNumber[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        arrayLocal[i] = new int[columnNubmer.Length];
        for (int j = 0; j < arrayLocal[i].Length; j++)
        {
          int x;
          if (int.TryParse(columnNubmer[j], out x))
            arrayLocal[i][j] = x;
          else
            errorNumber++;
        }
      }
      TornMain.array = arrayLocal;
      return errorNumber;
    }
    #endregion

    #region Save
    static void FileInit(string path)
    {
      if (!File.Exists(path))
      {
        var fie = File.Create(path);
        fie.Close();
      }
      else
        File.WriteAllText(path, string.Empty);
    }

    public static void Save(int[] array) //сохранение одномерного
    {
      string path = "One Dimensional Array.txt";
      FileInit(path);
      StreamWriter file = new StreamWriter(path);
      for (int i = 0; i < array.Length; i++)
      {
        if (i != array.Length - 1)
          file.Write(array[i] + " ");
        else
          file.Write(array[i]);
      }
      file.Close();
      MessageBox.Show("Массив записан");
    }

    public static void Save(int[,] array) //сохранение двумерного
    {
      string path = "Two Dimensional Array.txt";
      FileInit(path);
      StreamWriter file = new StreamWriter(path);
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (int j = 0; j < array.GetLength(1); j++)
          if (j != array.GetLength(1) - 1)
            file.Write(array[i, j] + " ");
          else
            file.WriteLine(array[i, j]);
      }
      file.Close();
      MessageBox.Show("Массив записан");
    }

    public static void Save(int[][] array) //Сохранение рваного
    {
      string path = "Torn Array.txt";
      FileInit(path);
      StreamWriter file = new StreamWriter(path);
      for (int i = 0; i < array.Length; i++)
      {
        for (int j = 0; j < array[i].Length; j++)
          if (j != array[i].Length - 1)
            file.Write(array[i][j] + " ");
          else
            file.WriteLine(array[i][j]);
      }
      file.Close();
      MessageBox.Show("Массив записан");
    }
    #endregion

    #region Box Check (inteface thingy)
    public static bool OneDimBoxesCheck
    {
      get
      {
        foreach (var box in textBoxes)
        {
          if (!int.TryParse(box.Text, out int y))
          {
            return false;
          }
        }
        return true;
      }
    }

    public static bool TwoDimBoxesCheck
    {
      get
      {
        foreach (var box in textBoxes)
        {
          if (!int.TryParse(box.Text, out int y))
          {
            return false;
          }
        }
        return true;
      }
    }

    public static bool TornBoxesCheck1
    {
      get
      {
        foreach (var x in textBoxes)
        {
          int y;
          if (!int.TryParse(x.Text, out y) || y < 0)
          {
            return false;
          }
        }
        return true;
      }
    }

    public static bool TornBoxesCheck2
    {
      get
      {
        foreach (var x in textBoxes)
        {
          int y;
          if (!int.TryParse(x.Text, out y))
          {
            return false;
          }
        }
        return true;
      }
    }
    #endregion

  }
}