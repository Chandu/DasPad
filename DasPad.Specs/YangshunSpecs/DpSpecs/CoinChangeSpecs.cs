using System;
using System.Collections.Generic;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.YangshunSpecs.DpSpecs
{
  public class CoinChangeSpecs
  {
    //TODO: (CV) https://leetcode.com/problems/coin-change/
    /*
     *
     * You are given coins of different denominations and a total amount of money amount. Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.
     * Example 1:

      Input: coins = [1, 2, 5], amount = 11
      Output: 3
      Explanation: 11 = 5 + 5 + 1
      Example 2:

      Input: coins = [2], amount = 3
      Output: -1
      Note:
      You may assume that you have an infinite number of each kind of coin.
     *
     *
     */
    //TODO: (CV) - Important - Backtracking and Recursion with Minimization and Dynamic Programming.

    public int CoinChange(int[] coins, int amount)
    {
      if (amount <= 0)
      {
        return 0;
      }
      Array.Sort(coins);
      var amountMap = new Dictionary<int, int>();
      return CoinChangeHelper(coins, amount, amountMap);
    }

    private int CoinChangeHelper(int[] coins, int amount, Dictionary<int, int> amountMap)
    {
      if (amount == 0)
      {
        return 0;
        //return coinsMap.Select(a => a.Value).Sum();
      }
      if (amount < 0)
      {
        return -1;
      }
      if (amountMap.ContainsKey(amount) && amountMap[amount] != 0)
      {
        return amountMap[amount];
      }
      else
      {
        int min = Int32.MaxValue;
        foreach (var coin in coins)
        {
          var result = CoinChangeHelper(coins, amount - coin, amountMap);
          if (result >= 0 && result < min)
          {
            min = 1 + result;
          }
        }
        amountMap[amount] = (min == Int32.MaxValue) ? -1 : min;
        return amountMap[amount];
      }
    }

    //public int CoinChange(int[] coins, int amount)
    //{
    //  if(amount <=0)
    //  {
    //    return 0;
    //  }
    //  Array.Sort(coins);
    //  var coinsMap = new Dictionary<int, int>();
    //  return CoinChangeHelper(coins, amount, coins.Length - 1, coinsMap);
    //}

    private Dictionary<int, int> BuildCoinsMap(Dictionary<int, int> coinsMap, int coin)
    {
      var newDict = new Dictionary<int, int>();
      foreach (var kv in coinsMap)
      {
        newDict[kv.Key] = kv.Value;
      }
      if (!newDict.ContainsKey(coin))
      {
        newDict[coin] = 0;
      }
      newDict[coin]++;
      return newDict;
    }

    //private int CoinChangeHelper(int[] coins, int amount, int coinIndex, Dictionary<int, int> coinsMap)
    //{
    //  if (amount == 0)
    //  {
    //    return coinsMap.Select(a => a.Value).Sum();
    //  }
    //  if (amount <= 0 || coinIndex < 0)
    //  {
    //    return -1;
    //  }
    //  else
    //  {
    //    var result = CoinChangeHelper(coins, amount - coins[coinIndex], coinIndex, BuildCoinsMap(coinsMap, coins[coinIndex]));
    //    if (result == -1)
    //    {
    //      return CoinChangeHelper(coins, amount, coinIndex - 1, coinsMap);
    //    }
    //    else
    //    {
    //      return result;
    //    }
    //  }
    //}

    [Fact]
    public void CanCoinChange()
    {
      //Assert.Equal(3, CoinChange(AsArray(1, 2, 5), 11));
      //Assert.Equal(3, CoinChange(AsArray(2, 4, 5), 11));
      //Assert.Equal(-1, CoinChange(AsArray(2), 3));
      Assert.Equal(20, CoinChange(AsArray(186, 419, 83, 408), 6249));
    }
  }
}
