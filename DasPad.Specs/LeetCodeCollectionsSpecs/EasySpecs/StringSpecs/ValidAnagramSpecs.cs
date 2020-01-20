using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.StringSpecs
{
  public class ValidAnagramSpecs
  {
    /*
     * Given two strings s and t , write a function to determine if t is an anagram of s.

      Example 1:

      Input: s = "anagram", t = "nagaram"
      Output: true
      Example 2:

      Input: s = "rat", t = "car"
      Output: false
      Note:
      You may assume the string contains only lowercase alphabets.

      Follow up:
      What if the inputs contain unicode characters? How would you adapt your solution to such case?
     */

    public bool IsAnagram(string s, string t)
    {
      if (s.Length != t.Length)
      {
        return false;
      }
      var hashMap = new Dictionary<char, int>();
      foreach (var c in s)
      {
        if (!hashMap.ContainsKey(c))
        {
          hashMap[c] = 0;
        }
        hashMap[c]++;
      }
      foreach (var c in t)
      {
        if (!hashMap.ContainsKey(c))
        {
          return false;
        }
        hashMap[c]--;
        if (hashMap[c] == 0)
        {
          hashMap.Remove(c);
        }
      }
      return !hashMap.Any();
    }

    [Theory]
    [InlineData("anagram", "nagaram", true)]
    public void CanVerifyIsAnagram(string first, string second, bool expected)
    {
      Assert.Equal(expected, IsAnagram(first, second));
    }
  }
}
