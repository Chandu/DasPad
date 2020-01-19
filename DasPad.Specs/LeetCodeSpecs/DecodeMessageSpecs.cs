using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class DecodeMessageSpecs
  {
    public int NumDecodings(string s)
    {
      return NumDecodingsHelper(s, 0, new Dictionary<int, int>());
    }

    public int NumDecodingsHelper(string s, int index, Dictionary<int, int> memo)
    {
      if(index >= s.Length)
      {
        return 1;
      }
      if(s[index] == '0')
      {
        return 0;
      }
      if(memo.ContainsKey(index))
      {
        return memo[index];
      }

      var result = NumDecodingsHelper(s, index + 1, memo);
      if(index + 1 < s.Length)
      {
        var val = Int32.Parse(s.Substring(index, 2));
        if(val < 27)
        {
          result += NumDecodingsHelper(s, index + 2, memo);
        }
      }
      return memo[index] = result;
    }

    [Theory]
    [InlineData("12", 2)]
    [InlineData("226", 3)]
    [InlineData("0", 0)]
    [InlineData("27", 1)]
    [InlineData("9371597631128776948387197132267188677349946742344217846154932859125134924241649584251978418763151253", 3981312)]
    public void CanDecodeMessage(string message, int decodings)
    {
      Assert.Equal(decodings, NumDecodings(message));
    }
  }
}
