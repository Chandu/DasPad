using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class CountSubstringsSpecs
  {/*
    Given a string, your task is to count how many palindromic substrings in this string.

    The substrings with different start indexes or end indexes are counted as different substrings even they consist of same characters.

    Example 1:

    Input: "abc"
    Output: 3
    Explanation: Three palindromic strings: "a", "b", "c".

    Example 2:

    Input: "aaa"
    Output: 6
    Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".

    Note:

    The input string length won't exceed 1000.
    */

    public int CountSubstrings(string s)
    {
      return CountSubstringsDp(s);
    }

    public int CountSubstringsBruteForce(string s)
    {
      var count = 0;
      for (var i = 0; i < s.Length; i++)
      {
        for (var j = i; j < s.Length; j++)
        {
          var result = IsPalindrome(s.Substring(i, j - i + 1));
          if (result)
          {
            count++;
          }
        }
      }
      return count;
    }

    public int CountSubstringsDp(string s)
    {
      if (s.Length < 2)
      {
        return 1;
      }
      //S[i, j] = true if s[i] == s[j] and S[i+1, j-1]
      /*
       * A little explanation for why the indices in the for loops are set the way they are (I was really confused for a long time):

      j must be greater than or equal i at all times. Why? i is the start index of the substring, j is the end index of the substring. It makes no sense for i to be greater than j. Visualization helps me, so if you visualize the dp 2d array, think of a diagonal that cuts from top left to bottom right. We are only filling the top right half of dp.

      Why are we counting down for i, but counting up for j? Each sub-problem dp[i][j] depends on dp[i+1][j-1] (dp[i+1][j-1] must be true and s.charAt(i) must equal s.charAt(j) for dp[i][j] to be true).
       */
      var dp = new bool[s.Length][];
      var n = s.Length;
      var count = 0;
      for (int i = n - 1; i >= 0; i--)
      {
        dp[i] = new bool[n];
        for (int j = i; j < n; j++)
        {
          dp[i][j] = s[i] == s[j] && (j - i < 3 || dp[i + 1][j - 1]);
          if (dp[i][j])
          {
            count++;
          }
        }
      }
      return count;
    }

    public bool IsPalindrome(string s)
    {
      var left = 0;
      var right = s.Length - 1;
      while (left < right)
      {
        if (s[left] != s[right])
        {
          return false;
        }
        left++;
        right--;
      }
      return true;
    }

    [Theory]
    [InlineData("aaa", 6)]
    public void CanCountPalindromes(string input, int expected)
    {
      Assert.Equal(expected, CountSubstrings(input));
    }
  }
}
