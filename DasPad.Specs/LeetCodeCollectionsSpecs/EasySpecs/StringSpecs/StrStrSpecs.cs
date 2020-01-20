using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.StringSpecs
{
  public class StrStrSpecs
  {
    /*
     * Implement strStr().

        Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

        Example 1:

        Input: haystack = "hello", needle = "ll"
        Output: 2
        Example 2:

        Input: haystack = "aaaaa", needle = "bba"
        Output: -1
        Clarification:

        What should we return when needle is an empty string? This is a great question to ask during an interview.

        For the purpose of this problem, we will return 0 when needle is an empty string. This is consistent to C's strstr() and Java's indexOf().
     */

    public int StrStr(string haystack, string needle)
    {
      if (string.IsNullOrEmpty(needle))
      {
        return 0;
      }

      var n = haystack.Length;
      var k = needle.Length;
      //Tip: Nice use of n-k instead of my initial thought of doing it in the inner for loop
      for (int i = 0; i <= n - k; i++)
      {
        var isFound = true;
        for (int j = 0; j < k; j++)
        {
          if (needle[j] != haystack[i + j])
          {
            isFound = false;
            break;
          }
        }
        if (isFound)
        {
          return i;
        }
      }
      return -1;
    }

    [Theory]
    [InlineData("abc", "ab", 0)]
    [InlineData("mississippi", "issipi", -1)]
    public void CanStrStr(string haystack, string needle, int expected)
    {
      Assert.Equal(expected, StrStr(haystack, needle));
    }
  }
}
