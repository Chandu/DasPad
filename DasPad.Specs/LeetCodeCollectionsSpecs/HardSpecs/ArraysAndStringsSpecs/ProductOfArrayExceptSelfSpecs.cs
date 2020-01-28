using DasPad.Specs.Extensions;
using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class ProductOfArrayExceptSelfSpecs
  {
    /*
     * Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

      Example:

      Input:  [1,2,3,4]
      Output: [24,12,8,6]
      Note: Please solve it without division and in O(n).

      Follow up:
      Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)
     */

    //Trick:
    public int[] ProductExceptSelf(int[] nums)
    {
      if (nums.Length < 1)
      {
        return Array.Empty<int>();
      }
      var leftProducts = new int[nums.Length];
      leftProducts[0] = 1;
      for (var i = 1; i < leftProducts.Length; i++)
      {
        leftProducts[i] = leftProducts[i - 1] * nums[i - 1];
      }
      var rightProducts = new int[nums.Length];
      rightProducts[nums.Length - 1] = 1;
      var rightProduct = 1;
      for (var i = nums.Length - 1; i >= 0; i--)
      {
        rightProducts[i] = rightProduct * leftProducts[i];
        rightProduct *= nums[i];
      }

      return rightProducts;
    }

    [Theory]
    [InlineData("1,2,3,4", "24,12,8,6")]
    public void CanProductExceptSelf(string input, string expected)
    {
      Assert.Equal(expected.AsIntsFromCsv(), ProductExceptSelf(input.AsIntsFromCsv()));
    }
  }
}
