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
  public partial class HalfPage : UserControl
  {
    List<DisplayByte> bytes = new List<DisplayByte>();

    private bool _enabled;
    public bool Enabled
    {
      get { return _enabled; }
      set
      {
        _enabled = value;
        if(value)
        {
          for ( int i = 0; i < _length; i++ )
            bytes[i].Enabled = true;
        }
        else
        {
          foreach ( DisplayByte b in bytes )
            b.Enabled = false;
        }
      }
    }

    public List<byte> Value
    {
      get
      {
        byte[] v = new byte[_length];
        for(int i = 0; i < _length; i++ )
        {
          v[i] = bytes[i].Value;
        }
        List<byte> val = new List<byte>(v);
        return val;
      }

      set
      {
        Length = value.Count;
        for(int i = 0; i < _length; i++ )
        {
          bytes[i].Value = value[i];
        }
      }
    }

    private int _length = 64;
    public int Length
    {
      get { return _length; }
      set
      {
        if(value > _length)
        {
          for(int i = _length; i < value; i++ )
          {
            bytes[i].Enabled = true;
          }
        }
        else
        {
          for(int i = value; i < _length; i++ )
          {
            bytes[i].Enabled = false;
          }
        }
        _length = value;
      }
    }

    public HalfPage()
    {
      InitializeComponent();

      bytes.Add(Byte0);
      bytes.Add(Byte1);
      bytes.Add(Byte2);
      bytes.Add(Byte3);
      bytes.Add(Byte4);
      bytes.Add(Byte5);
      bytes.Add(Byte6);
      bytes.Add(Byte7);
      bytes.Add(Byte8);
      bytes.Add(Byte9);

      bytes.Add(Byte10);
      bytes.Add(Byte11);
      bytes.Add(Byte12);
      bytes.Add(Byte13);
      bytes.Add(Byte14);
      bytes.Add(Byte15);
      bytes.Add(Byte16);
      bytes.Add(Byte17);
      bytes.Add(Byte18);
      bytes.Add(Byte19);

      bytes.Add(Byte20);
      bytes.Add(Byte21);
      bytes.Add(Byte22);
      bytes.Add(Byte23);
      bytes.Add(Byte24);
      bytes.Add(Byte25);
      bytes.Add(Byte26);
      bytes.Add(Byte27);
      bytes.Add(Byte28);
      bytes.Add(Byte29);

      bytes.Add(Byte30);
      bytes.Add(Byte31);
      bytes.Add(Byte32);
      bytes.Add(Byte33);
      bytes.Add(Byte34);
      bytes.Add(Byte35);
      bytes.Add(Byte36);
      bytes.Add(Byte37);
      bytes.Add(Byte38);
      bytes.Add(Byte39);

      bytes.Add(Byte40);
      bytes.Add(Byte41);
      bytes.Add(Byte42);
      bytes.Add(Byte43);
      bytes.Add(Byte44);
      bytes.Add(Byte45);
      bytes.Add(Byte46);
      bytes.Add(Byte47);
      bytes.Add(Byte48);
      bytes.Add(Byte49);

      bytes.Add(Byte50);
      bytes.Add(Byte51);
      bytes.Add(Byte52);
      bytes.Add(Byte53);
      bytes.Add(Byte54);
      bytes.Add(Byte55);
      bytes.Add(Byte56);
      bytes.Add(Byte57);
      bytes.Add(Byte58);
      bytes.Add(Byte59);

      bytes.Add(Byte60);
      bytes.Add(Byte61);
      bytes.Add(Byte62);
      bytes.Add(Byte63);
    }
  }
}
