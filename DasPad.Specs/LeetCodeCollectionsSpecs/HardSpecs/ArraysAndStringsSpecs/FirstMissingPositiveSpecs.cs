using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class FirstMissingPositiveSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-hard/116/array-and-strings/832/
     * Given an unsorted integer array, find the smallest missing positive integer.

      Example 1:

      Input: [1,2,0]
      Output: 3
      Example 2:

      Input: [3,4,-1,1]
      Output: 2
      Example 3:

      Input: [7,8,9,11,12]
      Output: 1
      Note:

      Your algorithm should run in O(n) time and uses constant extra space.
     */

    public int FirstMissingPositive(int[] nums)
    {
      if (nums.Length < 1)
      {
        return 1;
      }
      return FirstMissingConstantSpace(nums);
    }

    //Tip: Beautiful Solution
    //Tip: Whenever constant space is suggested then look at utilizing the input array as storage
    public int FirstMissingConstantSpace(int[] nums)
    {
      //Note:
      //The logic is to iterate through the array and for each entry k move it to the array[k] position if it exists.
      //Once the abvoe is done, the first entry where the nums[i] !=  i+1 is the answer.
      for (var i = 0; i < nums.Length; i++)
      {
        if (nums[i] > 0 && nums[i] < nums.Length && nums[nums[i] - 1] != nums[i])
        {
          var temp = nums[i];
          nums[i] = nums[nums[i]];
          nums[nums[i]] = temp;
        }
      }

      for (var i = 0; i < nums.Length; i++)
      {
        if (nums[i] != i + 1)
        {
          return i + 1;
        }
      }
      return nums.Length + 1;
    }

    public int FirstMissingBruteForce(int[] nums)
    {
      var sortedSet = new SortedSet<int>();
      for (var i = 0; i < nums.Length; i++)
      {
        if (nums[i] >= 1)
        {
          sortedSet.Add(nums[i]);
        }
      }
      if (sortedSet.Count() == 0)
      {
        return -1;
      }
      var max = sortedSet.Max();
      for (var i = 1; i < max; i++)
      {
        if (!sortedSet.Contains(i))
        {
          return i;
        }
      }
      return max + 1;
    }

    [Theory]
    [InlineData(3, 1, 2, 0)]
    public void CanFirstMissingPositive(int expected, params int[] nums)
    {
      Assert.Equal(expected, FirstMissingPositive(nums));
    }
  }
}
