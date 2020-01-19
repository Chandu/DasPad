using System;
using Xunit;

namespace DasPad.Specs.HackerRankSpecs
{
  public class LeftRoateSpecs
  {
    public static int[] Rotate(int[] a, int by)
    {
      if (by <= 0)
      {
        return a;
      }
      var length = a.Length;
      var netRemaining = by % length;
      for (var i = 0; i < netRemaining; i++)
      {
        var first = a[0];
        for (var j = 0; j < length - 1; j++)
        {
          a[j] = a[j + 1];
        }
        a[length - 1] = first;
      }

      return a;
    }

    [Fact]
    public void CanRotate()
    {
      Assert.Equal(new[] { 5, 1, 2, 3, 4 }, Rotate(new[] { 1, 2, 3, 4, 5 }, 4));
      Assert.Equal(new[] { 1, 2, 3, 4, 5 }, Rotate(new[] { 1, 2, 3, 4, 5 }, -4));
      Assert.Equal(Array.Empty<int>(), Rotate(Array.Empty<int>(), -4));
    }
  }
}
