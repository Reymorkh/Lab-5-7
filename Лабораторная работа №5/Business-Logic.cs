using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyLibStructWF.ArrayTypes;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Лабораторная_работа__5
{
  public static class BusinessLogic
  {
    public static OneDim OneDimMain = new OneDim(0), OneDimTemp = new OneDim(0);
    public static TwoDim TwoDimMain = new TwoDim(0, 0), TwoDimTemp = new TwoDim(0, 0);
    public static Torn TornMain = new Torn(0), TornTemp = new Torn(0);
    public static Random random = new Random();

    public static void FormStartup(Form form) => form.ShowDialog(); // открытие формы

    #region Set Array Length
    public static int[] SetArrayLength(int length) => new int[length];

    public static bool TwoDimParamCheck(string line, out int param1, out int param2)
    {
      string[] parameters;
      parameters = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
      if (parameters.Length > 1 && int.TryParse(parameters[0], out param1) && param1 > -1 && int.TryParse(parameters[1], out param2) && param2 > -1)
        return true;
      else if (parameters.Length == 1 && int.TryParse(parameters[0], out param1) && param1 == 0)
      {
        param2 = 0;
        return true;
      }
      param1 = -1; param2 = -1;
      return false;
    }

    public static int[,] SetArrayLength(int param1, int param2)
    {
      return new int[param1, param2];
    }

    public static int[][] SetTornLength(int length = 0) => new int[length][];

    public static void SetTornHeight(int[][] array, int number, int length = 0) => array[number] = new int[length];
    #endregion

    #region random fill
    public static void RandomFill(int[] array)
    {
      for (int i = 0; i < array.Length; i++)
        array[i] = random.Next(-100, 100);
    }

    public static void RandomFill(int[,] array)
    {
      for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
          array[i, j] = random.Next(-100, 100);
    }

    public static void RandomFill(int[][] array)
    {
      for (int i = 0; i < array.Length; i++)
        for (int j = 0; j < array[i].Length; j++)
          array[i][j] = random.Next(-100, 100);
    }
    #endregion

    #region Major Tasks
    public static void Task1()
    {
      if (OneDimMain.Length != 0)
      {
        int i;
        for (i = 0; i < OneDimMain.Length && (OneDimMain.array[i] % 2 == 1 | OneDimMain.array[i] == 0); i++) ;
        if (i < OneDimMain.Length && OneDimMain.array[i] != 0 && OneDimMain.array[i] % 2 == 0)
        {
          OneDimMain.array[i] = 0;
          for (i += 1; i < OneDimMain.Length; i++)
            (OneDimMain.array[i - 1], OneDimMain.array[i]) = (OneDimMain.array[i], OneDimMain.array[i - 1]);
          Array.Resize(ref OneDimMain.array, OneDimMain.Length - 1);
        }
        else
          MessageBox.Show("Чётных чисел в массиве не осталось.","Предупреждение");
      }
      else
        MessageBox.Show("Массив совершенно пуст.", "");
    } //удаление первого чётного элемента

    public static void Task2(string line)
    {
      int.TryParse(line, out int lineNumber);
      lineNumber -= 1;
      if (lineNumber > -1 && lineNumber <= TwoDimMain.Length(0))
        {
        int arrParam1 = TwoDimMain.Length(0), arrParam2 = TwoDimMain.Length(1);
        int[,] newArray = new int[arrParam1 + 1, arrParam2];
        for (int i = 0, k = 0; i < arrParam1; i++, k++) //i - строки, k - количество строк в новом массиве, j - содержимое строк
        {
          if (k == lineNumber)
            k++;
          for (int j = 0; j < arrParam2; j++)
          {
            newArray[k, j] = TwoDimMain.array[i, j];
          }
        }
      TwoDimMain.array = newArray;
      }
      else
        MessageBox.Show("Ввод некорректен, введите число в пределах количества строк массива", "Ошибка");
    } //добавление строки с введённым номером

    public static void Task3()
    {
      if (TornMain.Length != 0)
      {
        int length = TornMain.Length;
        int maxLength = 0, maxLengthIndex = 0;
        for (int i = 0; i < length; i++)  //индекс самой длинной строки массива
        {
          if (maxLength < TornMain.array[i].Length)
          {
            maxLength = TornMain.array[i].Length;
            maxLengthIndex = i;
          }
        }
        int[][] arrayTemp = new int[length - 1][];
        for (int i = 0, k = 0; i < length; i++)
        {
          if (i != maxLengthIndex)
          {
            int[] array = new int[TornMain.array[i].Length]; //создание строки для будущего рваного
            for (int j = 0; j < array.Length; j++)
              array[j] = TornMain.array[i][j];
            arrayTemp[k++] = array; //присваивание новосозданной строки к куску масива
          }
        }
        TornMain.array = arrayTemp;
      }
      else
        MessageBox.Show("Массив совершенно пуст.", "");
    } //удаление самой длинной строки
    #endregion

    #region Box Creation & Preparation
    public static void PrintBoxes(int[] array)
    {
      AddLabel(-0.5, 0, 0 + 1);
      for (int i = 0; i < array.Length; i++)
      {
        AddBox(i, 0);
        AddLabel(i, -0.8, i + 1);
      }
      NumbersToBoxes(array);
    }

    public static void NumbersToBoxes(int[] array)
    {
      int boxIndex = 0;
      for (int i = 0; i < textBoxes.Count && i < array.Length; i++)
      {
        if (array[i] != 0)
          textBoxes[boxIndex].Text = Convert.ToString(array[i]);
        boxIndex++;

      }
    }

    public static void PrintBoxes(int[,] array)
    {
      for (int i = 0; i < array.GetLength(0); i++)
      {
        AddLabel(-0.5, i, i + 1); //принтит номера рядов
        for (int j = 0; j < array.GetLength(1); j++)
          AddBox(j, i);
      }
      for (int i = 0; i < array.GetLength(1); i++) //принтит номера столбцов
        AddLabel(i, -0.8, i + 1);
      NumbersToBoxes(array);
    }

    public static void NumbersToBoxes(int[,] array)
    {
      int j, boxIndex = 0;
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (j = 0; j < array.GetLength(1); j++)
        {
          if (array[i, j] != 0)
            textBoxes[boxIndex].Text = Convert.ToString(array[i, j]);
          boxIndex++;
          if (boxIndex == textBoxes.Count)
            break;
        }
      }
    }

    public static void PrintBoxes(int[][]array)
    {
      int length = 0;
      for (int i = 0; i < array.Length; i++)
      {
        AddLabel(-0.5, i, i + 1);
        if (length < array[i].Length)
          length = array[i].Length;
        for (int j = 0; j < array[i].Length; j++)
          AddBox(j, i);
      }
      for (int i = 0; i < length; i++)
        AddLabel(i, -0.8, i + 1);
      NumbersToBoxes(array);
    }

    public static void NumbersToBoxes(int[][] array)
    {
      int boxIndex = 0;
      for (int i = 0; i < array.Length; i++)
      {
        for (int j = 0; j < array[i].Length; j++)
        {
          if (array[i][j] != 0)
            textBoxes[boxIndex].Text = Convert.ToString(array[i][j]);
          boxIndex++;
        }
      }
    }

    #endregion

    #region Boxes to Array
    public static void BoxesToArray(int[] array)
    {
      int temp;
      for (int i = 0; i < array.Length; i++)
      {
        if (textBoxes[i] != null && int.TryParse(textBoxes[i].Text, out temp))
          array[i] = Convert.ToInt32(textBoxes[i].Text);
      }
    }

    public static void BoxesToArray(int[,] array)
    {
      int j, boxIndex = 0, temp;
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (j = 0; j < array.GetLength(1); j++)
        {
          if (int.TryParse(textBoxes[boxIndex].Text, out temp))
            array[i, j] = temp;
          else
            array[i, j] = 0;
          boxIndex++;
        }
      }
    }

    public static void BoxesToArray(int[][] array)
    {
      int boxIndex = 0, temp;
      for (int i = 0; i < array.Length; i++)
      {
        for (int j = 0; j < array[i].Length; j++)
        {
          if (int.TryParse(textBoxes[boxIndex].Text, out temp))
            array[i][j] = temp;
          else
            array[i][j] = 0;
          boxIndex++;
        }
      }
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
            fileContent = reader.ReadToEnd();
        }
      }
      return fileContent;
    }

    public static bool IsFileCorrect_OneDim(string text, out string[] line) //проверка на корректность указанного файла одномерного массива
    {
      line = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
      if (line.Length == 1)
        return true;
      return false;
    }

    public static bool IsFileCorrect_TwoDim(string text, out string[][] lines) //проверка на корректность указанного файла двумерного массива
    {
      if (text.Length > 4 && text[0] == 'C' && text[1] == 'o' && text[2] == 'l')
      {
        lines = new string[1][];
        lines[0] = new string[text.Length];
        lines[0][0] = text;
        return true;
      }
      //else if (text.Length >= 5 && text[0] == 'E' && text[1] == 'm' && text[2] == 'p' && text[3] == 't' && text[4] == 'y')
      //{
      //  lines = new string[text.Split('\n', StringSplitOptions.RemoveEmptyEntries).Length][];
      //  lines[0] = new string[1];
      //  lines[0][0] = "Empty";
      //  return true;
      //}
      else if (text.Length > 0)
      {
        string[] arrStrings = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        int length = 0, lastLength = 0;
        lines = new string[arrStrings.Length][];
        for (int i = 0; i < arrStrings.Length; i++)
        {
          string[] line = arrStrings[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
          lines[i] = line;
          if (line.Length > 0 && line[0][0] == 'E' && line[0][1] == 'm' && line[0][2] == 'p' && line[0][3] == 't' && line[0][4] == 'y')
            length = 0;
          else
            length = line.Length;
          if (i == 0) //Чтобы в самом начале приравнять последнюю длину к длине
            lastLength = length;
          if (length != lastLength)
            return false;
        }
      if (length == lastLength)
        return true;
      }
      lines = new string[0][];
      return false;
    }

    public static bool IsFileCorrect_Torn(string text, out string[][] lines) //проверка на корректность указанного файла рваного массива
    {
      string[] arrStrings = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
      lines = new string[arrStrings.Length][];
      int minLength = 0, maxLength = 0;
      for (int i = 0; i < arrStrings.Length; i++)
      {
        string[] line = arrStrings[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        lines[i] = line;
        int tempLength;
        if (line.Length > 0 && line[0][0] == 'E' && line[0][1] == 'm' && line[0][2] == 'p' && line[0][3] == 't' && line[0][4] == 'y')
          tempLength = 0;
        else
          tempLength = line.Length;
        if (maxLength < tempLength)
          maxLength = tempLength;
        else if (minLength > tempLength)
          minLength = tempLength;
      }
      if (minLength != maxLength)
        return true;
      return false;
    }

    public static int Load_OneDim(string[] line)
    {
      int errorNumber = 0;
      line = line[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
      int[] arrayLocal = new int[line.Length];
      for (int i = 0; i < line.Length; i++)
      {
        if (int.TryParse(line[i], out int x))
          arrayLocal[i] = x;
        else
          errorNumber++;
      }
      OneDimMain.array = arrayLocal;
      return errorNumber;
    }

    public static int Load_TwoDim(string[][] lines)
    {
      if (lines[0][0][0] == 'C' && lines[0][0][1] == 'o' && lines[0][0][2] == 'l')
      {
        string[] colCount = lines[0][0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (int.TryParse(colCount[1], out int columns))
          TwoDimMain.array = new int[0, columns];
        else
          return -1;
        return 0;
      }
      else if (lines[0][0][0] == 'E' && lines[0][0][1] == 'm' && lines[0][0][2] == 'p' && lines[0][0][3] == 't' && lines[0][0][4] == 'y')
      {
        TwoDimMain.array = new int[lines.Length, 0];
        return 0;
      }
      else
      {
        int errorNumber = 0;
        int[,] arrayLocal = new int[lines.Length, lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
        {
          for (int j = 0; j < lines[i].Length; j++)
          {
            if (int.TryParse(lines[i][j], out int x))
              arrayLocal[i, j] = x;
            else
              errorNumber++;
          }
        }
        TwoDimMain.array = arrayLocal;
        return errorNumber;
      }
      return -1;
    }

    public static int Load_Torn(string[][] lines)
    {
      int errorNumber = 0;
      int[][] arrayLocal = new int[lines.Length][];
      for (int i = 0; i < lines.Length; i++)
      {
        if (lines[i][0][0] == 'E' && lines[i][0][1] == 'm' && lines[i][0][2] == 'p' && lines[i][0][3] == 't' && lines[i][0][4] == 'y')
          arrayLocal[i] = new int[0];
        else
        {
          arrayLocal[i] = new int[lines[i].Length];
          for (int j = 0; j < arrayLocal[i].Length; j++)
          {
            if (int.TryParse(lines[i][j], out int x))
              arrayLocal[i][j] = x;
            else
              errorNumber++;
          }
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
      if (array.GetLength(0) == 0 && array.GetLength(1) > 1)
        file.Write($"Col {array.GetLength(1)}");
      else
        for (int i = 0; i < array.GetLength(0); i++)
        {
          int length = array.GetLength(1);
          if (length == 0)
            file.WriteLine("Empty");
          else
            for (int j = 0; j < length; j++)
              if (j != length - 1)
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
        int length = array[i].Length;
        if (length == 0)
          file.WriteLine("Empty");
        else
          for (int j = 0; j < length; j++)
            if (j != length - 1)
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

    public static bool TornBoxesCheck1(int[] lineLenghts)
    {
      for (int i = 0; i < textBoxes.Count; i++)
      {
        if (int.TryParse(textBoxes[i].Text, out int y) && y > -1)
        {
          lineLenghts[i] = y;
        }
        else
          return false;
      }
      return true;
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