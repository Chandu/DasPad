using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.DynamicProgrammingSpecs
{
  public class ClimbingStairsSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-easy/97/dynamic-programming/569/
     * You are climbing a stair case. It takes n steps to reach to the top.

      Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

      Note: Given n will be a positive integer.

      Example 1:

      Input: 2
      Output: 2
      Explanation: There are two ways to climb to the top.
      1. 1 step + 1 step
      2. 2 steps
      Example 2:

      Input: 3
      Output: 3
      Explanation: There are three ways to climb to the top.
      1. 1 step + 1 step + 1 step
      2. 1 step + 2 steps
      3. 2 steps + 1 step
     */

    //TODO:(CV) TIP: Simple Bottom up without DP Table
    public int ClimbStairs(int n)
    {
      if (n == 1)
      {
        return 1;
      }
      int first = 1;
      int second = 2;
      for (int i = 3; i <= n; i++)
      {
        int third = first + second;
        first = second;
        second = third;
      }
      return second;
    }

    //TODO:(CV) TIP: Simple Bottom up with DP Table
    public int ClimbStairsBottomUp(int n)
    {
      if (n <= 1)
        return n;

      int[] dp = new int[n + 1];
      dp[0] = 1;
      dp[1] = 1;

      for (int i = 2; i <= n; i++)
      {
        dp[i] = dp[i - 1] + dp[i - 2];
      }

      return dp[n];
    }

    public int ClimbStairsRecursiveTopDown(int n)
    {
      var memo = new int[n + 1];
      for (var i = 1; i <= n; i++)
      {
        if (i < 3)
        {
          memo[i] = i;
        }
        else
        {
          memo[i] = -1;
        }
      }
      return ClimbStairsRecusriveHelper(n, memo);
    }

    public int ClimbStairsRecusriveHelper(int n, int[] memo)
    {
      if (n < 0)
      {
        return 0;
      }
      if (memo[n] != -1)
      {
        return memo[n];
      }
      else
      {
        return memo[n] = ClimbStairsRecusriveHelper(n - 1, memo) + ClimbStairsRecusriveHelper(n - 2, memo);
      }
    }

    [Theory(Timeout = 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(44, 1134903170)]
    public void CanClimbStairs(int n, int expected)
    {
      Assert.Equal(expected, ClimbStairs(n));
    }
  }
}
