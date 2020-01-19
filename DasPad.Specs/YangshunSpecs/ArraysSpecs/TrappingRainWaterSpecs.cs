using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.YangshunSpecs.ArraysSpecs
{
  public class TrappingRainWaterSpecs
  {
    //TODO: (CV) https://leetcode.com/problems/trapping-rain-water/solution/
    /*
     * Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.
     */
    public int Trap(int[] height)
    {
      int left = 0, right = height.Length - 1;
      int ans = 0;
      int left_max = 0, right_max = 0;
      while (left < right)
      {
        if (height[left] < height[right])
        {
          if (height[left] >= left_max)
          {
            left_max = height[left];
          }
          else
          {
            ans += (left_max - height[left]);
          }
          ++left;
        }
        else
        {
          if (height[right] >= right_max)
          {
            right_max = height[right];
          }
          else
          {
            ans += (right_max - height[right]);
          }
          --right;
        }
      }
      return ans;
    }

    [Fact]
    public void CanTrap()
    {
      Assert.Equal(6, Trap(AsArray(0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1)));
    }
  }
}
