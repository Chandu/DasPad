using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.OthersSpecs
{
  public class MajorityElementSpecs
  {
    /*
     * https://leetcode.com/problems/majority-element-ii/
     * Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.

        Note: The algorithm should run in linear time and in O(1) space.

        Example 1:

        Input: [3,2,3]
        Output: [3]
        Example 2:

        Input: [1,1,1,3,3,2,2,2]
        Output: [1,2]
     */

    //Trick:

    public IList<int> MajorityElementII(int[] nums)
    {
      if (nums.Length == 1)
      {
        return nums;
      }
      var firstSeen = int.MaxValue;
      var secondSeen = int.MaxValue;
      var firstCount = 0;
      var secondCount = 0;
      for (var i = 0; i < nums.Length; i++)
      {
        if (firstSeen == nums[i])
        {
          firstCount++;
        }
        else if (secondSeen == nums[i])
        {
          secondCount++;
        }
        else if (firstCount == 0)
        {
          firstCount++;
          firstSeen = nums[i];
        }
        else if (secondCount == 0)
        {
          secondCount++;
          secondSeen = nums[i];
        }
        else
        {
          firstCount--;
          secondCount--;
        }
      }

      firstCount = 0;
      secondCount = 0;
      for (int i = 0; i < nums.Length; i++)
      {
        if (nums[i] == firstSeen)
          firstCount++;
        else if (nums[i] == secondSeen)
          secondCount++;
      }

      /*
      if (firstCount > nums.Length / 3)
          return firstSeen;

      if (secondCount > nums.Length / 3)
          return secondSeen;

      */
      var toReturn = new List<int>();
      if (firstSeen != int.MaxValue && firstCount > nums.Length / 3)
      {
        toReturn.Add(firstSeen);
      }
      if (secondSeen != int.MaxValue & secondCount > nums.Length / 3)
      {
        toReturn.Add(secondSeen);
      }
      return toReturn.ToArray();
    }

    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/114/others/824/
     * Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.

      You may assume that the array is non-empty and the majority element always exist in the array.

      Example 1:

      Input: [3,2,3]
      Output: 3
      Example 2:

      Input: [2,2,1,1,1,2,2]
      Output: 2
     */

    public int MajorityElement(int[] nums)
    {
      var cache = new Dictionary<int, int>();
      for (var i = 0; i < nums.Length; i++)
      {
        if (!cache.ContainsKey(nums[i]))
        {
          cache[nums[i]] = 0;
        }
        cache[nums[i]]++;
      }
      return cache.OrderByDescending(a => a.Value).Select(a => a.Key).First();
    }

    // Using Sorting
    public int UsingSort(int[] nums)
    {
      Array.Sort(nums);
      return nums[nums.Length / 2];
    }

    // Using Boyre Moore Voting Algo
    // Traverse the array and keeing the first element as major and count +1 for same element found and count -1 for different during traversal
    // if count is 0 consider the next element as major and continue traversal
    //Tip: Interesting approach.
    //Revisit:
    public int MajorityElementBoyreMoore(int[] nums)
    {
      int count = 1;
      int majorElement = nums[0];
      int halfLength = nums.Length >> 1; // shifting right by 1 bit means divide by 2;
      for (int i = 1; count <= halfLength && i < nums.Length; i++)
      {
        if (count == 0)
        {
          majorElement = nums[i];
        }
        count += majorElement == nums[i] ? 1 : -1;
      }
      return majorElement;
    }

    // get the bit which is set most traversing from LSB(least significiant bit) to RSB
    // because if element is present more than half of the length its bit will be in most set bit either 1 or 0
    //Tip: Interesting approach.
    public int MajorityElementUsingBitManipul(int[] nums)
    {
      int numberOfBits = 32; // as integer has 4 bytes i.e.32 bits
      int number = 0;
      for (int i = 0; i < numberOfBits; i++)
      {
        int count = 0;
        for (int j = 0; j < nums.Length; j++)
        {
          if ((nums[j] & 1 << i) != 0)
          {
            count++;
          }
        }
        if (count > nums.Length / 2)
        {
          number += (1 << i);
        }
      }
      return number;
    }

    [Theory]
    [InlineData(3, 3, 2, 3)]
    public void CanMajorityElement(int expected, params int[] nums)
    {
      Assert.Equal(expected, MajorityElement(nums));
    }
  }
}
