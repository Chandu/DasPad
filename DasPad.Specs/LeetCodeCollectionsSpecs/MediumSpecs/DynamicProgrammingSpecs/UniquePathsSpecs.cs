using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.DynamicProgrammingSpecs
{
  public class UniquePathsSpecs
  {
    /*
     *https://leetcode.com/explore/interview/card/top-interview-questions-medium/111/dynamic-programming/808/
     *
     * A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

      The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

      How many possible unique paths are there?

      Above is a 7 x 3 grid. How many possible unique paths are there?

      Note: m and n will be at most 100.

      Example 1:

      Input: m = 3, n = 2
      Output: 3
      Explanation:
      From the top-left corner, there are a total of 3 ways to reach the bottom-right corner:
      1. Right -> Right -> Down
      2. Right -> Down -> Right
      3. Down -> Right -> Right
      Example 2:

      Input: m = 7, n = 3
      Output: 28
     */

    //Note: YAY another DP with First Attempt, but I had gone through similar question elsewhere while preparing.. I will still take it.
    public int UniquePaths(int m, int n)
    {
      //var dp = new int[m, n];
      //FillArray(dp, -1);
      //for (var i = 0; i < m; i++)
      //{
      //  dp[i, 0] = 1;
      //}

      //for (var i = 0; i < n; i++)
      //{
      //  dp[0, i] = 1;
      //}

      //return UniquePathsDpTopDown(m - 1, n - 1, dp);
      return UniquePathsDpBottomUp(m, n);
    }

    private static void FillArray(int[,] array, int val)
    {
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (int j = 0; j < array.GetLength(1); j++)
        {
          array[i, j] = val;
        }
      }
    }

    public int UniquePathsDpBottomUp(int m, int n)
    {
      var dp = new int[m, n];
      for (var i = 0; i < m; i++)
      {
        for (var j = 0; j < n; j++)
        {
          if (i == 0 || j == 0)
          {
            dp[i, j] = 1;
          }
          else
          {
            dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
          }
        }
      }
      return dp[m - 1, n - 1];
    }

    public int UniquePathsDpTopDown(int row, int col, int[,] dp)
    {
      var m = dp.GetLength(0);
      var n = dp.GetLength(1);
      if (row >= m || col >= n || row < 0 || col < 0)
      {
        return 0;
      }
      else
      {
        if (dp[row, col] == -1)
        {
          dp[row, col] = UniquePathsDpTopDown(row - 1, col, dp) + UniquePathsDpTopDown(row, col - 1, dp);
        }
        return dp[row, col];
      }
    }

    [Theory]
    [InlineData(3, 2, 3)]
    public void CanFindUniquePaths(int m, int n, int expected)
    {
      Assert.Equal(expected, UniquePaths(m, n));
    }
  }
}
