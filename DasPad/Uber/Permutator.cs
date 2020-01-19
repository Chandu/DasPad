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

    public class TreeNode
    {
      public TreeNode Left = null;
      public TreeNode Right = null;
      public Char Value;
    }

    public static TreeNode ToTreeNode(string input)
    {
      if (input.Length < 1)
      {
        return null;
      }

      TreeNode toReturn = null;
      TreeNode curNode = null;

      foreach (var s in input)
      {
        if (toReturn == null)
        {
          toReturn = new TreeNode
          {
            Value = s
          };
          curNode = toReturn;
        }
        else
        {
          curNode.Left = new TreeNode
          {
            Value = s
          };
          curNode = curNode.Left;
        }
      }
      return toReturn;
    }

    public static void PermuteUsingTree(string input)
    {
      var node = ToTreeNode(input);
    }
  }
}
