using System;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class ReverseKCharsOfStringSpecs
  {
    public string ReverseStr(string s, int k)
    {
      var input = s.ToCharArray();
      var i = 0;
      while ((i * k) < s.Length)
      {
        if (i % 2 == 0)
        {
          var end = Math.Min(s.Length, (i * k) + k);
          ReverseArray(input, (i * k), end - 1);
        }
        i++;
      }

      return string.Join("", input);
    }

    private void ReverseArray(char[] input, int start, int end)
    {
      while (start <= end)
      {
        var temp = input[start];
        input[start] = input[end];
        input[end] = temp;
        start++;
        end--;
      }
    }

    [Theory]
    [InlineData("abcdefg", 2, "bacdfeg")]
    [InlineData("a", 2, "a")]
    public void CanReverseStr(string input, int k, string expected)
    {
      Assert.Equal(expected, ReverseStr(input, k));
    }
  }
}
