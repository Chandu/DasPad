using Xunit;

namespace DasPad.Specs.YangshunSpecs.BinarySpecs
{
  public class NumberOf1BitsSpecs
  {
    public int HammingWeight(uint n)
    {
      var count = 0;
      while (n != 0)
      {
        if ((n & 1) == 1)
        {
          count++;
        }
        n >>= 1;
      }
      return count;
    }

    [Theory]
    [InlineData(11, 3)]
    public void CanHammingWeight(uint n, int expected)
    {
      Assert.Equal(expected, HammingWeight(n));
    }
  }
}
