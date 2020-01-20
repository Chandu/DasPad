using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class GoodNumberSpecs
  {
    /*
     * X is a good number if after rotating each digit individually by 180 degrees, we get a valid number that is different from X.  Each digit must be rotated - we cannot choose to leave it alone.

      A number is valid if each digit remains a digit after rotation. 0, 1, and 8 rotate to themselves; 2 and 5 rotate to each other; 6 and 9 rotate to each other, and the rest of the numbers do not rotate to any other number and become invalid.

      Now given a positive number N, how many numbers X from 1 to N are good?

      Example:
      Input: 10
      Output: 4
      Explanation:
      There are four good numbers in the range [1, 10] : 2, 5, 6, 9.
      Note that 1 and 10 are not good numbers, since they remain unchanged after rotating.
      Note:

      N  will be in range [1, 10000].
     */

    public Dictionary<int, int> RotationMap = new Dictionary<int, int>()
    {
      { 0, 0},
      { 1, 1},
      { 8, 8},
      { 2, 5},
      { 5, 2},
      { 6, 9},
      { 9, 6},
    };

    public int RotatedDigits(int input)
    {
      var count = 0;
      for (var i = 1; i <= input; i++)
      {
        if (IsNumberValid(i))
        {
          count++;
        }
      }
      return count;
    }

    public bool IsNumberValid(int number)
    {
      var workedNumber = number;
      var builtNumber = 0;
      var power = 0;
      while (workedNumber != 0)
      {
        var remainder = workedNumber % 10;

        if (RotationMap.ContainsKey(remainder))
        {
          var rotated = RotationMap[remainder];
          builtNumber = (rotated * (int)Math.Pow(10, power)) + builtNumber;
          power++;
        }
        else
        {
          return false;
        }
        workedNumber /= 10;
      }
      return number != builtNumber;
    }

    [Theory]
    [InlineData(10, 4)]
    public void CanRotatedDigits(int input, int expected)
    {
      Assert.Equal(expected, RotatedDigits(input));
    }
  }
}
