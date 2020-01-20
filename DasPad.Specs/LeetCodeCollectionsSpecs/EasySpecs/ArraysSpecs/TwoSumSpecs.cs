using System;
using System.Collections.Generic;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.ArraysSpecs
{
  public class TwoSumSpecs
  {
    /*
     * Given an array of integers, return indices of the two numbers such that they add up to a specific target.

      You may assume that each input would have exactly one solution, and you may not use the same element twice.

      Example:

      Given nums = [2, 7, 11, 15], target = 9,

      Because nums[0] + nums[1] = 2 + 7 = 9,
      return [0, 1].
     */

    public int[] TwoSum(int[] nums, int target)
    {
      var complementsMap = new Dictionary<int, int>(nums.Length);
      for (var i = 0; i < nums.Length; i++)
      {
        var current = nums[i];
        var complement = target - current;
        if (complementsMap.ContainsKey(complement))
        {
          return new[] { complementsMap[complement], i };
        }
        else
        {
          complementsMap[current] = i;
        }
      }
      return Array.Empty<int>();
    }
  }
}
