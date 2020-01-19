using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class NumJewelsInStonesSpecs
  {
    public int NumJewelsInStones(string J, string S)
    {
      int start = 'A';
      int end = 'z';
      var charsMap = new int[end - start + 1];
      foreach (var c in S)
      {
        charsMap[c - start]++;
      }
      var toReturn = 0;
      foreach (var c in J)
      {
        toReturn += charsMap[c - start];
      }
      return toReturn;
    }

    [Theory]
    [InlineData("aA", "aAAbbbb", 3)]
    [InlineData("z", "ZZ", 0)]
    public void CanNumJewelsInStones(string J, string S, int expected)
    {
      Assert.Equal(expected, NumJewelsInStones(J, S));
    }
  }
}
