using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace MyLibStructWF
{
  public static class ArrayTypes
  {
    const double fromTop = 30, fromLeft = 60;
    static Size size = new Size(40, 20);
    public static List<TextBox> textBoxes = new List<TextBox>();
    public static List<Label> labels = new List<Label>();

    public class OneDim
    {
      public int[] array;

      public OneDim(int length)
      {
        array = new int[length];
      
      }
      
      #region interface
      public string Show
      {
        get
        {
          if (Length != 0)
          {
            string Header = "Одномерный массив:" + Environment.NewLine;
            string[] underHeader = new string[array.Length / 10 + 2];
            underHeader[0] = "      ";
            for (int i = 0; i < 10 & i < array.Length; i++)
            {
              string temp = $"{i + 1}";
              underHeader[0] += temp.PadLeft(11 - temp.Length);
            }
            for (int temp = 0, textIndex = 1; temp < array.Length; temp += 10, textIndex++)
            {
              underHeader[textIndex] = LineConverter(temp);
            }
            return Header + string.Join(Environment.NewLine, underHeader);
          }
          else
            return "Одномерный массив пуст.";
        }
      }
      
      private string LineConverter(int temp)
      {
        string line = Convert.ToString(temp / 10 + 1) + '.';
        line = line.PadRight(7 - line.Length);
        for (int i = temp; i < temp + 10 && i < array.Length; i++)
        {
          string element = $"{array[i]}";
          line += element.PadLeft(11 - element.Length);
        }
        line = line.Trim();
        return line;
      } //Функция для верхней функции
      #endregion

      public int Length
      {
        get { return array.Length; }
      }
    }

    public class TwoDim
    {
      public int[,] array;

      public TwoDim(int length1, int length2)
      {
        array = new int[length1, length2];
      }
      
      public string Show
      {
        get
        {
          if (Length(0) != 0 && Length(1) != 0)
          {
            string Header = "Двумерный массив:" + Environment.NewLine;
            string[] arrayBody = new string[array.GetLength(0) + 2];
            arrayBody[0] = "      ";
            for (int i = 0; i < array.GetLength(1); i++)
            {
              string temp = $"{i + 1}";
              arrayBody[0] += temp.PadLeft(11 - temp.Length);
            }
            for (int i = 0, textIndex = 1; i < array.GetLength(0); i++, textIndex++)
            {
              arrayBody[textIndex] = Convert.ToString(textIndex) + '.';
              arrayBody[textIndex] = arrayBody[textIndex].PadRight(7 - arrayBody[textIndex].Length);
              for (int j = 0; j < array.GetLength(1); j++)
              {
                string number = "" + array[i, j];
                arrayBody[textIndex] += number.PadLeft(11 - number.Length);
              }
            }
            return Header + string.Join(Environment.NewLine, arrayBody);
          }
          else if (Length(0) == 0 & Length(1) > 0)
          {
            string Text = "В двумерном массиве нет строк, но есть столбцы" + Environment.NewLine;
            for (int i = 0; i < array.GetLength(1); i++)
            {
              string temp = $"{i + 1}";
              Text += temp.PadLeft(11 - temp.Length);
            }
            return Text;
          }
          else if (Length(0) > 0 & Length(1) == 0)
          {
            string Text = "В двумерном массиве нет столбцов, но есть строки" + Environment.NewLine;
            for (int i = 0; i < array.GetLength(0); i++)
              if (i < 10)
              Text += (i + 1 + ".").PadRight(9) + "Строка пуста" + Environment.NewLine;
            else if (i < 100)
                Text += (i + 1 + ".").PadRight(8) + "Строка пуста" + Environment.NewLine;
              else if (i < 1000)
                Text += (i + 1 + ".").PadRight(7) + "Строка пуста" + Environment.NewLine;
            return Text;
          }
            return "Двумерный массив пуст.";
        }
      }

      public int Length(int temp)
      {
        switch (temp)
        {
          case 0:
            return array.GetLength(0);
          case 1: 
            return array.GetLength(1);
        }
        return -1;
      }
    }

    public class Torn
    {
      public int[][] array;

      public Torn(int length)
      {
        array = new int[length][];
      }

      public int MaxLengthLine
      { 
        get
        {
          int maxLength = 0;
          for (int i = 0; i < Length; i++)  // индекс самой длинной строки массива
            if (maxLength < array[i].Length)
              maxLength = array[i].Length;
          return maxLength; 
        }
      }

      public string Show
      {
        get
        {
          if (Length != 0)
          {
            string Header = "Рваный массив:" + Environment.NewLine;
            string[] arrayBody = new string[array.Length + 1];
            arrayBody[0] = "   ";
            for (int i = 0; i < MaxLengthLine; i++)
            {
              string lineNumber = $"{i + 1}";
              arrayBody[0] += lineNumber.PadLeft(11 - lineNumber.Length);
            }
            for (int i = 0, textIndex = 1; i < Length; i++, textIndex++)
            {
              if (array[i].Length == 0)
              {
                string lineNumber = $"{i + 1}.";
                arrayBody[textIndex] += lineNumber.PadRight(11 - lineNumber.Length) + "Строка пуста";
              }
              else
              {
                arrayBody[textIndex] = $"{i + 1}.";
                for (int j = 0; j < array[i].Length; j++)
                {
                  string number = "" + array[i][j];
                  arrayBody[textIndex] += number.PadLeft(11 - number.Length);
                }
              }
            }
            Header += string.Join(Environment.NewLine, arrayBody);
            return Header;
          }
          else
            return "Рваный массив пуст.";
        }
      }

      public int Length
      {
        get { return array.Length; }
      }
    }

    public static void AddBox(double posx, double posy)
    {
      TextBox newTextBox = new TextBox();
      newTextBox.Location = new Point(40 + Convert.ToInt32(Math.Round(fromLeft * posx, 0)), 60 + Convert.ToInt32(Math.Round(fromTop * posy, 0)));
      newTextBox.Size = size;
      newTextBox.MaxLength = 5;
      newTextBox.TextAlign = HorizontalAlignment.Center;
      textBoxes.Add(newTextBox);
    }

    public static void AddLabel(double posx, double posy, int number)
    {
      Label newLabel = new Label();
      newLabel.Location = new Point(40 + Convert.ToInt32(Math.Round(fromLeft * posx, 0)), 60 + Convert.ToInt32(Math.Round(fromTop * posy, 0)));
      newLabel.Text = Convert.ToString(number);
      newLabel.TextAlign = ContentAlignment.MiddleCenter;
      newLabel.AutoSize = true;
      labels.Add(newLabel);
    }
  }
}