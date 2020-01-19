using System;
using Xunit;

namespace DasPad.Specs.HackerRankSpecs
{
  public class HourGlassSpecs
  {
    private static int hourglassSum(int[][] arr)
    {
      var rowLength = arr.Length;
      var colLength = arr[0].Length;
      if (rowLength < 3 && colLength < 3)
      {
        return 0;
      }
      var curMax = int.MinValue;
      for (var i = 0; i < rowLength - 2; i++)
      {
        for (var j = 0; j < colLength - 2; j++)
        {
          var value = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
          curMax = Math.Max(curMax, value);
        }
      }
      return curMax;
    }

    [Fact]
    public void CanDoHourGlassSum()
    {
      int[][] arr = new int[][]
        {
          new [] {1,1,1,0,0,0},
          new [] {0,1,0,0,0,0},
          new [] {1,1,1,0,0,0},
          new [] {0,0,2,4,4,0},
          new [] {0,0,0,2,0,0},
          new [] {0,0,1,2,4,0}
        };

      Assert.Equal(19, hourglassSum(arr));
      arr = new int[][]
        {
          new [] { 0, 1},
          new [] { 0, 1}
        };
      Assert.Equal(0, hourglassSum(arr));

      arr = new int[][]
        {
          new[] { -9, -9, -9, 1, 1, 1 },
          new[] { 0, -9, 0, 4, 3, 2 },
          new[] { -9, -9, -9, 1, 2, 3 },
          new[] { 0, 0, 8, 6, 6, 0 },
          new[] { 0, 0, 0, -2, 0, 0 },
          new[] { 0, 0, 1, 2, 4, 0 }
      };
      Assert.Equal(28, hourglassSum(arr));
    }
  }
}
