using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class ThreeSummer
  {
    public IList<IList<int>> ThreeSum(int[] nums)
    {
      Array.Sort(nums);
      var hashSet = new HashSet<(int, int, int)>();
      var length = nums.Length;
      for (var i = 0; i < length; i++)
      {
        var lhs = nums[i];
        if (i > 0 && nums[i] == nums[i - 1])
        {
          continue;
        }

        var left = 0;
        var right = length - 1;
        if (left == i)
        {
          left++;
        }
        if (right == i)
        {
          right--;
        }
        while (left < right)
        {
          var sum = nums[left] + nums[right] + lhs;
          if (sum == 0)
          {
            var result = new[] { nums[left], nums[right], lhs };
            Array.Sort(result);
            hashSet.Add((result[0], result[1], result[2]));
            left++;
            right--;
          }
          else if (sum < 0)
          {
            left++;
          }
          else //if(sum > 0)
          {
            right--;
          }
        }
      }
      var toReturn = new List<IList<int>>();
      foreach (var s in hashSet)
      {
        toReturn.Add(new List<int>()
        {
          s.Item1, s.Item2, s.Item3
        });
      }
      return toReturn;
    }

    [Fact]
    public void CanThreeSum()
    {
      var input = new[]
      {
        -1, 0, 1, 2, -1, -4
      };
      var expected = new List<List<int>>()
      {
        new List<int>() {-1, -1, 2 },
        new List<int>() {-1, 0, 1 },
      };

      Assert.Equal(expected, ThreeSum(input));
    }
  }
}
