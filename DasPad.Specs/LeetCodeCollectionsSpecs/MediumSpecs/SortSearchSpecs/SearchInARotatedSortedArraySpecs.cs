using DasPad.Specs.Extensions;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.SortSearchSpecs
{
  public class SearchInARotatedSortedArraySpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/804/
     * Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

        (i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

        You are given a target value to search. If found in the array return its index, otherwise return -1.

        You may assume no duplicate exists in the array.

        Your algorithm's runtime complexity must be in the order of O(log n).

        Example 1:

        Input: nums = [4,5,6,7,0,1,2], target = 0
        Output: 4
        Example 2:

        Input: nums = [4,5,6,7,0,1,2], target = 3
        Output: -1
     */

    public int Search(int[] nums, int target)
    {
      return SearchUsingBinarySearch(nums, target);
    }

    //Note:
    /*
     * the main idea is that we need to find some parts of array that we could adopt binary search on that, which means we need to find some completed sorted parts, then determine whether target is in left part or right part. There is at least one segment (left part or right part) is monotonically increasing.

      If the entire left part is monotonically increasing, which means the pivot point is on the right part
      If left <= target < mid ------> drop the right half
      Else ------> drop the left half
      If the entire right part is monotonically increasing, which means the pivot point is on the left part
      If mid < target <= right ------> drop the left half
      Else ------> drop the right half
     */

    //Tip: Anytime there is a mention of rotation of a sorted array, look for monotnic increating side of the split array
    public int SearchUsingBinarySearch(int[] nums, int target)
    {
      var start = 0;
      var end = nums.Length - 1;
      while (start <= end)
      {
        var mid = start + (end - start) / 2;
        if (nums[mid] == target)
        {
          return mid;
        }
        else
        {
          if (nums[start] <= nums[mid])
          {
            //This means the left is monotonically increasing.
            if (nums[start] <= target && target < nums[mid])
            {
              end = mid - 1;
            }
            else
            {
              start = mid + 1;
            }
          }
          else
          {
            //This means the right is monotonically increasing.
            if (nums[mid] < target && target <= nums[end])
            {
              start = mid + 1;
            }
            else
            {
              end = mid - 1;
            }
          }
        }
      }
      return -1;
    }

    [Theory]
    [InlineData("4,5,6,7,0,1,2", 0, 4)]
    public void CanSearch(string nums, int target, int expected)
    {
      Assert.Equal(expected, Search(nums.AsIntsFromCsv(), target));
    }
  }
}
