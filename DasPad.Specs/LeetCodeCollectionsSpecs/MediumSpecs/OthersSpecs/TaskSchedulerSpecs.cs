using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.OthersSpecs
{
  public class TaskSchedulerSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/114/others/826/
     * Given a char array representing tasks CPU need to do. It contains capital letters A to Z where different letters represent different tasks. Tasks could be done without original order. Each task could be done in one interval. For each interval, CPU could finish one task or just be idle.

      However, there is a non-negative cooling interval n that means between two same tasks, there must be at least n intervals that CPU are doing different tasks or just be idle.

      You need to return the least number of intervals the CPU will take to finish all the given tasks.

      Example:

      Input: tasks = ["A","A","A","B","B","B"], n = 2
      Output: 8
      Explanation: A -> B -> idle -> A -> B -> idle -> A -> B.

      Note:

      The number of tasks is in the range [1, 10000].
      The integer n is in the range [0, 100].
     */

    public class IntervalComparer : IComparer<(string, int)>
    {
      public int Compare((string, int) x, (string, int) y)
      {
        return x.Item2.CompareTo(y.Item2);
      }
    }

    //Review: Nice Trick for auto cleansing queue approach
    /*
      Get most frequent
      Get ties
      answer is most frequent + ties, or num of tasks

      a x x
      a x x
      a

    */

    public int LeastInterval(char[] tasks, int n)
    {
      if (tasks.Length < 1)
        return 0;
      var freqs = tasks.GroupBy(t => t).Select(g => new { val = g.Key, freq = g.Count() })
          .OrderByDescending(f => f.freq)
          .ToList();
      var mostFreq = freqs.First();
      var ties = freqs.Where(f => f.freq == mostFreq.freq).Count(); // will be 1 if there are no ties
      return (Math.Max((mostFreq.freq - 1) * (n + 1) + ties, tasks.Length));
    }

    [Theory]
    [InlineData(8, 2, 'A', 'A', 'A', 'B', 'B', 'B')]
    [InlineData(16, 2, 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G')]
    public void CanLeastInterval(int expected, int n, params char[] tasks)
    {
      Assert.Equal(expected, LeastInterval(tasks, n));
    }
  }
}
