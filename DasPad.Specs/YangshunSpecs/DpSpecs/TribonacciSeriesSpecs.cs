using Xunit;

namespace DasPad.Specs.YangshunSpecs.DpSpecs
{
  public class TribonacciSeriesSpecs
  {
    //TODO: (CV) https://leetcode.com/problems/n-th-tribonacci-number/
    /*
     *
     The Tribonacci sequence Tn is defined as follows:

      T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.

      Given n, return the value of Tn.

      Example 1:

      Input: n = 4
      Output: 4
      Explanation:
      T_3 = 0 + 1 + 1 = 2
      T_4 = 1 + 1 + 2 = 4
      Example 2:

      Input: n = 25
      Output: 1389537
     */

    public int Tribonacci(int n)
    {
      var memo = new int[n + 1];
      for (var i = 0; i <= n; i++)
      {
        if (i == 0)
        {
          memo[i] = 0;
        }
        else if (i <= 2)
        {
          memo[i] = 1;
        }
        else
        {
          memo[i] = -1;
        }
      }
      return TribonacciHelper(n , memo);
    }

    public int TribonacciHelper(int n, int[] memo)
    {
      if (n < 0)
      {
        return 0;
      }
      if (memo[n] == -1)
      {
        memo[n] = TribonacciHelper(n - 1, memo) + TribonacciHelper(n - 2, memo) + TribonacciHelper(n - 3, memo);
      }
      return memo[n];
    }

    [Theory]
    [InlineData(4, 4)]
    [InlineData(25, 1389537)]
    [InlineData(33, 181997601)]
    public void CanTribonacci(int input, int expected)
    {
      Assert.Equal(expected, Tribonacci(input));
    }
  }
}
