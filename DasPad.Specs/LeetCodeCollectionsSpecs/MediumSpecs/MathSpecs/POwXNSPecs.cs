using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.MathSpecs
{
  public class PowXNSPecs
  {
    /*
     * Implement pow(x, n), which calculates x raised to the power n (xn).

        Example 1:

        Input: 2.00000, 10
        Output: 1024.00000
        Example 2:

        Input: 2.10000, 3
        Output: 9.26100
        Example 3:

        Input: 2.00000, -2
        Output: 0.25000
        Explanation: 2-2 = 1/22 = 1/4 = 0.25
        Note:

        -100.0 < x < 100.0
        n is a 32-bit signed integer, within the range [−231, 231 − 1]
     */

    //Trick:
    public double MyPow(double x, int n)
    {
      if (n == 0)
      {
        return 1;
      }

      var temp = MyPow(x, n / 2);

      if (n % 2 == 0)
      {
        return temp * temp;
      }
      else
      {
        if (n > 0)
        {
          return x * temp * temp;
        }
        else
        {
          return (temp * temp) / x;
        }
      }
    }

    [Theory]
    [InlineData(2.00000, 10, 1024.00000)]
    [InlineData(2.00000, -2, 0.25)]
    [InlineData(0.00001, 2147483647, 0)]
    public void CanMyPow(double x, int n, double expected)
    {
      Assert.Equal(expected, MyPow(x, n));
    }
  }
}
