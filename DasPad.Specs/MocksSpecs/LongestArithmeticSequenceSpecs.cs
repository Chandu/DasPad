using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.MocksSpecs
{
  public class LongestArithmeticSequenceSpecs
  {
    public int LongestArithSeqLength(int[] A)
    {
      return LongestArithSeqLengthDp(A);
    }

    public int LongestArithSeqLengthDp(int[] A)
    {
      /*
      Idea is to build a Dp of Delta -> Arbitrary Sequence Length seen at index i for this delta
      So basically it's a Map of delta -> Array[]
      dp[diff][index] equals to the length of arithmetic sequence at index with difference diff.

      We iteratively build the map for a new index i, by considering all elements to the left one-by-one.
For each pair of indices (i,j) and difference d = A[i]-A[j] considered, we check if there was an existing chain at the index j with difference d already.

If yes, we can then extend the existing chain length by 1.
Else, if not, then we can start a new chain of length 2 with this new difference d and (A[j], A[i]) as its elements.

      def longestArithSeqLength(self, A: List[int]) -> int:
          dp = {}
          for i, a2 in enumerate(A[1:], start=1):
              for j, a1 in enumerate(A[:i]):
                  d = a2 - a1
                  if (j, d) in dp:
                      dp[i, d] = dp[j, d] + 1
                  else:
                      dp[i, d] = 2
          return max(dp.values())
      */
      var longestSoFar = 0;
      var cache = new Dictionary<(int, int), int>();
      for (var i = 0; i < A.Length; i++)
      {
        var cur = A[i];
        for (var j = 0; j < i; j++)
        {
          var next = A[j];
          var delta = next - cur;
          if (cache.ContainsKey((j, delta)))
          {
            cache[(i, delta)] = cache[(j, delta)] + 1;
          }
          else
          {
            cache[(i, delta)] = 2;
          }

          //if (!cache.ContainsKey((j, delta)))
          //{
          //  var index = j + 1;
          //  var factor = 1;
          //  var nCount = 1;
          //  while (index < A.Length)
          //  {
          //    if (A[index] - next == (factor * delta))
          //    {
          //      factor++;
          //      nCount++;
          //    }
          //    index++;
          //  }
          //  cache[(j, delta)] = nCount;
          //}

          //longestSoFar = Math.Max(longestSoFar, 1 + cache[(j, delta)]);
        }
      }
      //return longestSoFar;
      return cache.Max(a => a.Value);
    }

    public int LongestArithSeqLengthBruteForce(int[] A)
    {
      var longestSoFar = 0;
      for (var i = 0; i < A.Length; i++)
      {
        var cur = A[i];
        for (var j = i + 1; j < A.Length; j++)
        {
          var next = A[j];
          var delta = next - cur;
          var index = j + 1;
          var factor = 1;
          var nCount = 2;
          while (index < A.Length)
          {
            if (A[index] - next == (factor * delta))
            {
              factor++;
              nCount++;
            }
            index++;
          }
          longestSoFar = Math.Max(longestSoFar, nCount);
        }
      }
      return longestSoFar;
    }

    [Theory]
    [InlineData(4, 3, 6, 9, 12)]
    public void CanFindArithmeticSequence(int expected, params int[] input)
    {
      Assert.Equal(expected, LongestArithSeqLength(input));
    }
  }
}
