using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FontGenerator
{
  /// <summary>
  /// Interaction logic for Map.xaml
  /// </summary>
  public partial class Map : UserControl
  {
    private DisplayByte[,] bytes = new DisplayByte[8,128];

    public byte[,] Value
    {
      get
      {
        byte[,] temp = new byte[_height, _width];

        for(int i = 0; i < _height; i++ )
        {
          for(int j = 0; j < _width; j++ )
          {
            temp[i, j] = bytes[i, j].Value;
          }
        }
        return temp;
      }

      set
      {
        Height = value.GetLength(0);
        Width = value.GetLength(1);

        for(int i = 0; i < _height; i++ )
        {
          for(int j = 0; j < _width; j++ )
          {
            bytes[i, j].Value = value[i, j];
          }
        }
        Paint();
      }
    }

    private int _height = 8;
    public int y
    {
      get { return _height; }
      set
      {
        DisplayByte[,] temp = new DisplayByte[_height, _width];
        Array.Copy(bytes, temp, _height * _width);

        bytes = new DisplayByte[value, _width];

        mapGrid.Children.Clear();

        mapGrid.Rows = value;
        mapGrid.Columns = _width;

        for(int i = 0; i < value; i++ )
        {
          for(int j = 0; j < _width; j++ )
          {
            if ( (i >= _height) || (j >= _width) )
              bytes[i, j] = new DisplayByte();
            else
              bytes[i, j] = temp[i, j];
            mapGrid.Children.Add(bytes[i, j]);
          }
        }
        _height = value;
      }
    }

    private int _width = 128;

    new public int x
    {
      get { return _width; }
      set
      {
        DisplayByte[,] temp = new DisplayByte[_height, _width];
        Array.Copy(bytes, temp, _height * _width);

        bytes = new DisplayByte[_height, value];

        mapGrid.Children.Clear();

        mapGrid.Rows = _height;
        mapGrid.Columns = value;

        for(int i = 0; i < _height; i++ )
        {
          for(int j = 0; j < value; j++ )
          {
            if ( (i >= _height) || (j >= _width) )
              bytes[i, j] = new DisplayByte();
            else
              bytes[i, j] = temp[i, j];
            mapGrid.Children.Add(bytes[i, j]);
          }
        }
        _width = value;
      }
    }

    public Map()
    {
      InitializeComponent();

      for(int i = 0; i < 8; i++ )
      {
        for(int j = 0; j < 128; j++ )
        {
          bytes[i, j] = new DisplayByte();
          mapGrid.Children.Add(bytes[i, j]);
        }
      }
    }

    public void Paint()
    {
      mapGrid.Children.Clear();

      mapGrid.Rows = _height;
      mapGrid.Columns = _width;

      for(int i = 0; i < _height; i++ )
      {
        for(int j = 0; j < _width; j++ )
        {
          mapGrid.Children.Add(bytes[i, j]);
        }
      }
    }

    public void Invert()
    {
      foreach(DisplayByte db in bytes)
      {
        db.Invert();
      }
    }

  }
}
