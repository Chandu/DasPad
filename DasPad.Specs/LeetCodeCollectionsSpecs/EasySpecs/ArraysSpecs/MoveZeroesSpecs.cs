using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.ArraysSpecs
{
  public class MoveZeroesSpecs
  {
    /*
     * Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

      Example:

      Input: [0,1,0,3,12]
      Output: [1,3,12,0,0]
      Note:

      You must do this in-place without making a copy of the array.
      Minimize the total number of operations.
     */

    public void MoveZeroes(int[] nums)
    {
      if (nums.Length < 1)
      {
        return;
      }

      var prevZeroIndex = -1;
      var second = 0;
      while (second < nums.Length)
      {
        if (nums[second] == 0)
        {
          if (prevZeroIndex == -1)
          {
            prevZeroIndex = second;
          }
        }
        else
        {
          if (prevZeroIndex != -1)
          {
            nums[prevZeroIndex] = nums[second];
            nums[second] = 0;
            prevZeroIndex++;
          }
        }
        second++;
      }
    }

    [Fact]
    public void CanMoveZeroes()
    {
      var input = AsArray(0, 1, 0, 3, 12);
      MoveZeroes(input);
      Assert.Equal(AsArray(1, 3, 12, 0, 0), input);
    }
  }
}
