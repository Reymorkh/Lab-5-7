using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace MyLibStructWF
{
  public struct ArrayTypes
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
            string Text = "Одномерный массив:";
            string[] text = new string[array.Length / 10 + 2];
            int textIndex = 1;
            for (int temp = 0; temp < array.Length; temp += 10)
            {
              text[textIndex] = LineConverter(temp, text[textIndex]);
              textIndex++;
            }
            Text += string.Join(Environment.NewLine, text);
            return Text;
          }
          else
            return "Одномерный массив пуст.";
        }
      }
      
      private string LineConverter(int temp, string line)
      {
        for (int i = temp; i < temp + 10 && i < array.Length; i++)
          line += Convert.ToString(array[i]) + ' ';
        line = line.Trim();
        return line;
      } //Функция для верхней функции

      public void PrintBoxes()
      {
        AddLabel(-0.5, 0, 0 + 1);
        for (int i = 0; i < array.Length; i++)
        {
          AddBox(i, 0);
          AddLabel(i, -0.8, i + 1);
        }
        NumbersToBoxes();
      }

      public void NumbersToBoxes()
      {
        int boxIndex = 0;
        for (int i = 0; i < textBoxes.Count && i < array.Length; i++)
        {
          if (array[i] != 0)
            textBoxes[boxIndex].Text = Convert.ToString(array[i]);
          boxIndex++;

        }
      }

      public void BoxesToArray()
      {
        int temp;
        for (int i = 0; i < array.Length; i++)
        {
          if (textBoxes[i] != null && int.TryParse(textBoxes[i].Text, out temp))
            array[i] = Convert.ToInt32(textBoxes[i].Text);
        }
      }
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
      
      #region interface
      public void PrintBoxes()
      {
        for (int i = 0; i < array.GetLength(0); i++)
        {
          AddLabel(-0.5, i, i + 1); //принтит номера рядов
          for (int j = 0; j < array.GetLength(1); j++)
            AddBox(j, i);
        }
        for (int i = 0; i < array.GetLength(1); i++) //принтит номера столбцов
          AddLabel(i, -0.8, i + 1);
        NumbersToBoxes();
      }

      public void NumbersToBoxes()
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

      public void BoxesToArray()
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

      public string Show
      {
        get
        {
          if (Length(0) != 0 && Length(1) != 0)
          {
            string Text = "Двумерный массив:";
            string[] text = new string[array.GetLength(0) + 1];
            for (int i = 0; i < array.GetLength(0); i++)
            {
              for (int j = 0; j < array.GetLength(1); j++)
                text[i + 1] += Convert.ToString(array[i, j]) + " ";
              text[i + 1] = text[i + 1].Trim();
            }
            Text += string.Join(Environment.NewLine, text);
            return Text;
          }
          else
            return "Двумерный массив пуст.";
        }
      }
      #endregion

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

      #region interface
      public void PrintBoxes()
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
        NumbersToBoxes();
      }

      public void NumbersToBoxes()
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

      public void BoxesToArray()
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

      public string Show
      {
        get
        {
          if (Length != 0)
          {
          string Text = "Рваный массив:";
          string[] text = new string[array.Length + 1];
            for (int i = 0; i < Length; i++)
            {
              for (int j = 0; j < array[i].Length; j++)
                text[i + 1] += array[i][j] + " ";
            }
            Text += string.Join(Environment.NewLine, text);
            return Text;
          }
          else
            return "Рваный массив пуст.";
        }
      } //rewrite
      #endregion

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