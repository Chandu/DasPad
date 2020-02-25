using DasPad.Specs.Extensions;
using System;
using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class MaximumOfAbsoluteValueExpressionSpecs
  {
    /*
     * https://leetcode.com/problems/maximum-of-absolute-value-expression/
     * 1131. Maximum of Absolute Value Expression
      Medium

      88

      112

      Add to List

      Share
      Given two arrays of integers with equal lengths, return the maximum value of:

      |arr1[i] - arr1[j]| + |arr2[i] - arr2[j]| + |i - j|

      where the maximum is taken over all 0 <= i, j < arr1.length.

      Example 1:

      Input: arr1 = [1,2,3,4], arr2 = [-1,4,5,6]
      Output: 13
      Example 2:

      Input: arr1 = [1,-2,-5,0,10], arr2 = [0,-2,-1,-7,-4]
      Output: 20

      Constraints:

      2 <= arr1.length == arr2.length <= 40000
      -10^6 <= arr1[i], arr2[i] <= 10^6
     */

    public int MaxAbsValExpr(int[] arr1, int[] arr2)
    {
      if (arr1.Length < 1)
      {
        return 0;
      }
      return MaxAbsValExprOptim(arr1, arr2);
    }

    public int MaxAbsValExprBruteForce(int[] arr1, int[] arr2)
    {
      var maxSoFar = int.MinValue;
      for (var i = 0; i < arr1.Length; i++)
      {
        for (var j = i; j < arr1.Length; j++)
        {
          var cur = Math.Abs(arr1[i] - arr1[j]) + Math.Abs(arr2[i] - arr2[j]) + Math.Abs(i - j);
          maxSoFar = Math.Max(maxSoFar, cur);
        }
      }
      return maxSoFar;
    }

    /*
     * |arr1[i] - arr1[j]| + |arr2[i] - arr2[j]| + |i - j| can be written as each term being either mul;tipled bny 1 or -1 hence has 8 possible answers and we have to pick the best Abs value of these.:

      image

      If we look carefully, 1 & 8 ; 2 & 7; 3 & 6; 4 & 5 are practically the same.
      So , problem reduces to finding max of (1,2,3,4).
      And in each 1,2,3,4, values in both brackets are same, so we simply find max(value in bracket) - min(value in bracket) for each.
      Then find max of values obtained from (1,2,3,4)
     */

    public int MaxAbsValExprOptim(int[] arr1, int[] arr2)
    {
      int ans = 0;
      var sign = new int[4, 3] { { 1, 1, 1 }, { 1, 1, -1 }, { 1, -1, 1 }, { 1, -1, -1 } };
      for (int s = 0; s < sign.GetLength(0); s++)
      {
        int mini = int.MaxValue, maxi = int.MinValue;
        for (int i = 0; i < arr1.Length; i++)
        {
          mini = Math.Min(mini, sign[s, 0] * arr1[i] + sign[s, 1] * arr2[i] + sign[s, 2] * i);
          maxi = Math.Max(maxi, sign[s, 0] * arr1[i] + sign[s, 1] * arr2[i] + sign[s, 2] * i);
        }

        ans = Math.Max(ans, maxi - mini);
      }

      return ans;
    }

    [Theory]
    [InlineData("1,2,3,4", "-1,4,5,6", 13)]
    public void CanMaxAbsValExpr(string first, string second, int expected)
    {
      Assert.Equal(expected, MaxAbsValExpr(first.AsIntsFromCsv(), second.AsIntsFromCsv()));
    }
  }
}
