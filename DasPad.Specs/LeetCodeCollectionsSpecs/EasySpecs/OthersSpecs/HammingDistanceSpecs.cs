using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.OthersSpecs
{
  public class HammingDistanceSpecs
  {
    /*
     * The Hamming distance between two integers is the number of positions at which the corresponding bits are different.

        Given two integers x and y, calculate the Hamming distance.

        Note:
        0 ≤ x, y < 231.

        Example:

        Input: x = 1, y = 4

        Output: 2

        Explanation:
        1   (0 0 0 1)
        4   (0 1 0 0)
               ↑   ↑

        The above arrows point to positions where the corresponding bits are different.
     */

    public int HammingDistance(int x, int y)
    {
      var z = x ^ y;
      var count = 0;
      while (z > 0)
      {
        var isBitSet = (z & 1) == 1;
        if (isBitSet)
        {
          count++;
        }
        //TODO: (CV TIP Another way of identifying set bits is that an Int32 has 32 bits so we can interate from i=1 to 32 and then & the value with  z to see if the bit is set instead of dividing the z.
        z >>= 1;
      }
      return count;
    }

    [Theory]
    [InlineData(1, 4, 2)]
    public void CanHammingDistance(int x, int y, int expected)
    {
      Assert.Equal(expected, HammingDistance(x, y));
    }
  }
}
