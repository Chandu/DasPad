using System;
using System.Text;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class LongestCommonPrefixSpecs
  {
    public string LongestCommonPrefix(string[] strs)
    {
      if (strs.Length == 1)
      {
        return strs[0];
      }
      if (strs.Length < 1)
      {
        return "";
      }

      var minLength = strs[0].Length;
      for (var i = 1; i < strs.Length; i++)
      {
        minLength = Math.Min(minLength, strs[i].Length);
      }
      var curCP = new StringBuilder(minLength);
      var curIndex = 0;
      while (curIndex < minLength)
      {
        var ithChar = strs[0][curIndex];
        for (var j = 1; j < strs.Length; j++)
        {
          if (strs[j][curIndex] != ithChar)
          {
            return curCP.ToString();
          }
        }
        curCP.Append(ithChar);
        curIndex++;
      }
      return curCP.ToString();
    }

    [Fact]
    public void CanGetLongestCommonPrefix()
    {
      var input = new[]
      {
        "flower","flow","flight"
      };
      Assert.Equal("fl", LongestCommonPrefix(input));
    }
  }
}
