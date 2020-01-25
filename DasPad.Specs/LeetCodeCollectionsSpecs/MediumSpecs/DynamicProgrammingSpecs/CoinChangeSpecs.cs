using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.DynamicProgrammingSpecs
{
  public class CoinChangeSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/111/dynamic-programming/809/
     * Coin Change
    Solution
    You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.

    Example 1:

    Input: coins = [1, 2, 5], amount = 11
    Output: 3
    Explanation: 11 = 5 + 5 + 1
    Example 2:

    Input: coins = [2], amount = 3
    Output: -1
    Note:
    You may assume that you have an infinite number of each kind of coin.
     */
    /*
     *
     */

    //Note: My intuitive approach was to sort teh array based on the coin value and then use DFS picking coins with higher values as that would definitly yield min number of coins.
    //Wanted to try the DP on my own, but failed miserably :(
    public int CoinChange(int[] coins, int amount)
    {
      //return CoinChangeBruteForce(coins, amount, 0);
      return CoinChangeDpBottomUp(coins, amount);
    }

    //Revisit:
    public int CoinChangeDpBottomUp(int[] coins, int amount)
    {
      int[] dp = new int[amount + 1];

      for (int i = 0; i < dp.Length; i++)
      {
        //Note: Could have used Max value but it might cause int overflow, hence using amout + 1
        dp[i] = amount + 1;// int.MaxValue;
      }
      dp[0] = 0;
      for (int i = 1; i <= amount; i++)
      {
        for (int j = 0; j < coins.Length; j++)
        {
          //The Sub Problem could be stated as
          /*
           * For making Amount Si = Min of (Coins required to make Amount (Si - Coin value at index a) + 1)
           * */
          if (coins[j] <= i)
            dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
        }
      }

      return (dp[amount] == amount + 1) ? -1 : dp[amount];
    }

    //Revisit:
    public int CoinChangeBruteForce(int[] coins, int amount, int coinIndex)
    {
      if (amount == 0)
      {
        return 0;
      }

      if (coinIndex < coins.Length && amount > 0)
      {
        int maxVal = amount / coins[coinIndex];
        int minCost = int.MaxValue;
        for (int x = 0; x <= maxVal; x++)
        {
          if (amount >= x * coins[coinIndex])
          {
            int res = CoinChangeBruteForce(coins, amount - x * coins[coinIndex], coinIndex + 1);
            if (res != -1)
            {
              minCost = Math.Min(minCost, res + x);
            }
          }
        }
        return (minCost == int.MaxValue) ? -1 : minCost;
      }
      return -1;
    }

    //public int CoinChangeBackTrackDpBottomUp(int[] coins, int amount)
    //{
    //  var dp = new int[amount];
    //  dp[0] = 0;
    //  return dp[amount];
    //}

    [Theory]
    [InlineData(3, 11, 1, 2, 5)]
    public void CanCoinChange(int expected, int amount, params int[] coins)
    {
      Assert.Equal(expected, CoinChange(coins, amount));
    }
  }
}
