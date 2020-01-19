using System;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.YangshunSpecs.ArraysSpecs
{
  public class MaximumProductSubArraySpecs
  {
    //TODO: (CV) https://leetcode.com/problems/maximum-product-subarray/
    /*
     * Given an integer array nums, find the contiguous subarray within an array (containing at least one number) which has the largest product.

      Example 1:

      Input: [2,3,-2,4]
      Output: 6
      Explanation: [2,3] has the largest product 6.
      Example 2:

      Input: [-2,0,-1]
      Output: 0
      Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
     */

    public int MaxProduct(int[] nums)
    {
      if (nums == null || nums.Length == 0)
      {
        return 0;
      }
      int max = nums[0], min = nums[0], result = nums[0];
      for (int i = 1; i < nums.Length; i++)
      {
        int temp = max;
        max = Math.Max(Math.Max(max * nums[i], min * nums[i]), nums[i]);
        min = Math.Min(Math.Min(temp * nums[i], min * nums[i]), nums[i]);
        if (max > result)
        {
          result = max;
        }
      }
      return result;
    }

    [Fact]
    public void CanMaxProduct()
    {
      Assert.Equal(6, MaxProduct(AsArray(2, 3, -2, 4)));
      Assert.Equal(0, MaxProduct(AsArray(-2, 0, -1)));
    }
  }
}
