using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.OthersSpecs
{
  public class SumOfTwoIntegersSpecs
  {
    /*
     * Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.

        Example 1:

        Input: a = 1, b = 2
        Output: 3
        Example 2:

        Input: a = -2, b = 3
        Output: 1
     */

    public int GetSum(int a, int b)
    {
      //Tip: To get carry using Bit Manipulation;
      var carry = ((a & b) << 1);
      //Tip: To get sum without carry using Bit Manipulation;
      var sum = a ^ b;
      while (carry != 0)
      {
        var curSum = sum ^ carry;
        carry = ((sum & carry) << 1);
        sum = curSum;
      }
      return sum;

      //Tip: To get carry using Bit Manipulation;
      //var carry = ((a & b) << 1);
      //Tip: To negate a number get it's Two's complement and then add 1
      //  b = ~b + 1;
      //return b == 0 ? a : GetSum(a ^ b, (a & b) << 1);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-2, 3, 1)]
    public void CanGetSum(int a, int b, int result)
    {
      Assert.Equal(result, GetSum(a, b));
    }
  }
}
