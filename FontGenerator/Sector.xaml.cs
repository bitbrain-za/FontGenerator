using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
  /// Interaction logic for Sector.xaml
  /// </summary>
  public partial class Sector : UserControl
  {
    public ObservableCollection<Pixel> Pixels
    {
      get;
      set;
    }

    public byte Value
    {
      get
      {
        byte value = 0x00;
        for(int i = 0; i < 8; i++ )
        {
          value += (byte)(((Pixels[i].State == Pixel.PixelState.On) ? 0x01 : 0x00) << i);
        }
        return value;
      }
      set
      {
        for(int i = 0; i < 8; i++ )
        {
          Pixels[i].State = (((value >> i) & 0x01) == 0x01) ? Pixel.PixelState.On : Pixel.PixelState.Off;
        }
      }
    }

    public bool Enabled
    {
      get { return Pixels[0].State != Pixel.PixelState.Disabled; }
      set
      {
        if ( !value )
        {
          foreach ( Pixel p in Pixels )
            p.State = Pixel.PixelState.Disabled;
        }
        else
        {
          if ( Enabled )
            return;
          else
          {
            foreach ( Pixel p in Pixels )
              p.State = Pixel.PixelState.Off;
          }
        }
      }
    }

    public Sector()
    {
      InitializeComponent();
      Pixels = new ObservableCollection<Pixel>();
      for(int i = 0; i < 8; i++)
        Pixels.Add(new Pixel());
    }


  }
}
