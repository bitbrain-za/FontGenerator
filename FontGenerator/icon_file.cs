using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FontGenerator
{
  class icon_file
  {
    private Dictionary<string, byte[]> icon_map;

    public icon_file(string icon_file)
    {
      icon_map = new Dictionary<string, byte[]>();

      if ( icon_file == null )
        icon_file = "icons.csv";

      if ( File.Exists(icon_file) )
        load(icon_file);
    }

    public byte[] GetCharmap(string name)
    {
      if ( icon_map.ContainsKey(name) )
        return icon_map[name];
      else
        return null;
    }

    public void SetCharmap(string name, byte[] ba)
    {
      if ( icon_map.ContainsKey(name) )
        icon_map.Remove(name);

      icon_map.Add(name, ba);
    }

    public string[] Contents()
    {
      return icon_map.Keys.ToArray();
    }

    public void load(string path)
    {
      StreamReader reader = new StreamReader(path);

      string line;
      while ( (line = reader.ReadLine()) != null )
      {
        parse_line(line);
      }
      reader.Close();
    }

    public void save(string path)
    {
      if ( File.Exists(path) )
        File.Delete(path);

      using ( StreamWriter sw = File.AppendText(path) )
      {
        foreach ( KeyValuePair<string, byte[]> map in icon_map )
        {
          string line = "";
          line += map.Key;
          line += "|";
          line += map.Value.Length.ToString();
          line += "|";
          foreach ( byte b in map.Value )
          {
            line += "0x" + b.ToString("X2");
            line += ", ";
          }
          line = line.Substring(0, line.Length - 2);
          sw.WriteLine(line);
        }
      }
    }

    private void parse_line(string line)
    {
      string[] separators = { "|" };
      string[] parts = line.Split(separators, StringSplitOptions.None);

      string name = parts[0];
      int length = int.Parse(parts[1]);

      List<byte> map_bytes = new List<byte>();

      parts[2] = parts[2].Replace(" ", "");
      parts = parts[2].Split(',');

      for ( int i = 0; i < length; i++ )
      {
        byte b = (Convert.ToByte(parts[i], 16));
        map_bytes.Add(b);
      }

      SetCharmap(name, map_bytes.ToArray());

    }
  }
}
