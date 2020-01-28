using DasPad.Specs.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class SpiralMatrixSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-hard/116/array-and-strings/828/
     * Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

        Example 1:

        Input:
        [
         [ 1, 2, 3 ],
         [ 4, 5, 6 ],
         [ 7, 8, 9 ]
        ]
        Output: [1,2,3,6,9,8,7,4,5]
        Example 2:

        Input:
        [
          [1, 2, 3, 4],
          [5, 6, 7, 8],
          [9,10,11,12]
        ]
        Output: [1,2,3,4,8,12,11,10,9,5,6,7]
     */

    public IList<int> SpiralOrder(int[][] matrix)
    {
      if (matrix.Length == 0 || matrix[0].Length == 0)
      {
        return Array.Empty<int>();
      }
      var toReturn = new List<int>();
      int top = 0, left = 0;
      int bottom = matrix.Length - 1;
      int right = matrix[0].Length - 1;
      while (true)
      {
        for (var i = left; i <= right; i++)
        {
          toReturn.Add(matrix[top][i]);
        }
        top++;
        if (top > bottom)
        {
          break;
        }

        for (var i = top; i <= bottom; i++)
        {
          toReturn.Add(matrix[i][right]);
        }
        right--;
        if (left > right)
        {
          break;
        }

        for (var i = right; i >= left; i--)
        {
          toReturn.Add(matrix[bottom][i]);
        }
        bottom--;
        if (top > bottom)
        {
          break;
        }

        for (var i = bottom; i >= top; i--)
        {
          toReturn.Add(matrix[i][left]);
        }
        left++;
        if (left > right)
        {
          break;
        }
      }

      return toReturn;
    }

    [Theory]
    [InlineData("[[ 1, 2, 3 ],[ 4, 5, 6 ],[ 7, 8, 9 ]]", "1,2,3,6,9,8,7,4,5")]
    [InlineData("[[1, 2, 3, 4],[5, 6, 7, 8],[9,10,11,12]]", "1,2,3,4,8,12,11,10,9,5,6,7")]
    public void CanSpiralOrder(string matrix, string expected)
    {
      Assert.Equal(expected, SpiralOrder(matrix.AsArraysFromJsArrays()).ToArray().AsCsvFromIntsArray());
    }
  }
}
