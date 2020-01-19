using Xunit;

namespace DasPad.Specs.YangshunSpecs.DpSpecs
{
  public class ClimbingStairsSpecs
  {
    //TODO: (CV) https://leetcode.com/problems/climbing-stairs/
    /*
     *
        You are climbing a stair case. It takes n steps to reach to the top.

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

      Answer
      ~~~~~~~~~~~~
      Number of ways to reach ith step = NumWays(i-1) + NumWays(i-2)
     */

    public int ClimbStairs(int n)
    {
      var memo = new int[n];
      for (var i = 0; i < n; i++)
      {
        if (i <= 2)
        {
          memo[i] = i + 1;
        }
        else
        {
          memo[i] = -1;
        }
        
      }

      return ClimbStairsHelper(n - 1, memo);
    }

    public int ClimbStairsHelper(int n, int[] memo)
    {
      if (n < 0)
      {
        return 0;
      }
      if (memo[n] == -1)
      {
        memo[n] = ClimbStairsHelper(n - 1, memo) + ClimbStairsHelper(n - 2, memo);
      }
      
      return memo[n];
    }

    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(44, 1134903170)]
    public void CanClimbStairs(int input, int expected)
    {
      Assert.Equal(expected, ClimbStairs(input));
    }
  }
}
