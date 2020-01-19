using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.YangshunSpecs.DpSpecs
{
  public class TargetSumSpecs
  {
    //TODO: (CV) https://leetcode.com/problems/target-sum/
    /*
     * You are given a list of non-negative integers, a1, a2, ..., an, and a target, S. Now you have 2 symbols + and -. For each integer, you should choose one from + and - as its new symbol.

      Find out how many ways to assign symbols to make sum of integers equal to target S.

      Example 1:
      Input: nums is [1, 1, 1, 1, 1], S is 3.
      Output: 5
      Explanation:

      -1+1+1+1+1 = 3
      +1-1+1+1+1 = 3
      +1+1-1+1+1 = 3
      +1+1+1-1+1 = 3
      +1+1+1+1-1 = 3

      There are 5 ways to assign symbols to make the sum of nums be target 3.
      Note:
      The length of the given array is positive and will not exceed 20.
      The sum of elements in the given array will not exceed 1000.
      Your output answer is guaranteed to be fitted in a 32-bit integer.
     */

    public int FindTargetSumWays(int[] nums, int S)
    {
      return FindTargetSumWaysHelper(nums, S, 0, 0);
    }

    public int FindTargetSumWaysHelper(int[] nums, int S, int curSum, int i)
    {
      if (i == nums.Length)
      {
        if (S == curSum)
        {
          return 1;
        }
        else
        {
          return 0;
        }
      }
      else
      {
        var val = nums[i];
        return FindTargetSumWaysHelper(nums, S, curSum + val, i + 1) + FindTargetSumWaysHelper(nums, S, curSum - val, i + 1);
      }
    }

    [Fact(Timeout = 1)]
    public void CanFindTargetSumWays()
    {
      Assert.Equal(5, FindTargetSumWays(AsArray(1, 1, 1, 1, 1), 3));
    }
  }
}
