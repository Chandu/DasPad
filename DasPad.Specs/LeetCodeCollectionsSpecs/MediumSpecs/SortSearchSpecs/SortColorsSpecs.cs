using DasPad.Specs.Extensions;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.SortSearchSpecs
{
  public class SortColorsSpecs
  {
    /*
     *https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/798/
     * Given an array with n objects colored red, white or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white and blue.

      Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

      Note: You are not suppose to use the library's sort function for this problem.

      Example:

      Input: [2,0,2,1,1,0]
      Output: [0,0,1,1,2,2]
      Follow up:

      A rather straight forward solution is a two-pass algorithm using counting sort.
      First, iterate the array counting number of 0's, 1's, and 2's, then overwrite array with total number of 0's, then 1's and followed by 2's.
      Could you come up with a one-pass algorithm using only constant space?
     */

    public void SortColors(int[] nums)
    {
      //SortColorsUsingCountSort(nums);
      SortColorsWithOnePass(nums);
    }

    //Revisit
    //https://leetcode.com/problems/sort-colors/discuss/26481/Python-O(n)-1-pass-in-place-solution-with-explanation
    public void SortColorsWithOnePass(int[] nums)
    {
      var zeroIndex = 0;
      var oneIndex = 0;
      var twoIndex = nums.Length - 1;
      while (oneIndex <= twoIndex)
      {
        if (nums[oneIndex] == 0)
        {
          var temp = nums[oneIndex];
          nums[oneIndex] = nums[zeroIndex];
          nums[zeroIndex] = temp;
          zeroIndex++;
          oneIndex++;
        }
        else if (nums[oneIndex] == 1)
        {
          oneIndex++;
        }
        else
        {
          var temp = nums[oneIndex];
          nums[oneIndex] = nums[twoIndex];
          nums[twoIndex] = temp;
          twoIndex--;
        }
      }
    }

    public void SortColorsUsingCountSort(int[] nums)
    {
      var zerosCount = 0;
      var onesCount = 0;
      foreach (var i in nums)
      {
        if (i == 0)
        {
          zerosCount++;
        }
        else if (i == 1)
        {
          onesCount++;
        }
      }
      for (var i = 0; i < nums.Length; i++)
      {
        if (zerosCount > 0)
        {
          nums[i] = 0;
          zerosCount--;
        }
        else if (onesCount > 0)
        {
          nums[i] = 1;
          onesCount--;
        }
        else
        {
          nums[i] = 2;
        }
      }
    }

    [Theory]
    [InlineData("2,0,2,1,1,0", "0,0,1,1,2,2")]
    [InlineData("2,0,1", "0,1,2")]
    public void CanSortColors(string input, string output)
    {
      var inputArray = input.AsIntsFromCsv();
      SortColors(inputArray);
      Assert.Equal(output.AsIntsFromCsv(), inputArray);
    }
  }
}
