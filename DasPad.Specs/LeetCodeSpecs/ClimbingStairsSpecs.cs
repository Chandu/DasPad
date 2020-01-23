using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class ClimbingStairsSpecs
  {
    public Dictionary<int, int> StepsMemo = new Dictionary<int, int>();

    public int ClimbStairs(int n)
    {
      if (n <= 1)
      {
        return n;
      }
      if (n == 2)
      {
        return 2;
      }
      else
      {
        if (StepsMemo.ContainsKey(n))
        {
          return StepsMemo[n];
        }
        else
        {
          return StepsMemo[n] = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }
      }
    }

    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(44, 1134903170)]
    public void CanClimbStairs(int n, int expected)
    {
      Assert.Equal(expected, ClimbStairs(n));
    }
  }
}
