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
  /// Interaction logic for LCDCanvas.xaml
  /// </summary>
  public partial class LCDCanvas : UserControl
  {
    DisplayByte[,] bytes = new DisplayByte[8,128];

    private int _height = 8;
    public int y
    {
      get { return _height; }
      set
      {

        DisplayByte[,] temp = new DisplayByte[_height, _width];
        Array.Copy(bytes, temp, _height * _width);

        bytes = new DisplayByte[value, _width];

        canvasGrid.Children.Clear();

        canvasGrid.Rows = value;
        canvasGrid.Columns = _width;

        for(int i = 0; i < value; i++ )
        {
          for(int j = 0; j < _width; j++ )
          {
            if ( (i >= _height) || (j >= _width) )
              bytes[i, j] = new DisplayByte();
            else
              bytes[i, j] = temp[i, j];
            canvasGrid.Children.Add(bytes[i, j]);
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

        canvasGrid.Children.Clear();

        canvasGrid.Rows = _height;
        canvasGrid.Columns = value;

        for(int i = 0; i < _height; i++ )
        {
          for(int j = 0; j < value; j++ )
          {
            if ( (i >= _height) || (j >= _width) )
              bytes[i, j] = new DisplayByte();
            else
              bytes[i, j] = temp[i, j];
            canvasGrid.Children.Add(bytes[i, j]);
          }
        }
        _width = value;
      }
    }

    public LCDCanvas()
    {
      InitializeComponent();

      for(int i = 0; i < 8; i++ )
      {
        for(int j = 0; j < 128; j++ )
        {
          bytes[i, j] = new DisplayByte();
          canvasGrid.Children.Add(bytes[i, j]);
        }
      }
    }
  }
}
