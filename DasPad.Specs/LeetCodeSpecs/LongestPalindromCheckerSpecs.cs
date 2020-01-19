using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class LongestPalindromCheckerSpecs
  {
    public string LongestPalindrome(string input)
    {
      if (string.IsNullOrEmpty(input))
      {
        return "";
      }
      var length = input.Length;
      var tabulation = new bool[length, length];
      int longestSoFar = 0, startIndex = 0, endIndex = 0;
      for (var j = 0; j < length; j++)
      {
        tabulation[j, j] = true;
        for (var i = 0; i < j; i++)
        {
          if (input[i] == input[j])
          {
            if (j == 1 + i || tabulation[i + 1, j - 1])
            {
              tabulation[i, j] = true;

              if (j - i + 1 > longestSoFar)
              {
                longestSoFar = j - i + 1;
                startIndex = i;
                endIndex = j;
              }
            }
          }
        }
      }
      return input.Substring(startIndex, endIndex - startIndex + 1);
    }

    [Theory]
    //[InlineData("bababbdbababad", "babab")]
    [InlineData("dabcbac", "abcba")]
    //[InlineData("cbbd", "bb")]
    public void CanGetLongestPlaindrome(string input, string expected)
    {
      Assert.Equal(expected, LongestPalindrome(input));
    }
  }
}
