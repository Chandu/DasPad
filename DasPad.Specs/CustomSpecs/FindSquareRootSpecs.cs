using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DasPad.Specs.CustomSpecs
{
  public class FindSquareRootSpecs
  {
    public int sqrt(int A)
    {
      long low = 1;
      long high = (long)A;
      long mid = 0;
      while (low <= high)
      {
        mid = low + (high - low) / 2;
        if (mid * mid == A)
          return (int)mid;
        if (mid * mid > A)
          high = mid - 1;
        else
          low = mid + 1;
      }
      return (int)high;
    }

    [Theory]
    [InlineData(25, 5)]
    [InlineData(26, 5)]
    [InlineData(24, 4)]
    [InlineData(2147483647, 46340)]
    public void CanSqrt(int A, int expected)
    {
      Assert.Equal(expected, sqrt(A));
    }
  }
}
