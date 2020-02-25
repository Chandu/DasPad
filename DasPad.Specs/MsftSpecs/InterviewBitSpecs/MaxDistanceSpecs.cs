using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.MsftSpecs.InterviewBitSpecs
{
  public class MaxDistanceSpecs
  {
    /*
     * https://www.interviewbit.com/problems/max-distance/
     * Given an array A of integers, find the maximum of j - i subjected to the constraint of A[i] <= A[j].

        If there is no solution possible, return -1.

        Example :

        A : [3 5 4 2]

        Output : 2
        for the pair (3, 4)
     */

    public int maximumGap(List<int> A)
    {
      if (A == null || A.Count() < 2)
      {
        return 0;
      }
      return maximumGapBinarySearch(A);
    }

    //Revisit
    private int maximumGapBinarySearch(List<int> A)
    {
      int maxDiff;
      int i, j;
      int n = A.Count;
      int[] RMax = new int[n];
      int[] LMin = new int[n];

      if (A.Count == 1)
        return 0;

      /* Construct LMin[] such that LMin[i] stores the minimum value
         from (arr[0], arr[1], ... arr[i]) */
      LMin[0] = A[0];
      for (i = 1; i < n; ++i)
        LMin[i] = Math.Min(A[i], LMin[i - 1]);

      /* Construct RMax[] such that RMax[j] stores the maximum value
         from (arr[j], arr[j+1], ..arr[n-1]) */
      RMax[n - 1] = A[n - 1];
      for (j = n - 2; j >= 0; --j)
        RMax[j] = Math.Max(A[j], RMax[j + 1]);

      /* Traverse both arrays from left to right to find optimum j - i
         This process is similar to merge() of MergeSort */
      i = 0; j = 0; maxDiff = -1;
      while (j < n && i < n)
      {
        if (LMin[i] <= RMax[j])
        {
          maxDiff = Math.Max(maxDiff, j - i);
          j++;
        }
        else
          i++;
      }

      return maxDiff;
    }

    private int maximumGapBruteForce(List<int> A)
    {
      var maxSoFar = int.MinValue;
      for (var i = 0; i < A.Count(); i++)
      {
        for (var j = i; j < A.Count(); j++)
        {
          if (A[j] >= A[i])
          {
            maxSoFar = Math.Max(maxSoFar, j - i);
          }
        }
      }
      return maxSoFar;
    }

    [Theory]
    [InlineData(2, 3, 5, 4, 2)]
    public void CanFindMaximumGap(int expected, params int[] nums)
    {
      Assert.Equal(expected, maximumGap(nums.ToList()));
    }
  }
}
