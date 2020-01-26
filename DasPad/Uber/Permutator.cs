using System;
using System.Collections.Generic;

namespace DasPad.Uber
{
  public static class Permutator
  {
    public static string[] Permute(string str)
    {
      return Permute(str, 0, str.Length - 1);
    }

    public static string[] Permute(string str, int l, int r)
    {
      if (l == r)
        return new[] { str };
      else
      {
        var toReturn = new List<string>();
        for (int i = l; i <= r; i++)
        {
          str = Swap(str, l, i);
          toReturn.AddRange(Permute(str, l + 1, r));
          str = Swap(str, l, i);
        }
        return toReturn.ToArray();
      }
    }

    public static String Swap(String a, int i, int j)
    {
      char temp;
      char[] charArray = a.ToCharArray();
      temp = charArray[i];
      charArray[i] = charArray[j];
      charArray[j] = temp;
      string s = new string(charArray);
      return s;
    }
  }
}
