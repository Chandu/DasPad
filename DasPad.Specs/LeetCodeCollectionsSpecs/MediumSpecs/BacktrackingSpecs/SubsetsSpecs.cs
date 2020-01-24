using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.BacktrackingSpecs
{
  public class SubsetsSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/796/
     * Given a set of distinct integers, nums, return all possible subsets (the power set).

      Note: The solution set must not contain duplicate subsets.

      Example:

      Input: nums = [1,2,3]
      Output:
      [
        [3],
        [1],
        [2],
        [1,2,3],
        [1,3],
        [2,3],
        [1,2],
        []
      ]
     */

    public IList<IList<int>> Subsets(int[] nums)
    {
      var digits = nums.Length;
      var toReturn = new List<IList<int>>();
      for (var i = 0; i < Math.Pow(2, nums.Length); i++)
      {
        var curList = new List<int>();
        for (var j = 0; j < digits; j++)
        {
          if (IsKthBitSet(i, j))
          {
            curList.Add(nums[j]);
          }
        }
        toReturn.Add(curList);
      }
      return toReturn;
    }

    public static bool IsKthBitSet(int n, int k)
    {
      var seed = (1 << k);
      return (n & seed) == seed;
    }

    [Fact]
    public void CanGenerateSubsets()
    {
      var expected = new[] {
        new [] {3},
        new [] {1},
        new [] {2},
        new [] {1,2,3},
        new [] {1,3},
        new [] {2,3},
        new [] {1,2},
        Array.Empty<int>()
      };
      // Assert.Equal(expected, Subsets(new[] { 3, 1, 2 }));
    }
  }
}
