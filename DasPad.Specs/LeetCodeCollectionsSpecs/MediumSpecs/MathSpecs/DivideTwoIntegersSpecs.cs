using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.MathSpecs
{
  public class DivideTwoIntegersSpecs
  {
    /*
     * Given two integers dividend and divisor, divide two integers without using multiplication, division and mod operator.

      Return the quotient after dividing dividend by divisor.

      The integer division should truncate toward zero.

      Example 1:

      Input: dividend = 10, divisor = 3
      Output: 3
      Example 2:

      Input: dividend = 7, divisor = -3
      Output: -2
      Note:

      Both dividend and divisor will be 32-bit signed integers.
      The divisor will never be 0.
      Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. For the purpose of this problem, assume that your function returns 231 − 1 when the division result overflows.
     */

    public int Divide(int dividend, int divisor)
    {
      if (dividend == Int32.MinValue && divisor == -1)
      {
        return Int32.MaxValue;
      }

      if (divisor == 0)
      {
        throw new Exception("Invalid Input! 0 is not allowed as divisor");
      }

      if (dividend == 0)
      {
        return 0;
      }

      bool neg = (dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0);

      if (dividend > 0)
      {
        dividend = -dividend;
      }
      if (divisor > 0)
      {
        divisor = -divisor;
      }

      return neg ? -DivideTwoNegs(dividend, divisor) : DivideTwoNegs(dividend, divisor);
    }

    private int DivideTwoNegs(int dividend, int divisor)
    {
      if (dividend > divisor)
      {
        return 0;
      }
      if (dividend == divisor)
      {
        return 1;
      }

      int times = 1;
      while (divisor << times < 0 && divisor << times > dividend)
      {
        times++;
      }

      return (1 << (times - 1)) + DivideTwoNegs(dividend - (divisor << (times - 1)), divisor);
    }

    [Theory]
    [InlineData(10, 3, 3)]
    [InlineData(7, -3, -2)]
    [InlineData(-7, -3, 2)]
    [InlineData(-7, 3, -2)]
    public void CanDivide(int dividend, int divisor, int result)
    {
      Assert.Equal(result, Divide(dividend, divisor));
    }

    [Fact]
    public void CanDivideOverflow()
    {
      Assert.Equal(int.MaxValue, Divide(int.MinValue, -1));
    }
  }
}
