using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.SortSearchSpecs
{
  public class SearchA2DMatrixIISpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/806/
     * Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

      Integers in each row are sorted in ascending from left to right.
      Integers in each column are sorted in ascending from top to bottom.
      Example:

      Consider the following matrix:

      [
        [1,   4,  7, 11, 15],
        [2,   5,  8, 12, 19],
        [3,   6,  9, 16, 22],
        [10, 13, 14, 17, 24],
        [18, 21, 23, 26, 30]
      ]
      Given target = 5, return true.

      Given target = 20, return false.
     */

    public bool SearchMatrix(int[,] matrix, int target)
    {
      return SearchMatrixInternal(matrix, target);
    }

    private bool SearchMatrixInternal(int[,] matrix, int target)
    {
      var rowLength = matrix.GetLength(0);
      var columnLength = matrix.GetLength(1);
      var row = 0;
      var col = columnLength - 1;
      while (row < rowLength && col >= 0)
      {
        var curVal = matrix[row, col];
        if (curVal == target)
        {
          return true;
        }
        if (curVal > target)
        {
          col--;
        }
        else
        {
          row++;
        }
      }

      return false;
    }

    [Theory]
    [InlineData(5, true)]
    [InlineData(20, false)]
    public void CanSearchMatrix(int target, bool expected)
    {
      var input = new[,]
      {
        { 1,   4,  7, 11, 15},
        { 2,   5,  8, 12, 19},
        { 3,   6,  9, 16, 22},
        { 10, 13, 14, 17, 24},
        { 18, 21, 23, 26, 30}
      };

      Assert.Equal(expected, SearchMatrix(input, target));
      Assert.True(SearchMatrix(new[,] { { -5 } }, -5));
      Assert.True(SearchMatrix(new[,] { { 1, 1 } }, 1));
    }
  }
}
