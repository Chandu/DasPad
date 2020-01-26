using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.MathSpecs
{
  public class FactorialTrailingZeroesSpecs
  {
    /*
     * Given an integer n, return the number of trailing zeroes in n!.

      Example 1:

      Input: 3
      Output: 0
      Explanation: 3! = 6, no trailing zero.
      Example 2:

      Input: 5
      Output: 1
      Explanation: 5! = 120, one trailing zero.
      Note: Your solution should be in logarithmic time complexity.
     */

    //Trick:  The idea is to consider prime factors of a factorial n. A trailing zero is always produced by prime factors 2 and 5. If we can count the number of 5s and 2s, our task is done. However for every 5 in a factors exapnded factorial there is atleast a 2 so we need to just count number of 5's.
    public int TrailingZeroes(int n)
    {
      return n == 0 ? 0 : n / 5 + TrailingZeroes(n / 5);
    }

    [Theory]
    [InlineData(3, 0)]
    [InlineData(1808548329, 452137076)]
    public void CanTrailingZeroes(int n, int expected)
    {
      Assert.Equal(expected, TrailingZeroes(n));
    }
  }
}
