using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.MathSpecs
{
  public class IsPowerOfThreeSpecs
  {
    /*
     * Given an integer, write a function to determine if it is a power of three.

      Example 1:

      Input: 27
      Output: true
      Example 2:

      Input: 0
      Output: false
      Example 3:

      Input: 9
      Output: true
      Example 4:

      Input: 45
      Output: false
      Follow up:
      Could you do it without using any loop / recursion?
     */

    public bool IsPowerOfThree(int n)
    {
      return IsPowerOfThreeUsingLogBase3(n);
    }

    public bool IsPowerOfThreeUsingLogBase3(int n)
    {
      return Math.Log(n, 3) % 1 == 0;
    }

    public bool IsPowerOfThreeUsingDivideBy3(int n)
    {
      if (n < 1)
      {
        return false;
      }
      else if (n == 1)
      {
        return true;
      }

      return (n % 3 == 0) && (IsPowerOfThree(n / 3));
    }

    [Theory]
    [InlineData(9, true)]
    public void CanVerifyIsPowerOfThree(int input, bool expected)
    {
      Assert.Equal(expected, IsPowerOfThree(input));
    }
  }
}
