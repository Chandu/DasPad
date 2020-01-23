using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class PointsOnSameLineSpecs
  {
    public int MaxPoints(int[][] points)
    {
      if (points.Length <= 1)
      {
        return points.Length;
      }
      var slopes = new Dictionary<(int, int), int>();
      for (var i = 0; i < points.Length; i++)
      {
        for (var j = i + 1; j < points.Length; j++)
        {
          var x = points[j][0] - points[i][0];
          var y = points[j][1] - points[i][1];
          int gcd = generateGCD(x, y);
          if (gcd != 0)
          {
            x /= gcd;
            y /= gcd;
          }
          var slope = (y, x);

          if (!slopes.ContainsKey(slope))
          {
            slopes[slope] = 1;
          }
          slopes[slope]++;
        }
      }
      var max = 0;
      foreach (var a in slopes)
      {
        max = Math.Max(max, a.Value);
      }
      return max;
    }

    private int generateGCD(int a, int b)
    {
      if (b == 0) return a;

      return generateGCD(b, a % b);
    }

    public static T[] AsArray<T>(params T[] p)
    {
      return p;
    }

    [Fact]
    public void CanMaxPoints()
    {
      //4
      var input = new int[][]
      {
        new [] {1, 1},
        new [] {3, 2},
        new [] {5, 3},
        new [] {4, 1},
        new [] {2, 3},
        new [] {1, 4}
      };
      //2
      //expected = 2;
      //input = new int[][]
      //{
      //  new[] { 0, 0},
      //  new[] { 0, 0 }
      //};

      //Assert.Equal(expected, MaxPoints(input));
    }
  }
}
