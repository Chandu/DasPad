using System;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class BuySellStocksSpecs
  {
    /*
     * Say you have an array for which the ith element is the price of a given stock on day i.

      If you were only permitted to complete at most one transaction (i.e., buy one and sell one share of the stock), design an algorithm to find the maximum profit.

      Note that you cannot sell a stock before you buy one.

      Example 1:

      Input: [7,1,5,3,6,4]
      Output: 5
      Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
                   Not 7-1 = 6, as selling price needs to be larger than buying price.
      Example 2:

      Input: [7,6,4,3,1]
      Output: 0
      Explanation: In this case, no transaction is done, i.e. max profit = 0.
     */

    public int MaxProfit(int[] prices)
    {
      var maxProfit = 0;
      var minPrice = Int32.MaxValue;
      for (var i = 0; i < prices.Length; i++)
      {
        if (prices[i] < minPrice)
        {
          minPrice = prices[i];
        }
        else if (maxProfit < prices[i] - minPrice)
        {
          maxProfit = prices[i] - minPrice;
        }
      }
      return maxProfit;
    }

    [Fact]
    public void CanMaxProfit()
    {
      Assert.Equal(5, MaxProfit(AsArray(7, 1, 5, 3, 6, 4)));
      Assert.Equal(3, MaxProfit(AsArray(1, 4, 2)));
      Assert.Equal(0, MaxProfit(AsArray(4, 3, 2)));
      Assert.Equal(4, MaxProfit(AsArray(3, 2, 6, 5, 0, 3)));
    }
  }
}
