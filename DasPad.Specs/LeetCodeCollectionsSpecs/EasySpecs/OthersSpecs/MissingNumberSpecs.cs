using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.OthersSpecs
{
  public class MissingNumberSpecs
  {
    /*
     * Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.

      Example 1:

      Input: [3,0,1]
      Output: 2
      Example 2:

      Input: [9,6,4,2,3,5,7,0,1]
      Output: 8
      Note:
      Your algorithm should run in linear runtime complexity. Could you implement it using only constant extra space complexity?
     */

    public int MissingNumber(int[] nums)
    {
      return MissingNumberUsingMath(nums);
    }

    internal static int MissingNumberUsingMath(int[] nums)
    {
      //TODO: (CV) Tip: Summation Series formula is n(n+1)/2. So if the sum of array equals n(n+1)/2 then missing is 0. Else it is n(n+1)/2 - Sum of Array

      var sumOfArray = 0;
      int expectedSum = nums.Length * (nums.Length + 1) / 2;
      for (var i = 0; i < nums.Length; i++)
      {
        sumOfArray += nums[i];
      }
      return expectedSum - sumOfArray;
    }

    internal static int MissingNumberUsingSort(int[] nums)
    {
      Array.Sort(nums);
      for (var i = 0; i < nums.Length; i++)
      {
        if (i != nums[i])
        {
          return i;
        }
      }
      //TODO: (CV) I misread the question (yet again). If the code has reached to thsi point that is all the numbers are valid and present in the array from 0..n-1 (since the array will be of length n (actually it would be n+1 since the numbers are starting from 0)) hence we simply return n which in this case happens to be the length of the array.
      return nums.Length;
    }

    [Theory]
    [InlineData(2, 3, 0, 1)]
    [InlineData(1, 0)]
    [InlineData(0, 1)]
    public void CanFindMissingNumber(int expected, params int[] input)
    {
      Assert.Equal(expected, MissingNumber(input));
    }
  }
}
