using System;
using Xunit;

namespace DasPad.Specs.YangshunSpecs.ArraysSpecs
{
    public class BuySellStockSpecs
    {
        public T[] AsArray<T>(params T[] parameters) => parameters;

        public int MaxProfit(int[] prices)
        {
            var maxProfit = 0;
            if (prices.Length < 2)
            {
                return 0;
            }
            else if (prices.Length == 2)
            {
                return Math.Max(0, prices[1] - prices[0]);
            }
            int minPrice = Int32.MaxValue;
            for (var i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
                else if (prices[i] - minPrice > maxProfit)
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
            Assert.Equal(3, MaxProfit(AsArray(1, 1, 1, 1, 1, 4)));
        }
    }
}