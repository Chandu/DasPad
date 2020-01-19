using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class MatrixUniquePaths
  {
    //public int UniquePaths(int m, int n)
    //{
    //  int[, ] grid = new int[m, n];
    //  for (int i = 0; i < m; i++)
    //  {
    //    for (int j = 0; j < n; j++)
    //    {
    //      if (i == 0 || j == 0)
    //        grid[i, j] = 1;
    //      else
    //        grid[i, j] = grid[i, j - 1] + grid[i - 1, j];
    //    }
    //  }
    //  return grid[m - 1, n - 1];
    //}

    public int UniquePaths(int m, int n)
    {
      if (m == 1 || n == 1)
      {
        return 1;
      }
      else
      {
        return UniquePaths(m - 1, n) + UniquePaths(m, n - 1);
      }
    }

    [Theory]
    [InlineData(3, 2, 3)]
    public void CanUniquePaths(int width, int height, int expected)
    {
      Assert.Equal(expected, UniquePaths(width, height));
    }
  }
}
