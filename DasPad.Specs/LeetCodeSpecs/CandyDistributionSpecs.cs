using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class CandyDistributionSpecs
  {
    public int DistributeCandies(int[] candies)
    {
      var kinds = new HashSet<int>();
      foreach (int candy in candies)
      {
        kinds.Add(candy);
      }
      return kinds.Count() >= candies.Count() / 2 ? candies.Length / 2 : kinds.Count();
    }

    [Fact]
    public void CanDistributeCandies()
    {
      int[] input = new[] { 0, 0, 14, 0, 10, 0, 0, 0 };
      var expected = 3;
      Assert.Equal(expected, DistributeCandies(input));
    }
  }
}
