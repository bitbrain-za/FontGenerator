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
  /// Interaction logic for DisplayByte.xaml
  /// </summary>
  public partial class DisplayByte : UserControl
  {
    public event EventHandler ValueChanged;

    private byte _value;
    public byte Value
    {
      get { return _value;  }
      set { update_value(value); }
    }

    public bool Enabled
    {
      set { Visible = value; }
    }

    public bool Visible
    {
      get
      {
        return (B0.Fill != Brushes.LightGray);
      }
      set
      {
        if ( !value )
        {
          B0.Fill = Brushes.LightGray;
          B1.Fill = Brushes.LightGray;
          B2.Fill = Brushes.LightGray;
          B3.Fill = Brushes.LightGray;
          B4.Fill = Brushes.LightGray;
          B5.Fill = Brushes.LightGray;
          B6.Fill = Brushes.LightGray;
          B6.Fill = Brushes.LightGray;
          B7.Fill = Brushes.LightGray;
        }
        else
        {
          update_value();
        }
      }
    }
    public DisplayByte()
    {
      InitializeComponent();
    }

    public void Clear()
    {
      if ( Visible )
        Value = 0x00;
      else
        _value = 0x00;
    }

    private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      Rectangle r = sender as Rectangle;
      bool state = RectangleToggle(r);

      byte val = byte.Parse(r.Name.Remove(0, 1));

      if ( state )
        _value |= (byte)(1 << val);
      else
        _value &= (byte)(~(1 << val));

      if ( ValueChanged != null )
        ValueChanged(this, null);    }

    bool RectangleToggle(Rectangle r)
    {
      bool on = RectangleGet(r);
      RectangleSet(r, !on);
      return !on;
    }

    private bool RectangleGet(Rectangle r)
    {
      return (r.Fill == Brushes.Black);
    }

    private void RectangleSet(Rectangle r, bool on)
    {
      if(!on)
      {
        r.Fill = Brushes.YellowGreen;
      }
      else
      {
        r.Fill = Brushes.Black;
      }
    }

    private void update_value(byte val)
    {
      _value = val;

      RectangleSet(B0, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B1, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B2, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B3, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B4, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B5, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B6, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B7, ((val & 0x01) == 0x01));
    }

    private void update_value()
    {
      byte val = _value;

      RectangleSet(B0, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B1, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B2, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B3, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B4, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B5, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B6, ((val & 0x01) == 0x01));
      val = (byte)(val >> 1);

      RectangleSet(B7, ((val & 0x01) == 0x01));
    }
  }
}
