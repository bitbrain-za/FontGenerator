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
  /// Interaction logic for Page.xaml
  /// </summary>
  public partial class Page : UserControl
  {
    private bool _enabled = true;
    public bool Enabled
    {
      get { return _enabled; }
      set
      {
        HP0.Enabled = value;
        HP1.Enabled = value;
        _enabled = value;
      }
    }

    private int _length;
    public int Length
    {
      get { return _length; }
      set
      {
        if ( !_enabled )
          return;

        if(value >= 64)
        {
          HP0.Length = 64;
          HP1.Length = value - 64;
        }
        else
        {
          HP0.Length = value;
          HP1.Length = 0;
        }
        _length = value;
      }
    }

    public List<byte> Value
    {
      get
      {
        List<byte> v = new List<byte>();

        v.AddRange(HP0.Value);

        if(_length >= 64)
        {
          v.AddRange(HP1.Value);
        }

        return v;
      }
      set
      {
        Length = value.Count;

        if ( _length > 64 )
        {
          HP0.Value = value.GetRange(0, 64);
          HP1.Value = value.GetRange(0, _length - 64);
        }
        else
        {
          HP0.Value = value;
          HP1.Value = null;
        }
      }
    }

    public Page()
    {
      InitializeComponent();

    }
  }
}
