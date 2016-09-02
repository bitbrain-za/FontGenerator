using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FontGenerator
{
  class font_file
  {
    private Dictionary<char, byte[]> font_map;

    public font_file(string font_file)
    {
      font_map = new Dictionary<char, byte[]>();

      if ( font_file == null )
        font_file = "temp.csv";

      if ( File.Exists(font_file) )
        load(font_file);
    }

    public byte[] GetCharmap(char c)
    {
      if ( font_map.ContainsKey(c) )
        return font_map[c];
      else
        return null;
    }

    public void SetCharmap(char c, byte[] ba)
    {
      if ( font_map.ContainsKey(c) )
        font_map.Remove(c);

      font_map.Add(c, ba);
    }

    public char[] Contents()
    {
      return font_map.Keys.ToArray();
    }

    public void load(string path)
    {
      StreamReader reader = new StreamReader(path);

      string line;
      while((line = reader.ReadLine()) != null )
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
        foreach(KeyValuePair<char, byte[]> map in font_map)
        {
          string line = "";
          line += map.Key;
          line += "|;|";
          line += map.Value.Length.ToString();
          line += "|;|";
          foreach(byte b in map.Value)
          {
            line += "0x" + b.ToString();
            line += ", ";
          }
          line = line.Substring(0, line.Length - 2);
          sw.WriteLine(line);
        }
      }
    }

    private void parse_line(string line)
    {
      string[] separators = { "|;|" };
      string[] parts = line.Split(separators, StringSplitOptions.None);

      char c = char.Parse(parts[0]);
      int length = int.Parse(parts[1]);

      List<byte> map_bytes = new List<byte>();

      parts[2] = parts[2].Replace(" ", "");
      parts = parts[2].Split(',');

      for(int i = 0; i < length; i++ )
      {
        byte b = (Convert.ToByte(parts[i], 16));
        //byte b = byte.Parse(parts[i]);
        map_bytes.Add(b);
      }

      SetCharmap(c, map_bytes.ToArray());
    }

    public void Export(string path)
    {
      if ( File.Exists(path) )
        File.Delete(path);

      class_decleration(path);

      using ( StreamWriter sw = File.AppendText(path) )
      {
        sw.WriteLine("/* Put this in the font class */");
        sw.WriteLine("character charmap[" + font_map.Count.ToString() + "]");

        sw.WriteLine('\n');
        
        sw.WriteLine("character charmap[" + font_map.Count.ToString() + "]");
        
        KeyValuePair<char, byte[]>[] character = font_map.ToArray();

        for(int i = 0; i < font_map.Count; i++ )
        {
          string line;
          if((character[i].Key == '\'') || (character[i].Key == '\\'))
          {
            line = "charmap[0x" + i.ToString("X2") + "] = character(\'\\" + character[i].Key + "\', " + character[i].Value.Length.ToString();
          }
          else
          {
            line = "charmap[0x" + i.ToString("X2") + "] = character(\'" + character[i].Key + "\', " + character[i].Value.Length.ToString();
          }

          for(int j = 0; j < character[i].Value.Length; j++ )
          {
            line += ", 0x" + character[i].Value[j].ToString("X2");
          }
          line += ");";
          sw.WriteLine(line);

        }
      }
    }

    private void class_decleration(string path)
    {
      File.WriteAllText(path, FontGenerator.Properties.Resources.character_class);
    }


  }
}
