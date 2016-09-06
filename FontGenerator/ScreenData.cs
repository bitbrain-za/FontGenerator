using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontGenerator
{
  class ScreenData
  {
    private int width = 128;
    private int height = 8;
    private byte[,] data;

    public int Width
    {
      get { return width; }
      set
      {
        byte[,] temp = new byte[height, width];
        Array.Copy(data, temp, height * width);

        data = new byte[height, value];

        for ( int i = 0; i < height; i++ )
        {
          for ( int j = 0; j < value; j++ )
          {
            if ( (i < height) && (j < width) )
              data[i, j] = temp[i, j];
          }
        }
        width = value;
      }
    }
    
    public int Height
    {
      get { return height; }
      set
      {
        byte[,] temp = new byte[height, width];
        Array.Copy(data, temp, height * width);

        data = new byte[value, width];

        for ( int i = 0; i < value; i++ )
        {
          for ( int j = 0; j < width; j++ )
          {
            if ( (i < height) && (j < width) )
              data[i, j] = temp[i, j];
          }
        }
        height = value;
      }
    }

    public byte[,] Data
    {
      get
      {
        return data;
      }

      set
      {
        height = value.GetLength(0);
        width = value.GetLength(1);

        data = value;
      }
    }

    public ScreenData()
    {
      data = new byte[128, 8];
    }



    
  }
}
