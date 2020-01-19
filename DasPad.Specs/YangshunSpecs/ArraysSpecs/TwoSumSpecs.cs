using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.YangshunSpecs.ArraysSpecs
{
  public class TwoSumSpecs
  {
    public T[] AsArray<T>(params T[] parameters) => parameters;

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

    [Fact]
    public void CanTwoSum()
    {
      Assert.Equal(AsArray(0, 1), TwoSum(AsArray(2, 7, 11, 15), 9));
    }
  }
}
