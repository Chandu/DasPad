using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class IsPowerOfTwoSpecs
  {
    public bool IsPowerOfTwo(int n)
    {
      if (n <= 2)
      {
        return (n <= 0) ? false : true;
      }
      var powered = 2;
      while (powered <= n / 2)
      {
        powered <<= 1;
      }
      return (powered & n) == n;
    }

    [Theory]
    [InlineData(32, true)]
    [InlineData(4, true)]
    [InlineData(5, false)]
    [InlineData(6, false)]
    [InlineData(2, true)]
    public void CanIdentifyIsPowerOfTwo(int input, bool expected)
    {
      Assert.Equal(expected, IsPowerOfTwo(input));
    }
  }
}
