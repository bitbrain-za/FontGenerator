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
  /// Interaction logic for byte_map.xaml
  /// </summary>
  public partial class byte_map : UserControl
  {
    public event EventHandler EnterPressed;

    public byte[] Value
    {
      get { return GetValue(); }
      set { SetValue(value); }
    }
    public byte_map()
    {
      InitializeComponent();
    }

    private byte[] GetValue()
    {
      List<byte> bytes = new List<byte>();

      if ( txt19.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt19.Text, 16));
      }

      if ( txt18.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt18.Text, 16));
      }

      if ( txt17.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt17.Text, 16));
      }

      if ( txt16.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt16.Text, 16));
      }

      if ( txt15.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt15.Text, 16));
      }

      if ( txt14.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt14.Text, 16));
      }

      if ( txt13.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt13.Text, 16));
      }

      if ( txt12.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt12.Text, 16));
      }

      if ( txt11.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt11.Text, 16));
      }

      if ( txt10.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt10.Text, 16));
      }

      if ( txt9.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt9.Text, 16));
      }

      if ( txt8.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt8.Text, 16));
      }

      if ( txt7.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt7.Text, 16));
      }

      if ( txt6.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt6.Text, 16));
      }

      if ( txt5.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt5.Text, 16));
      }

      if ( txt4.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt4.Text, 16));
      }

      if ( txt3.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt3.Text, 16));
      }

      if ( txt2.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt2.Text, 16));
      }

      if ( txt1.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt1.Text, 16));
      }

      if ( txt0.IsEnabled )
      {
        bytes.Add(Convert.ToByte(txt0.Text, 16));
      }
      bytes.Reverse();
      return bytes.ToArray();
    }

    private void SetValue(byte[] ba)
    {
      int length = ba.Length;

      if ( length > 19 )
      {
        txt19.Text = "" + ba[19].ToString("X2");
        txt19.IsEnabled = true;
      }
      else
      {
        txt19.Text = "";
        txt19.IsEnabled = false;
      }

      if ( length > 18 )
      {
        txt18.Text = "" + ba[18].ToString("X2");
        txt18.IsEnabled = true;
      }
      else
      {
        txt18.Text = "";
        txt18.IsEnabled = false;
      }

      if ( length > 17 )
      {
        txt17.Text = "" + ba[17].ToString("X2");
        txt17.IsEnabled = true;
      }
      else
      {
        txt17.Text = "";
        txt17.IsEnabled = false;
      }

      if ( length > 16 )
      {
        txt16.Text = "" + ba[16].ToString("X2");
        txt16.IsEnabled = true;
      }
      else
      {
        txt16.Text = "";
        txt16.IsEnabled = false;
      }

      if ( length > 15 )
      {
        txt15.Text = "" + ba[15].ToString("X2");
        txt15.IsEnabled = true;
      }
      else
      {
        txt15.Text = "";
        txt15.IsEnabled = false;
      }

      if ( length > 14 )
      {
        txt14.Text = "" + ba[14].ToString("X2");
        txt14.IsEnabled = true;
      }
      else
      {
        txt14.Text = "";
        txt14.IsEnabled = false;
      }

      if ( length > 13 )
      {
        txt13.Text = "" + ba[13].ToString("X2");
        txt13.IsEnabled = true;
      }
      else
      {
        txt13.Text = "";
        txt13.IsEnabled = false;
      }

      if ( length > 12 )
      {
        txt12.Text = "" + ba[12].ToString("X2");
        txt12.IsEnabled = true;
      }
      else
      {
        txt12.Text = "";
        txt12.IsEnabled = false;
      }

      if ( length > 11 )
      {
        txt11.Text = "" + ba[11].ToString("X2");
        txt11.IsEnabled = true;
      }
      else
      {
        txt11.Text = "";
        txt11.IsEnabled = false;
      }

      if ( length > 10 )
      {
        txt10.Text = "" + ba[10].ToString("X2");
        txt10.IsEnabled = true;
      }
      else
      {
        txt10.Text = "";
        txt10.IsEnabled = false;
      }

      if ( length > 9 )
      {
        txt9.Text = "" + ba[9].ToString("X2");
        txt9.IsEnabled = true;
      }
      else
      {
        txt9.Text = "";
        txt9.IsEnabled = false;
      }

      if ( length > 8 )
      {
        txt8.Text = "" + ba[8].ToString("X2");
        txt8.IsEnabled = true;
      }
      else
      {
        txt8.Text = "";
        txt8.IsEnabled = false;
      }

      if ( length > 7 )
      {
        txt7.Text = "" + ba[7].ToString("X2");
        txt7.IsEnabled = true;
      }
      else
      {
        txt7.Text = "";
        txt7.IsEnabled = false;
      }

      if ( length > 6 )
      {
        txt6.Text = "" + ba[6].ToString("X2");
        txt6.IsEnabled = true;
      }
      else
      {
        txt6.Text = "";
        txt6.IsEnabled = false;
      }

      if ( length > 5 )
      {
        txt5.Text = "" + ba[5].ToString("X2");
        txt5.IsEnabled = true;
      }
      else
      {
        txt5.Text = "";
        txt5.IsEnabled = false;
      }

      if ( length > 4 )
      {
        txt4.Text = "" + ba[4].ToString("X2");
        txt4.IsEnabled = true;
      }
      else
      {
        txt4.Text = "";
        txt4.IsEnabled = false;
      }

      if ( length > 3 )
      {
        txt3.Text = "" + ba[3].ToString("X2");
        txt3.IsEnabled = true;
      }
      else
      {
        txt3.Text = "";
        txt3.IsEnabled = false;
      }

      if ( length > 2 )
      {
        txt2.Text = "" + ba[2].ToString("X2");
        txt2.IsEnabled = true;
      }
      else
      {
        txt2.Text = "";
        txt2.IsEnabled = false;
      }

      if ( length > 1 )
      {
        txt1.Text = "" + ba[1].ToString("X2");
        txt1.IsEnabled = true;
      }
      else
      {
        txt1.Text = "";
        txt1.IsEnabled = false;
      }

      if ( length > 0 )
      {
        txt0.Text = "" + ba[0].ToString("X2");
        txt0.IsEnabled = true;
      }
      else
      {
        txt0.Text = "";
        txt0.IsEnabled = false;
      }
    }

    private void txt_KeyDown(object sender, KeyEventArgs e)
    {
      if ( (e.Key == Key.Enter) && (EnterPressed != null) )
        EnterPressed(this, null);
    }
  }
}
