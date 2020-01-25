using System;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.DynamicProgrammingSpecs
{
  public class LongestIncreasingSubsequenceSpecs
  {
    /*
     *https://leetcode.com/explore/interview/card/top-interview-questions-medium/111/dynamic-programming/810/
     * Given an unsorted array of integers, find the length of longest increasing subsequence.

      Example:

      Input: [10,9,2,5,3,7,101,18]
      Output: 4
      Explanation: The longest increasing subsequence is [2,3,7,101], therefore the length is 4.
      Note:

      There may be more than one LIS combination, it is only necessary for you to return the length.
      Your algorithm should run in O(n2) complexity.
      Follow up: Could you improve it to O(n log n) time complexity?
     */

    public int LengthOfLIS(int[] nums)
    {
      if (nums.Length < 1)
      {
        return 0;
      }
      return LengthOfLISDpBottomUp(nums);
    }

    //Note
    /*
     * Problem Relation
     * S[i] = Max(For j 0..i if a[i] > a[j] S[j] + 1  )
     */

    public int LengthOfLISDpBottomUp(int[] nums)
    {
      var dp = new int[nums.Length];
      dp[0] = 1;
      for (var i = 0; i < nums.Length; i++)
      {
        dp[i] = 1;
      }
      for (var i = 1; i < nums.Length; i++)
      {
        dp[i] = 1;
        for (var j = 0; j < i; j++)
        {
          if (nums[i] > nums[j])
          {
            dp[i] = Math.Max(dp[i], dp[j] + 1);
          }
        }
      }
      return dp.Max();
    }

    [Theory]
    [InlineData(4, 10, 9, 2, 5, 3, 7, 101, 18)]
    [InlineData(6, 1, 3, 6, 7, 9, 4, 10, 5, 6)]
    public void CanFindLengthOfLIS(int expected, params int[] input)
    {
      Assert.Equal(expected, LengthOfLIS(input));
    }
  }
}
