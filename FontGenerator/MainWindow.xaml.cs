using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
      WidthSelector.Value = 128;
      WidthSelector.Minimum = 1;
      WidthSelector.Maximum = 128;

      HeightSelector.Value = 8;
            
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

    private void HeightSelector_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      Slider s = sender as Slider;
      set_height((int)(s.Value));
    }

    private void set_width(int val)
    {
      if ( bitmap != null )
      {
        bitmap.x = val;
        w.Text = val.ToString();
      }
    }

    private void set_height(int val)
    {
      if ( bitmap != null )
      {
        bitmap.y = val;
        h.Text = val.ToString();
      }
    }

    private void Clear_Click(object sender, RoutedEventArgs e)
    {
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
      return bytes.ToArray();
    }

    private void setMap(byte[] ba)
    {
      int length = ba.Length;

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
          WidthSelector.Value = map.Length;
        }
      }
    }

    private void B_ValueChanged(object sender, EventArgs e)
    {
    }

    private void ByteMap_EnterPressed(object sender, EventArgs e)
    {
    }

    private void btnInvert_Click(object sender, RoutedEventArgs e)
    {
      bitmap.Invert();
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

    private static bool IsTextAllowed(string text)
    {
      Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
      return !regex.IsMatch(text);
    }

    private void numericPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      e.Handled = !IsTextAllowed(e.Text);
    }

    private void h_KeyDown(object sender, KeyEventArgs e)
    {
      if ( e.Key == Key.Return )
      {
        if ( h.Text == "" )
          h.Text = "1";
        HeightSelector.Value = int.Parse(h.Text);
      }
    }

    private void w_KeyDown(object sender, KeyEventArgs e)
    {
      if ( e.Key == Key.Return )
      {
        if ( w.Text == "" )
          w.Text = "1";
        WidthSelector.Value = int.Parse(w.Text);
      }
    }
  }
}
