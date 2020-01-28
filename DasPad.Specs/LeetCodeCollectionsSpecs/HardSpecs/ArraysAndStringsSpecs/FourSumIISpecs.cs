using DasPad.Specs.Extensions;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class FourSumIISpecs
  {
    /*
     * Given four lists A, B, C, D of integer values, compute how many tuples (i, j, k, l) there are such that A[i] + B[j] + C[k] + D[l] is zero.

    To make problem a bit easier, all A, B, C, D have same length of N where 0 ≤ N ≤ 500. All integers are in the range of -228 to 228 - 1 and the result is guaranteed to be at most 231 - 1.

    Example:

    Input:
    A = [ 1, 2]
    B = [-2,-1]
    C = [-1, 2]
    D = [ 0, 2]

    Output:
    2

    Explanation:
    The two tuples are:
    1. (0, 0, 0, 1) -> A[0] + B[0] + C[0] + D[1] = 1 + (-2) + (-1) + 2 = 0
    2. (1, 1, 0, 0) -> A[1] + B[1] + C[0] + D[0] = 2 + (-1) + (-1) + 0 = 0
     */

    public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
    {
      return FourSumUsingMap(A, B, C, D);
    }

    public int FourSumCountBruteForce(int[] A, int[] B, int[] C, int[] D)
    {
      var toReturn = 0;
      for (var i = 0; i < A.Length; i++)
      {
        for (var j = 0; j < B.Length; j++)
        {
          var ab = A[i] + B[j];
          for (var k = 0; k < C.Length; k++)
          {
            var abc = ab + C[k];
            for (var l = 0; l < D.Length; l++)
            {
              if (abc + D[l] == 0)
              {
                toReturn++;
              }
            }
          }
        }
      }
      return toReturn;
    }

    public int FourSumUsingMap(int[] A, int[] B, int[] C, int[] D)
    {
      var toReturn = 0;
      //var sumCache = new HashSet<int>();
      //Tip: We would need a dictionary here since two different numbers could yield same sum and if we use HashSet we will loose the different combinations and instead only account for one combo.
      var sumCache = new Dictionary<int, int>();
      for (var i = 0; i < A.Length; i++)
      {
        for (var j = 0; j < B.Length; j++)
        {
          var sum = A[i] + B[j];
          if (!sumCache.ContainsKey(sum))
          {
            sumCache[sum] = 0;
          }
          sumCache[sum]++;
        }
      }

      for (var i = 0; i < C.Length; i++)
      {
        for (var j = 0; j < D.Length; j++)
        {
          var negated = -1 * (C[i] + D[j]);
          if (sumCache.ContainsKey(negated))
          {
            toReturn += sumCache[negated];
          }
        }
      }
      return toReturn;
    }

    [Theory]
    [InlineData("1, 2", "-2,-1", "-1, 2", " 0, 2", 2)]
    [InlineData("-1,-1", "-1,1", "-1,1", "1,-1", 6)]
    public void CanFourSumCount(string A, string B, string C, string D, int expected)
    {
      Assert.Equal(expected, FourSumCount(A.AsIntsFromCsv(), B.AsIntsFromCsv(), C.AsIntsFromCsv(), D.AsIntsFromCsv()));
    }
  }
}
