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
  /// Interaction logic for Pixel.xaml
  /// </summary>
  public partial class Pixel : UserControl
  {
    public enum PixelState
    {
      Disabled,
      Off,
      On
    };

    public PixelState State = PixelState.Off;

    public Brush Colour
    {
      get
      {
        switch( State )
        {
          case PixelState.Disabled:
            return Brushes.LightGray;

          case PixelState.Off:
            return Brushes.YellowGreen;

          case PixelState.On:
            return Brushes.Black;

          default:
            return Brushes.LightGray;
        }
      }
      set
      {
          if(value == Brushes.YellowGreen)
            State = PixelState.Off;
          else if(value == Brushes.Black)
            State = PixelState.On;
          else
            State = PixelState.Off;
      }
    }

    public int Value
    {
      get
      {
        switch( State )
        {
          case PixelState.Disabled:
            return 0x00;

          case PixelState.On:
            return 0x01;

          default:
            return 0x00;
        }
      }
      set
      {
        if ( State == PixelState.Disabled )
          return;
        else if ( value > 0 )
          State = PixelState.On;
        else
          State = PixelState.Off;
      }
    }

    public Pixel()
    {
      InitializeComponent();
      Colour = Brushes.YellowGreen;
    }

    private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      if ( State == PixelState.Disabled )
        return;

      if ( State == PixelState.On )
        State = PixelState.Off;
      else
        State = PixelState.On;
    }
  }
}
