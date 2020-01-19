using System;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.YangshunSpecs.ArraysSpecs
{
  public class MaxAreaOfHistrogramSpecs
  {
    //TODO: (CV) https://leetcode.com/problems/container-with-most-water/solution/

    public int MaxAreaBruteForce(int[] height)
    {
      int maxArea = 0;
      for (int i = 0; i < height.Length; i++)
      {
        for (int j = i + 1; j < height.Length; j++)
        {
          maxArea = Math.Max(maxArea, Math.Min(height[i], height[j]) * (j - i));
        }
      }

      return maxArea;
    }

    //TODO: (CV) Intuitive Max Area
    public int MaxAreaTwoPointers(int[] height)
    {
      if (height.Length == 0)
      {
        return 0;
      }
      if (height.Length == 1)
      {
        return height[0] * height[0];
      }
      var maxArea = 0;
      var left = 0;
      var right = height.Length - 1;
      while (left < right)
      {
        var curArea = Math.Min(height[left], height[right]) * (right - left);
        maxArea = Math.Max(curArea, maxArea);
        if (height[left] < height[right])
        {
          left++;
        }
        else
        {
          right--;
        }
      }
      return maxArea;
    }

    private void CanMaxArea(Func<int[], int> fn)
    {
      Assert.Equal(49, fn(AsArray(1, 8, 6, 2, 5, 4, 8, 3, 7)));
    }

    [Fact]
    public void CanMaxAreaBruteForce()
    {
      CanMaxArea(MaxAreaBruteForce);
    }

    [Fact]
    public void CanMaxAreaTwoPointers()
    {
      CanMaxArea(MaxAreaTwoPointers);
    }
  }
}
