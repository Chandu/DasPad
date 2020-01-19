using System;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class ReverseIntegerSpecs
  {
    public int Reverse(int x)
    {
      if (x == 0)
      {
        return 0;
      }
      int toReturn = 0;
      try
      {
        for (var power = 0; x != 0; power++)
        {
          var lastBit = x % 10;
          toReturn = checked((10 * toReturn) + lastBit);
          x /= 10;
        }
        return toReturn;
      }
      catch (OverflowException)
      {
        return 0;
      }
    }

    [Theory]
    [InlineData(12, 21)]
    [InlineData(123, 321)]
    [InlineData(-2147483648, 0)]
    public void CanReverse(int input, int expected)
    {
      Assert.Equal(expected, Reverse(input));
    }
  }
}
