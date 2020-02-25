using System;
using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class DivideNumberSpecs
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
      var remainder = Math.Abs(dividend);
      var sign = 1;
      if ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0))
      {
        sign = -1;
      }
      if (remainder == Math.Abs(divisor))
      {
        return sign * 1;
      }
      var quotient = 0;
      while (remainder > Math.Abs(divisor))
      {
        remainder = remainder - Math.Abs(divisor);
        quotient++;
      }
      return quotient * sign;
    }

    [Theory]
    [InlineData(3, 10, 3)]
    [InlineData(-2, 7, -3)]
    public void CanDivide(int expected, int dividend, int divisor)
    {
      Assert.Equal(expected, Divide(dividend, divisor));
    }
  }
}
