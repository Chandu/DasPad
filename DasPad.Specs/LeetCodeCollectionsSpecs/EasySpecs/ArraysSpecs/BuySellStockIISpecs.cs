using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.ArraysSpecs
{
  public class BuySellStockIISpecs
  {
    //TODO: (CV) https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/564/
    /*
     * Say you have an array for which the ith element is the price of a given stock on day i.

        Design an algorithm to find the maximum profit. You may complete as many transactions as you like (i.e., buy one and sell one share of the stock multiple times).

        Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).

        Example 1:

        Input: [7,1,5,3,6,4]
        Output: 7
        Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
                     Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
        Example 2:

        Input: [1,2,3,4,5]
        Output: 4
        Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
                     Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are
                     engaging multiple transactions at the same time. You must sell before buying again.
        Example 3:

        Input: [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transaction is done, i.e. max profit = 0.

      The key point is we need to consider every peak immediately following a valley to maximize the profit. In case we skip one of the peaks (trying to obtain more profit), we will end up losing the profit over one of the transactions leading to an overall lesser profit.
      a and b are heights of two peaks -  valleys between a and c
      a+b >= c
       public int maxProfit(int[] prices) {
        int i = 0;
        int valley = prices[0];
        int peak = prices[0];
        int maxprofit = 0;
        while (i < prices.length - 1) {
            while (i < prices.length - 1 && prices[i] >= prices[i + 1])
                i++;
            valley = prices[i];
            while (i < prices.length - 1 && prices[i] <= prices[i + 1])
                i++;
            peak = prices[i];
            maxprofit += peak - valley;
        }
        return maxprofit;
    }
     */

    //This logic uses buying and selling the share on every spike which cumulatively will yield more profit.
    public int MaxProfit(int[] prices)
    {
      int maxProfit = 0;
      for (int i = 1; i < prices.Length; i++)
      {
        if (prices[i] > prices[i - 1])
        {
          maxProfit += prices[i] - prices[i - 1];
        }
      }
      return maxProfit;
    }

    [Fact]
    public void CanMaxProfit()
    {
      Assert.Equal(7, MaxProfit(AsArray(7, 1, 5, 3, 6, 4)));
    }
  }
}
