using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DasPad.Specs.Extensions
{
  public static class ForString
  {
    public static int[] AsIntsFromCsv(this string source)
    {
      if (source == null || source.Trim().Length < 1)
      {
        return Array.Empty<int>();
      }
      return source.Split(',').Select(a => int.Parse(a.Trim())).ToArray();
    }

    public static string AsCsvFromIntsArray(this int[] source)
    {
      if (source == null || source.Length < 1)
      {
        return "";
      }
      return string.Join(",", source);
    }

    public static int[][] AsArraysFromJsArrays(this string source)
    {
      if (source == null || source.Trim().Length < 1)
      {
        return Array.Empty<int[]>();
      }
      var regex = new Regex("[^0-9,\\[\\]]");
      return regex.Replace(source, "").Trim().TrimStart('[').TrimEnd(']')
        .Split('[').Select(a => a.TrimEnd(',').TrimEnd(']').AsIntsFromCsv()).ToArray();
    }

    public static string AsJsArraysString(this int[][] source)
    {
      if (source == null)
      {
        return "[]";
      }
      var sb = new StringBuilder();
      sb.Append("[");

      foreach (var entry in source)
      {
        sb.Append("[");
        entry.ToList().ForEach(a => sb.Append(a.ToString() + ","));
        sb.Append("],");
      }
      sb.Append("]");

      return sb.ToString().Replace(",]", "]").Replace("],]", "]]");
    }
  }
}
