using Xunit;

namespace DasPad.Specs.HackerRankSpecs
{
  public class ReverseArraySpecs
  {
    private static int[] reverseArray(int[] a)
    {
      for (int i = 0, j = a.Length - 1; j > i; i++, j--)
      {
        var temp = a[i];
        a[i] = a[j];
        a[j] = temp;
      }
      return a;
    }

    [Fact]
    public void CanReverseArray()
    {
      Assert.Equal(new[] { 2, 3, 4, 1 }, reverseArray(new[] { 1, 4, 3, 2 }));
    }
  }
}
