using DasPad.Specs.Extensions;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.SortSearchSpecs
{
  public class SearchForARangeSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/802/
     *Given an array of integers nums sorted in ascending order, find the starting and ending position of a given target value.

      Your algorithm's runtime complexity must be in the order of O(log n).

      If the target is not found in the array, return [-1, -1].

      Example 1:

      Input: nums = [5,7,7,8,8,10], target = 8
      Output: [3,4]
      Example 2:

      Input: nums = [5,7,7,8,8,10], target = 6
      Output: [-1,-1]
     */

    public int[] SearchRange(int[] nums, int target)
    {
      int start = FirstGreaterEqual(nums, target);
      if (start == nums.Length || nums[start] != target)
      {
        return new int[] { -1, -1 };
      }
      return new int[] { start, FirstGreaterEqual(nums, target + 1) - 1 };
    }

    //find the first number that is greater than or equal to target.
    //could return A.length if target is greater than A[A.length-1].
    //actually this is the same as lower_bound in C++ STL.
    private static int FirstGreaterEqual(int[] nums, int target)
    {
      int low = 0, high = nums.Length;
      while (low < high)
      {
        int mid = low + (high - low) / 2;

        if (nums[mid] < target)
        {
          low = mid + 1;
        }
        else
        {
          //should not be mid-1 when A[mid]==target.
          //could be mid even if A[mid]>target because mid<high.
          high = mid;
        }
      }
      return low;
    }

    [Theory]
    [InlineData("5,7,7,8,8,10", 8, "3,4")]
    public void CanSearchRange(string nums, int target, string expected)
    {
      Assert.Equal(expected.AsIntsFromCsv(), SearchRange(nums.AsIntsFromCsv(), target));
    }
  }
}
