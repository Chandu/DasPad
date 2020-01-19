using System;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class ThreeSumClosestSpecs
  {
    public static T[] AsArray<T>(params T[] p)
    {
      return p;
    }

    public int ThreeSumClosest(int[] nums, int target)
    {
      if (nums.Length < 3)
      {
        return int.MinValue;
      }

      Array.Sort(nums);
      var curClosest = nums[0] + nums[1] + nums[2];
      var length = nums.Length;
      for (var i = 0; i < length; i++)
      {
        var lhs = nums[i];
        var left = i + 1;
        var right = length - 1;
        while (left < right)
        {
          var leftVal = nums[left];
          var rightVal = nums[right];
          var sum = lhs + leftVal + rightVal;
          if (sum == target)
          {
            return sum;
          }
          else if (sum < target)
          {
            left++;
          }
          else
          {
            right--;
          }

          if (Math.Abs(target - sum) < Math.Abs(target - curClosest))
          {
            curClosest = sum;
          }
        }
      }
      return curClosest;
    }

    [Fact]
    public void CanThreeSumClosest()
    {
      var input = AsArray(-1, 2, 1, -4);
      Assert.Equal(2, ThreeSumClosest(input, 1));
      Assert.Equal(0, ThreeSumClosest(AsArray(0, 0, 0), 1));
      Assert.Equal(3, ThreeSumClosest(AsArray(1, 1, 1, 1), 3));
    }
  }
}
