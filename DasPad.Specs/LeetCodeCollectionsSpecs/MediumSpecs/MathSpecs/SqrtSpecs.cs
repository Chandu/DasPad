using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.MathSpecs
{
  public class SqrtSpecs
  {
    /*
     *https://leetcode.com/explore/interview/card/top-interview-questions-medium/113/math/819/
     * Implement int sqrt(int x).

      Compute and return the square root of x, where x is guaranteed to be a non-negative integer.

      Since the return type is an integer, the decimal digits are truncated and only the integer part of the result is returned.

      Example 1:

      Input: 4
      Output: 2
      Example 2:

      Input: 8
      Output: 2
      Explanation: The square root of 8 is 2.82842..., and since
                   the decimal part is truncated, 2 is returned.
     */

    public int MySqrt(int x)
    {
      int i = 1;
      int j = x;
      int ans = 0;
      while (i <= j)
      {
        int mid = i + (j - i) / 2;
        if (mid <= x / mid)
        {
          i = mid + 1;
          ans = mid;
        }
        else
          j = mid - 1;
      }

      return ans;
    }

    [Theory]
    [InlineData(4, 2)]
    public void CanMySqrt(int x, int expected)
    {
      Assert.Equal(expected, MySqrt(x));
    }
  }
}
