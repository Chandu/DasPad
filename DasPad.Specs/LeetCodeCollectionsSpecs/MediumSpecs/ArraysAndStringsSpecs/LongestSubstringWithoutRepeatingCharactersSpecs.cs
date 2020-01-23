using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.ArraysAndStringsSpecs
{
  public class LongestSubstringWithoutRepeatingCharactersSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/779/
     * Given a string, find the length of the longest substring without repeating characters.

      Example 1:

      Input: "abcabcbb"
      Output: 3
      Explanation: The answer is "abc", with the length of 3.
      Example 2:

      Input: "bbbbb"
      Output: 1
      Explanation: The answer is "b", with the length of 1.
      Example 3:

      Input: "pwwkew"
      Output: 3
      Explanation: The answer is "wke", with the length of 3.
                   Note that the answer must be a substring, "pwke" is a subsequence and not a substring.
     */

    //TIP: Whenever there is a non-repeating or repeating in req first chekc if you could utilize a HashSet/Map or two pointers to identify repetitions.
    //TIP: The idea is use a hash set to track the longest substring without repeating characters so far, use a fast pointer j to see if character j is in the hash set or not, if not, great, add it to the hash set, move j forward and update the max length, otherwise, delete from the head by using a slow pointer i until we can put character j to the hash set.
    public int LengthOfLongestSubstring(string s)
    {
      int i = 0, j = 0, max = 0;
      var set = new HashSet<Char>();

      while (j < s.Length)
      {
        if (!set.Contains(s[j]))
        {
          set.Add(s[j++]);
          max = Math.Max(max, set.Count);
        }
        else
        {
          set.Remove(s[i++]);
        }
      }

      return max;
    }

    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("pwwkew", 3)]
    [InlineData(" ", 1)]
    [InlineData("au", 2)]
    [InlineData("dvdf", 3)]
    public void CanFindLengthOfLongestSubstring(string s, int expected)
    {
      Assert.Equal(expected, LengthOfLongestSubstring(s));
    }
  }
}
