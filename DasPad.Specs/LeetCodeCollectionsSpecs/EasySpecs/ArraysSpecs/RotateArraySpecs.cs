using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.ArraysSpecs
{
  public class RotateArraySpecs
  {
    //TODO: (CV) https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
    /*
     * Given an array, rotate the array to the right by k steps, where k is non-negative.

      Example 1:

      Input: [1,2,3,4,5,6,7] and k = 3
      Output: [5,6,7,1,2,3,4]
      Explanation:
      rotate 1 steps to the right: [7,1,2,3,4,5,6]
      rotate 2 steps to the right: [6,7,1,2,3,4,5]
      rotate 3 steps to the right: [5,6,7,1,2,3,4]
      Example 2:

      Input: [-1,-100,3,99] and k = 2
      Output: [3,99,-1,-100]
      Explanation:
      rotate 1 steps to the right: [99,-1,-100,3]
      rotate 2 steps to the right: [3,99,-1,-100]
      Note:

      Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem.
      Could you do it in-place with O(1) extra space?
     */

    public void Rotate(int[] nums, int k)
    {
      var length = nums.Length;
      if (length <= 1)
      {
        return;
      }

      if (k == length)
      {
        return;
      }

      if (k > length)
      {
        k %= length;
      }

      var spareArray = new int[k];
      for (var i = 0; i < k; i++)
      {
        spareArray[i] = nums[length - k + i];
      }

      for (var i = length - 1; i >= k; i--)
      {
        nums[i] = nums[i - k];
      }
      for (var i = 0; i < k; i++)
      {
        nums[i] = spareArray[i];
      }
    }

    [Fact]
    public void CanRotate()
    {
      var input = AsArray(1, 2, 3, 4, 5, 6, 7);
      Rotate(input, 3);
      Assert.Equal(AsArray(5, 6, 7, 1, 2, 3, 4), input);
    }
  }
}
