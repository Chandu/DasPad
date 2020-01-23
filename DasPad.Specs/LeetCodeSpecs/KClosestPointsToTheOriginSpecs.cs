using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class KClosestPointsToTheOriginSpecs
  {
    public class PointComparer : IComparer<PointWithDistance>
    {
      public int Compare(PointWithDistance x, PointWithDistance y)
      {
        return x.Distance.CompareTo(y.Distance);
      }
    }

    public class PointWithDistance
    {
      public int[] Point = new int[2];
      public double Distance;
    }

    public int[][] KClosest(int[][] points, int K)
    {
      var distances = points.Select(a => new PointWithDistance()
      {
        Distance = Math.Sqrt(a[0] * a[0] + a[1] * a[1]),
        Point = a
      }).ToArray();
      Array.Sort(distances, new PointComparer());

      var i = 0;
      return distances.Select(a => a.Point).TakeWhile(_ =>
      {
        var toReturn = i < K && i < points.Length;
        i++;
        return toReturn;
      }).ToArray();
    }

    public static string ArrayToString(int[][] arr)
    {
      var toReturn = "";
      for (var i = 0; i < arr.Length; i++)
      {
        for (var j = 0; j < arr[i].Length; j++)
        {
          toReturn += arr[i][j].ToString() + " ";
        }
        toReturn += Environment.NewLine;
      }
      return toReturn;
    }

    [Fact]
    public void CanKClosest()
    {
      var input = new[] { new int[] { 1, 3 }, new int[] { -2, 2 } };
      var k = 1;
      var expected = new[] { new int[] { -2, 2 } };
      var actual = KClosest(input, k);
      Assert.Equal(ArrayToString(expected), ArrayToString(actual));
    }
  }
}
