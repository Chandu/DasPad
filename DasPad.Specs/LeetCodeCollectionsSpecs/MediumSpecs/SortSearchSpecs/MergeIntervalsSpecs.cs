using DasPad.Specs.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.SortSearchSpecs
{
  public class MergeIntervalsSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/110/sorting-and-searching/803/
     * Given a collection of intervals, merge all overlapping intervals.

      Example 1:

      Input: [[1,3],[2,6],[8,10],[15,18]]
      Output: [[1,6],[8,10],[15,18]]
      Explanation: Since intervals [1,3] and [2,6] overlaps, merge them into [1,6].
      Example 2:

      Input: [[1,4],[4,5]]
      Output: [[1,5]]
      Explanation: Intervals [1,4] and [4,5] are considered overlapping.
      NOTE: input types have been changed on April 15, 2019. Please reset to default code definition to get new method signature.
     */

    public int[][] Merge(int[][] intervals)
    {
      return MergeUsingSortAndStack(intervals);
    }

    //Note: Nice intuitive Trick
    public class IntervalComparer : IComparer<int[]>
    {
      public int Compare(int[] x, int[] y)
      {
        return x[0].CompareTo(y[0]);
      }
    }

    public int[][] MergeUsingSortAndStack(int[][] intervals)
    {
      Array.Sort(intervals, new IntervalComparer());
      var toReturn = new List<int[]>();
      foreach (var entry in intervals)
      {
        if (toReturn.Count == 0)
        {
          toReturn.Add(entry);
        }
        else
        {
          var cur = toReturn[toReturn.Count() - 1];
          if (cur[1] < entry[0])
          {
            toReturn.Add(entry);
          }
          else if (cur[1] < entry[1])
          {
            cur[0] = Math.Min(entry[0], cur[0]);
            cur[1] = Math.Max(entry[1], cur[1]);
          }
        }
      }
      return toReturn.ToArray();
    }

    [Theory]
    [InlineData("[[1,3],[2,6],[8,10],[15,18]]", "[[1,6],[8,10],[15,18]]")]
    [InlineData("[[2,3],[2,2],[3,3],[1,3],[5,7],[2,2],[4,6]]", "[[1,3],[4,7]]")]
    [InlineData("[[2,3],[2,2],[3,3],[1,3],[4,7],[2,2],[5,6]]", "[[1,3],[4,7]]")]
    public void CanMergeIntervals(string intervals, string expected)
    {
      Assert.Equal(expected, Merge(intervals.AsArraysFromJsArrays()).AsJsArraysString());
    }
  }
}
