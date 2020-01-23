using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.ArraysAndStringsSpecs
{
  public class IncreasingTripletSubsequenceSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/781/
     * Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array.

      Formally the function should:

      Return true if there exists i, j, k
      such that arr[i] < arr[j] < arr[k] given 0 ≤ i < j < k ≤ n-1 else return false.
      Note: Your algorithm should run in O(n) time complexity and O(1) space complexity.

      Example 1:

      Input: [1,2,3,4,5]
      Output: true
      Example 2:

      Input: [5,4,3,2,1]
      Output: false
     */

    //TIP: Nice Discussion Post https://leetcode.com/problems/increasing-triplet-subsequence/discuss/79053/My-way-to-approach-such-a-problem.-How-to-think-about-it-Explanation-of-my-think-flow.
    public bool IncreasingTriplet(int[] nums)
    {
      return IncreasingTripletBruteForce(nums);
    }

    //Hint:  Start with two largest values, as soon as we find a number bigger than both, while both have been updated, return true.
    //Revisit:
    public bool IncreasingTripletLinear(int[] nums)
    {
      if (nums.Length < 3)
      {
        return false;
      }
      int small = int.MaxValue, big = int.MaxValue;
      foreach (int n in nums)
      {
        if (n <= small) // update small if n is smaller than both
        {
          small = n;
        }
        // update big only if greater than small but smaller than big
        else if (n <= big)
        {
          big = n;
        }
        // return if you find a number bigger than both
        else
        {
          return true;
        }
      }
      return false;
    }

    public bool IncreasingTripletBruteForce(int[] nums)
    {
      //O(N power 3)
      var length = nums.Length;
      for (var i = 0; i < length; i++)
      {
        for (var j = i + 1; j < length; j++)
        {
          if (nums[i] > nums[j])
          {
            continue;
          }
          for (var k = j + 1; k < length; k++)
          {
            if (nums[j] < nums[k])
            {
              return true;
            }
          }
        }
      }
      return false;
    }

    [Theory]
    [InlineData(true, 1, 2, 3, 4, 5)]
    [InlineData(false, 5, 4, 3, 2, 1)]
    public void CanCheckIfItHasIncreasingTriplet(bool expected, params int[] input)
    {
      Assert.Equal(expected, IncreasingTriplet(input));
    }
  }
}
