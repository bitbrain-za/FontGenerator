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
  /// Interaction logic for Bitmap.xaml
  /// </summary>
  public partial class Bitmap : UserControl
  {
    private int _height = 8;
    public int y
    {
      get { return _height; }
      set
      {
        if ( _height == value )
          return;

        if(value > _height)
        {
          for(int i = _height; i < value; i++ )
          {
            pages[i].Enabled = true;
            pages[i].Length = _width;
          }
        }
        else
        {
          for ( int i = value; i < _height; i++ )
            pages[i].Enabled = false;
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
        if ( _width == value )
          return;

        foreach ( Page p in pages )
          p.Length = value;

        _width = value;
      }
    }

    List<Page> pages = new List<Page>();

    public Bitmap()
    {
      InitializeComponent();

      pages.Add(P0);
      pages.Add(P1);
      pages.Add(P2);
      pages.Add(P3);
      pages.Add(P4);
      pages.Add(P5);
      pages.Add(P6);
      pages.Add(P7);
    }
  }
}
