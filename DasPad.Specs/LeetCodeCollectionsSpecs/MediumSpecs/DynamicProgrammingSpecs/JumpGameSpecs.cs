using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.DynamicProgrammingSpecs
{
  public class JumpGameSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/111/dynamic-programming/807/
     * Given an array of non-negative integers, you are initially positioned at the first index of the array.

      Each element in the array represents your maximum jump length at that position.

      Determine if you are able to reach the last index.

      Example 1:

      Input: [2,3,1,1,4]
      Output: true
      Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
      Example 2:

      Input: [3,2,1,0,4]
      Output: false
      Explanation: You will always arrive at index 3 no matter what. Its maximum
                   jump length is 0, which makes it impossible to reach the last index.
     */

    //Note: YAY!!! First attempt worked for DP.
    public bool CanJump(int[] nums)
    {
      //return CanJumpBacktrackingHelper(nums, 0);
      return CanJumpDp(nums);
    }

    public bool CanJumpDp(int[] nums)
    {
      var dp = new int[nums.Length];
      dp[0] = 1;
      return CanJumpDpHelper(nums, nums.Length - 1, dp);
    }

    public bool CanJumpDpHelper(int[] nums, int index, int[] dp)
    {
      if (index < 0)
      {
        return false;
      }
      else
      {
        if (dp[index] == 0)
        {
          dp[index] = 2;
          for (var i = index - 1; i >= 0; i--)
          {
            var result = CanJumpDpHelper(nums, i, dp) && (nums[i] >= (index - i));
            if (result)
            {
              dp[index] = 1;
              break;
            }
          }
        }
        return dp[index] == 1;
      }
    }

    //TODO: What is the Time Complexity for this?
    private bool CanJumpBacktrackingHelper(int[] nums, int index)
    {
      if (index >= nums.Length)
      {
        return false;
      }
      else
      {
        if (index == nums.Length - 1)
        {
          return true;
        }
        else
        {
          for (var i = 1; i <= nums[index]; i++)
          {
            var result = CanJumpBacktrackingHelper(nums, index + i);
            if (result)
            {
              return true;
            }
          }
        }
        return false;
      }
    }

    [Theory]
    [InlineData(true, 2, 3, 1, 1, 4)]
    [InlineData(false, 3, 2, 1, 0, 4)]
    public void CanVerifyCanJump(bool expected, params int[] input)
    {
      Assert.Equal(expected, CanJump(input));
    }
  }
}
