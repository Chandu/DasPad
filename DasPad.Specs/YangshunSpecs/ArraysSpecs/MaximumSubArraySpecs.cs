using System;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.YangshunSpecs.ArraysSpecs
{
  public class MaximumSubArraySpecs
  {
    //TODO:(CV) https://leetcode.com/problems/maximum-subarray/
    /*
     * Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
     * Example:
        Input: [-2,1,-3,4,-1,2,1,-5,4],
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
     */
    /*
     * Kadane’s Algorithm:
     ~~~~~~~~~~~~~~~~~~~~~~~~~

      Initialize:
          max_so_far = 0
          max_ending_here = 0

      Loop for each element of the array
        (a) max_ending_here = max_ending_here + a[i]
        (b) if(max_ending_here < 0)
                  max_ending_here = 0
        (c) if(max_so_far < max_ending_here)
                  max_so_far = max_ending_here
      return max_so_far
     */

    public int MaxSubArray(int[] nums)
    {
      int[] dp = new int[nums.Length];
      int max = nums[0];
      dp[0] = nums[0];
      for (int i = 1; i < nums.Length; i++)
      {
        //Set dp[i] to either maximum sum so far with nums[i] or just nums[i], in the latter case the longest subaray starts with i now.
        dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
        max = Math.Max(max, dp[i]);
      }
      return max;
    }

    [Fact]
    public void CanMaxSubArray()
    {
      Assert.Equal(6, MaxSubArray(AsArray(-2, 1, -3, 4, -1, 2, 1, -5, 4)));
      Assert.Equal(5, MaxSubArray(AsArray(3, -2, 4)));
    }
  }
}
