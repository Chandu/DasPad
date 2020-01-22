using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.DynamicProgrammingSpecs
{
  public class MaximumSubArraySpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-easy/97/dynamic-programming/566/
     * Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.

        Example:

        Input: [-2,1,-3,4,-1,2,1,-5,4],
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
        Follow up:

        If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
     */

    public int MaxSubArray(int[] nums)
    {
      return MaxSubArrayUsingDivideAndConquer(nums);
    }

    //TODO: (CV) TIP Using Divide and Conquer with nLogn T for MaxSubArray
    /*
     *  1) Divide the given array in two halves
        2) Return the maximum of following three
        ….a) Maximum subarray sum in left half (Make a recursive call)
        ….b) Maximum subarray sum in right half (Make a recursive call)
        ….c) Maximum subarray sum such that the subarray crosses the midpoint

        The lines 2.a and 2.b are simple recursive calls. How to find maximum subarray sum such that the subarray crosses the midpoint? We can easily find the crossing sum in linear time. The idea is simple, find the maximum sum starting from mid point and ending at some point on left of mid, then find the maximum sum starting from mid + 1 and ending with sum point on right of mid + 1. Finally, combine the two and return.
     */

    public int MaxSubArrayUsingDivideAndConquer(int[] nums)
    {
      return MaxSubArrayUsingDivideAndConquerHelper(nums, 0, nums.Length - 1);
    }

    public int MaxSubArrayUsingDivideAndConquerHelper(int[] nums, int start, int end)
    {
      if (start > end)
      {
        return Int32.MinValue;
      }
      if (start == end)
      {
        return nums[start];
      }

      int mid = start + (end - start) / 2;
      var lMax = MaxSubArrayUsingDivideAndConquerHelper(nums, start, mid);
      var rMax = MaxSubArrayUsingDivideAndConquerHelper(nums, mid + 1, end);
      var lrMax = Math.Max(lMax, rMax);
      var lAndRMax = checked(MaxSumBetween(nums, start, mid, true) + MaxSumBetween(nums, mid + 1, end, false));
      return Math.Max(lrMax, lAndRMax);
    }

    public int MaxSumBetween(int[] nums, int start, int end, bool moveLeft)
    {
      var maxSum = Int32.MinValue;
      if (moveLeft)
      {
        //TODO: (CV) LookAgain This fails if we assign curSum to nums[end], need to check why
        var curSum = 0;

        for (var i = end; i >= start; i--)
        {
          curSum += nums[i];
          maxSum = Math.Max(maxSum, curSum);
        }
      }
      else
      {
        //TODO: (CV) LookAgain This fails if we assign curSum to nums[start], need to check why
        var curSum = 0;
        for (var i = start; i <= end; i++)
        {
          curSum += nums[i];
          maxSum = Math.Max(maxSum, curSum);
        }
      }

      return maxSum;
    }

    public int MaxSubArrayUsingDP(int[] nums)
    {
      if (nums.Length < 1)
      {
        return 0;
      }
      if (nums.Length == 1)
      {
        return nums[0];
      }
      var dp = new int[nums.Length];
      dp[0] = nums[0];
      var maxSum = nums[0];

      for (var i = 1; i < nums.Length; i++)
      {
        dp[i] = Math.Max(nums[i], nums[i] + dp[i - 1]);
        maxSum = Math.Max(maxSum, dp[i]);
      }
      return maxSum;
    }

    [Theory]
    [InlineData(6, -2, 1, -3, 4, -1, 2, 1, -5, 4)]
    [InlineData(-1, -1, -2)]
    public void CanMaxSubArray(int expected, params int[] nums)
    {
      Assert.Equal(expected, MaxSubArray(nums));
    }
  }
}
