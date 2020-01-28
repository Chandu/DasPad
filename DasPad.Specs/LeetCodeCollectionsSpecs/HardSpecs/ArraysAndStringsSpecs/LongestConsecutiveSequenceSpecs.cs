using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class LongestConsecutiveSequenceSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-hard/116/array-and-strings/833/
     * Given an unsorted array of integers, find the length of the longest consecutive elements sequence.

        Your algorithm should run in O(n) complexity.

        Example:

        Input: [100, 4, 200, 1, 3, 2]
        Output: 4
        Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
     */

    public int LongestConsecutive(int[] nums)
    {
      return LongestConsecutiveUsingHashset(nums);
    }

    //Revisit
    public int LongestConsecutiveUsingHashset(int[] nums)
    {
      var numSet = new HashSet<int>();
      foreach (int num in nums)
      {
        numSet.Add(num);
      }

      int longestStreak = 0;

      foreach (int num in numSet)
      {
        if (!numSet.Contains(num - 1))
        {
          int currentNum = num;
          int currentStreak = 1;

          while (numSet.Contains(currentNum + 1))
          {
            currentNum += 1;
            currentStreak += 1;
          }

          longestStreak = Math.Max(longestStreak, currentStreak);
        }
      }

      return longestStreak;
    }

    [Theory]
    [InlineData(4, 100, 4, 200, 1, 3, 2)]
    public void CanLongestConsecutive(int expected, params int[] nums)
    {
      Assert.Equal(expected, LongestConsecutive(nums));
    }
  }
}
