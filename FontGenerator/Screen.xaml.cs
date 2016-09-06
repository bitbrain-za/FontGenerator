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
  /// Interaction logic for Screen.xaml
  /// </summary>
  public partial class Screen : UserControl
  {
    private ScreenData screen;
    ObservableCollection<Page> Pages { get; set; }

    public int x
    {
      get { return screen.Width; }
      set
      {
        screen.Width = value;
        foreach ( Page p in Pages )
          p.Length = value;
      }
    }

    public int y
    {
      get
      {
        return screen.Height;
      }
      set
      {
        if(value > screen.Height )
        {
          for ( ; screen.Height < value; screen.Height++ )
            Pages.Add(new Page());
        }
        else
        {
          for ( ; --screen.Height > value; )
            Pages.RemoveAt(screen.Height);

        }
        screen.Height = value;
      }
    }

    public Screen()
    {
      InitializeComponent();

      Pages = new ObservableCollection<Page>();

      screen = new ScreenData();

      for ( int i = 0; i < 8; i++ )
        Pages.Add(new Page());
    }

    public void Paint()
    {
    }

    public void Invert()
    {
      
    }

  }
}
