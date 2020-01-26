using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.MathSpecs
{
  public class FractionToRecurringDecimalSpecs
  {
    /*
     *  Fraction to Recurring Decimal
        Solution
        Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.

        If the fractional part is repeating, enclose the repeating part in parentheses.

        Example 1:

        Input: numerator = 1, denominator = 2
        Output: "0.5"
        Example 2:

        Input: numerator = 2, denominator = 1
        Output: "2"
        Example 3:

        Input: numerator = 2, denominator = 3
        Output: "0.(6)"
     */

    public string FractionToDecimal(int numerator, int denominator)
    {
      var result = new StringBuilder();
      string sign = (numerator < 0 == denominator < 0 || numerator == 0) ? "" : "-";
      long num = Math.Abs((long)numerator);
      long den = Math.Abs((long)denominator);
      result.Append(sign);
      result.Append(num / den);
      long remainder = num % den;
      if (remainder == 0)
      {
        return result.ToString();
      }

      result.Append(".");
      //Tip:
      //Notice that once the remainder starts repeating, so does the divided result.
      var hashMap = new Dictionary<long, int>();
      while (!hashMap.ContainsKey(remainder))
      {
        hashMap[remainder] = result.Length;
        result.Append(10 * remainder / den);
        remainder = 10 * remainder % den;
      }
      int index = hashMap[remainder];
      result.Insert(index, "(");
      result.Append(")");
      return result.ToString().Replace("(0)", "");
    }

    [Theory]
    [InlineData(1, 2, "0.5")]
    [InlineData(2, 3, "0.(6)")]
    [InlineData(4, 333, "0.(012)")]
    public void CanFractionToDecimal(int numerator, int denominator, string expected)
    {
      Assert.Equal(expected, FractionToDecimal(numerator, denominator));
    }
  }
}
