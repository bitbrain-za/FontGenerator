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
using Microsoft.Win32;

namespace FontGenerator
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private font_file fonts;
    private icon_file icons;
    private string font_path;
    private string icon_path;
    private bool FontMode = true;

    public MainWindow()
    {
      InitializeComponent();
      WidthSelector.Value = 20;
      WidthSelector.Minimum = 1;
            
      font_path = Properties.Settings.Default.font;
      icon_path = Properties.Settings.Default.icon;

      fonts = new font_file(font_path);
      icons = new icon_file(icon_path);

      if(font_path != null )
      {
        ReloadComboBox();
      }
    }

    private void WidthSelector_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      Slider s = sender as Slider;
      set_width((int)(s.Value));
    }

    private void set_width(int val)
    {
      ByteMap.Value = getMap();

      if ( val > 19 )
        B19.Visible = true;
      else
        B19.Visible = false;

      if ( val > 18 )
        B18.Visible = true;
      else
        B18.Visible = false;

      if ( val > 17 )
        B17.Visible = true;
      else
        B17.Visible = false;

      if ( val > 16 )
        B16.Visible = true;
      else
        B16.Visible = false;

      if ( val > 15 )
        B15.Visible = true;
      else
        B15.Visible = false;

      if ( val > 14 )
        B14.Visible = true;
      else
        B14.Visible = false;

      if ( val > 13 )
        B13.Visible = true;
      else
        B13.Visible = false;

      if ( val > 12 )
        B12.Visible = true;
      else
        B12.Visible = false;

      if ( val > 11 )
        B11.Visible = true;
      else
        B11.Visible = false;

      if ( val > 10 )
        B10.Visible = true;
      else
        B10.Visible = false;

      if ( val > 9 )
        B9.Visible = true;
      else
        B9.Visible = false;

      if ( val > 8 )
        B8.Visible = true;
      else
        B8.Visible = false;

      if ( val > 7 )
        B7.Visible = true;
      else
        B7.Visible = false;

      if ( val > 6 )
        B6.Visible = true;
      else
        B6.Visible = false;

      if ( val > 5 )
        B5.Visible = true;
      else
        B5.Visible = false;

      if ( val > 4 )
        B4.Visible = true;
      else
        B4.Visible = false;

      if ( val > 3 )
        B3.Visible = true;
      else
        B3.Visible = false;

      if ( val > 2 )
        B2.Visible = true;
      else
        B2.Visible = false;

      if ( val > 1 )
        B1.Visible = true;
      else
        B1.Visible = false;

      if ( val > 0 )
        B0.Visible = true;
      else
        B0.Visible = false;

    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
      B19.Clear();
      B18.Clear();
      B17.Clear();
      B16.Clear();
      B15.Clear();
      B14.Clear();
      B13.Clear();
      B12.Clear();
      B11.Clear();
      B10.Clear();
      B9.Clear();
      B8.Clear();
      B7.Clear();
      B6.Clear();
      B5.Clear();
      B4.Clear();
      B3.Clear();
      B2.Clear();
      B1.Clear();
      B0.Clear();

      ByteMap.Value = getMap();
    }

    private void btnOpen_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog fileDialog = new OpenFileDialog();
      bool? res = fileDialog.ShowDialog();

      if(res == true)
      {
        if ( FontMode )
        {
          font_path = fileDialog.FileName;
          fonts.load(font_path);
          Properties.Settings.Default.font = font_path;
        }
        else
        {
          icon_path = fileDialog.FileName;
          icons.load(icon_path);
          Properties.Settings.Default.icon = icon_path;
        }
        Properties.Settings.Default.Save();

        ReloadComboBox();
      }
    }

    private void ReloadComboBox()
    {
      comboDone.Items.Clear();

      if ( FontMode )
      {
        foreach ( char c in fonts.Contents() )
        {
          comboDone.Items.Add(c);
        }
      }
      else
      {
        foreach ( string name in icons.Contents() )
        {
          comboDone.Items.Add(name);
        }
      }
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      if ( FontMode )
        fonts.save(font_path);
      else
        icons.save(icon_path);
    }

    private void btnSaveAs_Click(object sender, RoutedEventArgs e)
    {
      SaveFileDialog fileDialog = new SaveFileDialog();
      bool? res = fileDialog.ShowDialog();

      if(res == true)
      {
        string file = fileDialog.FileName;
        if ( FontMode )
          fonts.save(file);
        else
          icons.save(file);
      }   
    }

    private byte[] getMap()
    {
      List<byte> bytes = new List<byte>();
      int length = (int)WidthSelector.Value;

      if ( length > 19 )
        bytes.Add(B19.Value);

      if ( length > 18 )
        bytes.Add(B18.Value);

      if ( length > 17 )
        bytes.Add(B17.Value);

      if ( length > 16 )
        bytes.Add(B16.Value);

      if ( length > 15 )
        bytes.Add(B15.Value);

      if ( length > 14 )
        bytes.Add(B14.Value);

      if ( length > 13 )
        bytes.Add(B13.Value);

      if ( length > 12 )
        bytes.Add(B12.Value);

      if ( length > 11 )
        bytes.Add(B11.Value);

      if ( length > 10 )
        bytes.Add(B10.Value);

      if ( length > 9 )
        bytes.Add(B9.Value);

      if ( length > 8 )
        bytes.Add(B8.Value);

      if ( length > 7 )
        bytes.Add(B7.Value);

      if ( length > 6 )
        bytes.Add(B6.Value);

      if ( length > 5 )
        bytes.Add(B5.Value);

      if ( length > 4 )
        bytes.Add(B4.Value);

      if ( length > 3 )
        bytes.Add(B3.Value);

      if ( length > 2 )
        bytes.Add(B2.Value);

      if ( length > 1 )
        bytes.Add(B1.Value);

      if ( length > 0 )
        bytes.Add(B0.Value);

      bytes.Reverse();

      return bytes.ToArray();
    }

    private void setMap(byte[] ba)
    {
      int length = ba.Length;

      if ( length > 19 )
        B19.Value = ba[19];

      if ( length > 18 )
        B18.Value = ba[18];

      if ( length > 17 )
        B17.Value = ba[17];

      if ( length > 16 )
        B16.Value = ba[16];

      if ( length > 15 )
        B15.Value = ba[15];

      if ( length > 14 )
        B14.Value = ba[14];

      if ( length > 13 )
        B13.Value = ba[13];

      if ( length > 12 )
        B12.Value = ba[12];

      if ( length > 11 )
        B11.Value = ba[11];

      if ( length > 10 )
        B10.Value = ba[10];

      if ( length > 9 )
        B9.Value = ba[9];

      if ( length > 8 )
        B8.Value = ba[8];

      if ( length > 7 )
        B7.Value = ba[7];

      if ( length > 6 )
        B6.Value = ba[6];

      if ( length > 5 )
        B5.Value = ba[5];

      if ( length > 4 )
        B4.Value = ba[4];

      if ( length > 3 )
        B3.Value = ba[3];

      if ( length > 2 )
        B2.Value = ba[2];

      if ( length > 1 )
        B1.Value = ba[1];

      if ( length > 0 )
        B0.Value = ba[0];
    }

    private void Commit_Click(object sender, RoutedEventArgs e)
    {
      if(FontMode)
      {
        UInt16 char_val = Convert.ToUInt16(txtCharCode.Text, 16);
        char c = Convert.ToChar(char_val);
        fonts.SetCharmap(c, getMap());
      }
      else
      {
        icons.SetCharmap(txtCharacter.Text, getMap());
      }
      
      ReloadComboBox();
    }

    private void txtCharCode_KeyDown(object sender, KeyEventArgs e)
    {
      if(e.Key == Key.Enter)
      {
        if ( FontMode )
        {
          try
          {
            UInt16 char_val = Convert.ToUInt16(txtCharCode.Text, 16);
            char c = Convert.ToChar(char_val);
            byte[] map = fonts.GetCharmap(c);
            if ( map != null )
              setMap(map);

            txtCharacter.Text = c.ToString();
          }
          catch ( Exception ex )
          {

          }
        }
      }
    }

    private void txtCharacter_KeyDown(object sender, KeyEventArgs e)
    {
      if ( e.Key != Key.Enter )
        return;

      if ( FontMode )
      {
        if ( txtCharacter.Text.Length != 1 )
          return;
        char c = char.Parse(txtCharacter.Text);
        txtCharCode.Text = "0x" + Convert.ToByte(c).ToString("X2");

        byte[] map = fonts.GetCharmap(c);
        if ( map != null )
          setMap(map);
      }
      else
      {
        byte[] map = icons.GetCharmap(txtCharacter.Text);
        if ( map != null )
          setMap(map);
      }
    }

    private void comboDone_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if ( comboDone.SelectedValue == null )
        return;

      if ( FontMode )
      {
        txtCharacter.Text = comboDone.SelectedValue.ToString();
        char c = char.Parse(txtCharacter.Text);
        txtCharCode.Text = "0x" + Convert.ToByte(c).ToString("X2");

        byte[] map = fonts.GetCharmap(c);
        if ( map != null )
        {
          setMap(map);
          ByteMap.Value = map;
          WidthSelector.Value = map.Length;
        }
      }
      else
      {
        txtCharacter.Text = comboDone.SelectedValue.ToString();

        byte[] map = icons.GetCharmap(txtCharacter.Text);
        if ( map != null )
        {
          setMap(map);
          ByteMap.Value = map;
          WidthSelector.Value = map.Length;
        }
      }
    }

    private void B_ValueChanged(object sender, EventArgs e)
    {
      ByteMap.Value = getMap();
    }

    private void ByteMap_EnterPressed(object sender, EventArgs e)
    {
      setMap(ByteMap.Value);
    }

    private void btnInvert_Click(object sender, RoutedEventArgs e)
    {
      byte[] ba = ByteMap.Value;

      for ( int i = 0; i < ba.Length; i++ )
      {
        ba[i] = (byte)(~ba[i]);
      }
      ByteMap.Value = ba;
      setMap(ba);  
    }

    private void btnMode_Click(object sender, RoutedEventArgs e)
    {
      if ( FontMode )
      {
        btnMode.Content = "Icon Mode";
        txtCharCode.IsEnabled = false;
        txtCharacter.MaxLength = 32;
      }
      else
      {
        btnMode.Content = "Font Mode";
        txtCharCode.IsEnabled = true;
        txtCharacter.MaxLength = 1;
      }
      FontMode = !FontMode;
      ReloadComboBox();
    }

    private void btnExport_Click(object sender, RoutedEventArgs e)
    {
      SaveFileDialog fileDialog = new SaveFileDialog();
      bool? res = fileDialog.ShowDialog();

      if(res == true)
      {
        string file = fileDialog.FileName;
        if ( FontMode )
          fonts.Export(file);
        else
          icons.save(file);
      }   
    }
  }
}
