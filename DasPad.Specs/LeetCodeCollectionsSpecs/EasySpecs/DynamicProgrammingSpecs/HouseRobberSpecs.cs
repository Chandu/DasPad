﻿using System;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.DynamicProgrammingSpecs
{
  public class HouseRobberSpecs
  {
    /*
     * You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

      Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.

      Example 1:

      Input: [1,2,3,1]
      Output: 4
      Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
                   Total amount you can rob = 1 + 3 = 4.
      Example 2:

      Input: [2,7,9,3,1]
      Output: 12
      Explanation: Rob house 1 (money = 2), rob house 3 (money = 9) and rob house 5 (money = 1).
                   Total amount you can rob = 2 + 9 + 1 = 12.
     */
    //TIP NIce article on DP: https://leetcode.com/problems/house-robber/discuss/156523/From-good-to-great.-How-to-approach-most-of-DP-problems.

    //TODO: (CV) This is DP Bottom Up without a DP Array
    public int Rob(int[] nums)
    {
      if (nums.Length < 1)
      {
        return 0;
      }
      if (nums.Length < 2)
      {
        return nums[0];
      }
      nums[1] = Math.Max(nums[0], nums[1]);
      var max = Math.Max(nums[0], nums[1]);
      for (var i = 2; i < nums.Length; i++)
      {
        nums[i] = Math.Max(nums[i - 1], nums[i - 2] + nums[i]);
        max = Math.Max(max, nums[i]);
      }
      return max;
    }

    public int RobIteartiveWithoutMemo(int[] nums)
    {
      if (nums.Length < 1)
      {
        return 0;
      }
      if (nums.Length < 2)
      {
        return nums[0];
      }
      var dp = new int[nums.Length + 1];
      dp[0] = nums[0];
      dp[1] = Math.Max(nums[0], nums[1]);
      for (var i = 2; i < nums.Length; i++)
      {
        dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
      }
      return dp.Max();
    }

    public int RobIteartiveWithMemo(int[] nums)
    {
      if (nums.Length < 1)
      {
        return 0;
      }
      if (nums.Length < 2)
      {
        return nums[0];
      }
      var dp = new int[nums.Length + 1];
      dp[0] = nums[0];
      dp[1] = Math.Max(nums[0], nums[1]);
      for (var i = 2; i < nums.Length; i++)
      {
        dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
      }
      return dp.Max();
    }

    [Theory]
    [InlineData(4, 1, 2, 3, 1)]
    public void CanRob(int expected, params int[] input)
    {
      Assert.Equal(expected, Rob(input));
    }
  }
}
