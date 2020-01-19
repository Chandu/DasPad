using System;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.YangshunSpecs.ArraysSpecs
{
  public class MinimumInRoatedSortedArraySpecs
  {
    //TODO: (CV): https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
    /*
     * Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

      (i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).

      Find the minimum element.

      You may assume no duplicate exists in the array.

      Example 1:

      Input: [3,4,5,1,2]
      Output: 1
      Example 2:

      Input: [4,5,6,7,0,1,2]
      Output: 0
     */

      //Binary Search
    public int FindMin(int[] nums)
    {
      int low = 0;
      int high = nums.Length - 1;
      while (low < high)
      {
        int mid = (low + high) / 2;
        if (nums[high] < nums[mid])
        {
          low = mid + 1;
        }
        else
        {
          high = mid;
        }
      }
      return nums[high];
    }

    public int FindMinSimple(int[] nums)
    {
      if (nums.Length == 0)
      {
        return 0;
      }
      for (var i = 0; i < nums.Length - 1; i++)
      {
        if (nums[i] > nums[i + 1])
        {
          return nums[i + 1];
        }
      }
      return nums[0];
    }

    [Fact]
    public void CanFindMin()
    {
      Assert.Equal(1, FindMin(AsArray(3, 4, 5, 1, 2)));
    }
  }
}
