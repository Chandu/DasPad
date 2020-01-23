using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class SumSubArraySpecs
  {
    public static T[] AsArray<T>(params T[] p)
    {
      return p;
    }

    public int SumSubarrayMins(int[] nums)
    {
      var subsets = SubArraysMins(nums);
      var toReturn = 0;
      foreach (var i in subsets)
      {
        toReturn += i;
      }
      return toReturn;
    }

    internal List<int> SubArraysMins(int[] nums)
    {
      List<int> results = new List<int>();

      for (var i = 0; i < nums.Length; i++)
      {
        var min = nums[i];
        for (var j = i; j < nums.Length; j++)
        {
          min = Math.Min(min, nums[j]);
          results.Add(min);
        }
      }
      return results;
    }

    [Fact]
    public void CanSumSubarrayMins()
    {
      var input = AsArray(48, 87, 27);
      Assert.Equal(264, SumSubarrayMins(input));
    }
  }
}
