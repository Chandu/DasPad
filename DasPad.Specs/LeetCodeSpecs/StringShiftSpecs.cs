using System.Text;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class StringShiftSpecs
  {
    public bool RotateString(string A, string B)
    {
      if (string.IsNullOrEmpty(A) && string.IsNullOrEmpty(B))
      {
        return true;
      }
      if (string.IsNullOrEmpty(A) || string.IsNullOrEmpty(B) || (A.Length != B.Length))
      {
        return false;
      }
      var i = 0;
      var sb = new StringBuilder(A);
      while (i <= A.Length - 2)
      {
        i++;
        var temp = sb[0];
        var j = 0;
        while (j < A.Length - 1)
        {
          sb[j] = sb[j + 1];
          j++;
        }
        sb[A.Length - 1] = temp;

        if (sb.ToString() == B)
        {
          return true;
        }
      }
      return false;
    }

    [Theory]
    [InlineData("abcde", "cdeab", true)]
    [InlineData("mndqvdqktyxknfdtklxapbkuxuzwubpiwmqgickuwqishkrgzu", "rgzumndqvdqktyxknfdtklxapbkuxuzwubpiwmqgickuwqishk", true)]
    public void CabRotateString(string A, string B, bool expected)
    {
      Assert.Equal(expected, RotateString(A, B));
    }
  }
}
