using DasPad.Algos;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class IsStringMadeOfSubstringsSpecs
  {
    public bool Verify(string input)
    {
      if (input.Length == 0)
      {
        return true;
      }
      else if (input.Length == 1)
      {
        return true;
      }
      var lps = KmpAlgorithm.CreateLps(input);
      var last = lps[lps.Length - 1];

      return input.Length % last == 0;
    }

    [Theory]
    [InlineData("abcabc", true)]
    [InlineData("abcdabc", false)]
    public void CanVerify(string input, bool expected)
    {
      var actual = Verify(input);
      Assert.Equal(expected, actual);
    }
  }
}
