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
  /// Interaction logic for Page.xaml
  /// </summary>
  public partial class Page : UserControl
  {
    ObservableCollection<Sector> Sectors { get; set; }

    private bool _enabled = true;
    public bool Enabled
    {
      get { return _enabled; }
      set
      {
        _enabled = value;
      }
    }

    private int _length;
    public int Length
    {
      get { return _length; }

      set
      {
        if(value > _length)
        {
          int temp = _length;
          _length = value;

          for(int i = temp; i < value; i++ )
          {
            Sectors.Add(new Sector());
          }
        }
        else
        {
          for(int i = value; i < _length; i++ )
          {
            Sectors.RemoveAt(i);
          }
          _length = value;
        }
      }
    }

    public List<byte> Value
    {
      get
      {
        List<byte> v = new List<byte>();

        foreach ( Sector s in Sectors )
        {
          v.Add(s.Value);
        }
        return v;
      }
      set
      {
        Length = value.Count;
        for(int i = 0; i < Length; i++)
        {
          Sectors[i].Value = value[i];
        }
      }
    }

    public Page()
    {
      InitializeComponent();
      Sectors = new ObservableCollection<Sector>();

      for(int i = 0; i<128; i++)
      {
        Sectors.Add(new Sector());
      }
    }
  }
}
