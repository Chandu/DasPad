using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class FindAnagramsSpecs
  {
    /*
     * Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.

      Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.

      The order of output does not matter.

      Example 1:

      Input:
      s: "cbaebabacd" p: "abc"

      Output:
      [0, 6]
      Explanation:
      The substring with start index = 0 is "cba", which is an anagram of "abc".
      The substring with start index = 6 is "bac", which is an anagram of "abc".
      Example 2:

      Input:
      s: "abab" p: "ab"

      Output:
      [0, 1, 2]
      Explanation:
      The substring with start index = 0 is "ab", which is an anagram of "ab".
      The substring with start index = 1 is "ba", which is an anagram of "ab".
      The substring with start index = 2 is "ab", which is an anagram of "ab".
     */

    public IList<int> FindAnagrams(string s, string p)
    {
      var toReturn = new List<int>();
      if (s.Count() < p.Count())
      {
        return toReturn;
      }

      var pHash = new Dictionary<char, int>();
      foreach (var a in p)
      {
        if (!pHash.ContainsKey(a))
        {
          pHash[a] = 0;
        }
        pHash[a]++;
      }
      var sHash = new Dictionary<char, int>();
      var left = 0;
      var right = 0;
      while (right < p.Length)
      {
        var key = s[right];
        if (!sHash.ContainsKey(key))
        {
          sHash[key] = 0;
        }
        sHash[key]++;
        right++;
      }

      if (AreSame(sHash, pHash))
      {
        toReturn.Add(left);
      }
      left++;
      //right++;
      while (right < s.Length)
      {
        var prev = s[left - 1];
        var cur = s[right];
        if (sHash.ContainsKey(prev))
        {
          sHash[prev]--;
          if (sHash[prev] == 0)
          {
            sHash.Remove(prev);
          }
        }
        if (!sHash.ContainsKey(cur))
        {
          sHash[cur] = 0;
        }
        sHash[cur]++;
        if (AreSame(sHash, pHash))
        {
          toReturn.Add(left);
        }
        left++;
        right++;
      }

      return toReturn;
    }

    private bool AreSame(Dictionary<char, int> source, Dictionary<char, int> target)
    {
      if (source.Count() != target.Count())
      {
        return false;
      }
      return !source.Any(a => !target.ContainsKey(a.Key) || target[a.Key] != a.Value);
    }

    [Theory]
    [InlineData("cbaebabacd", "abc", 0, 6)]
    public void CanFindAnagrams(string s, string p, params int[] output)
    {
      Assert.Equal(output, FindAnagrams(s, p));
    }
  }
}
