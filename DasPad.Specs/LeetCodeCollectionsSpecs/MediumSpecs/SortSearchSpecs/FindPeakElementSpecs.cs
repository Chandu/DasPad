using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.SortSearchSpecs
{
  public class FindPeakElementSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/801/
     * A peak element is an element that is greater than its neighbors.

      Given an input array nums, where nums[i] ≠ nums[i+1], find a peak element and return its index.

      The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.

      You may imagine that nums[-1] = nums[n] = -∞.

      Example 1:

      Input: nums = [1,2,3,1]
      Output: 2
      Explanation: 3 is a peak element and your function should return the index number 2.
      Example 2:

      Input: nums = [1,2,1,3,5,6,4]
      Output: 1 or 5
      Explanation: Your function can return either index number 1 where the peak element is 2,
                   or index number 5 where the peak element is 6.
      Note:

      Your solution should be in logarithmic complexity.
     */
    //Notes:
    /*
     * From Leet Code Discussion point: https://leetcode.com/problems/find-peak-element/discuss/50232/Find-the-maximum-by-binary-search-(recursion-and-iteration)
     * Most people have figured out the binary search solution but are not able to understand how its working. I will try to explain it simply. What we are essentially doing is going in the direction of the rising slope(by choosing the element which is greater than current). How does that guarantee the result? Think about it, there are 2 possibilities.a) rising slope has to keep rising till end of the array b) rising slope will encounter a lesser element and go down.
      In both scenarios we will have an answer. In a) the answer is the end element because we take the boundary as -INFINITY b) the answer is the largest element before the slope falls. Hope this makes things clearer.
     */

    public int FindPeakElement(int[] nums)
    {
      var start = 0;
      var end = nums.Length - 1;
      while (start < end)
      {
        int mid1 = (start + end) / 2;
        int mid2 = mid1 + 1;
        if (nums[mid1] < nums[mid2])
        {
          start = mid2;
        }
        else
        {
          end = mid1;
        }
      }
      return start;
    }

    [Theory]
    [InlineData(2, 1, 2, 3, 1)]
    public void CanFindPeakElement(int expected, params int[] nums)
    {
      Assert.Equal(expected, FindPeakElement(nums));
    }
  }
}
