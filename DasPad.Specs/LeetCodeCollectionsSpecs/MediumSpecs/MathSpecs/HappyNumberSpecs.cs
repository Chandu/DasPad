using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.MathSpecs
{
  public class HappyNumberSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/113/math/815/
     * Write an algorithm to determine if a number is "happy".

      A happy number is a number defined by the following process: Starting with any positive integer, replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1. Those numbers for which this process ends in 1 are happy numbers.

      Example:

      Input: 19
      Output: true
      Explanation:
      12 + 92 = 82
      82 + 22 = 68
      62 + 82 = 100
      12 + 02 + 02 = 1
     */

    private HashSet<int> VisitedList = new HashSet<int>();

    private readonly Dictionary<int, int> Squares = new Dictionary<int, int>()
    {
      [0] = 0,
      [1] = 1,
      [2] = 4,
      [3] = 9,
      [4] = 16,
      [5] = 25,
      [6] = 36,
      [7] = 49,
      [8] = 64,
      [9] = 81
    };

    public bool IsHappy(int n)
    {
      if (VisitedList.Contains(n))
      {
        return false;
      }
      var digitsArray = n.ToString().Select(a => int.Parse(a.ToString())).ToArray();
      var digitsSum = digitsArray.Select(a => Squares[a]).Sum();
      if (digitsSum == 1)
      {
        return true;
      }
      else
      {
        VisitedList.Add(n);
        return IsHappy(digitsSum);
      }
    }

    [Theory]
    [InlineData(19, true)]
    [InlineData(7, true)]
    public void CanVerifyIsHappy(int input, bool expected)
    {
      Assert.Equal(expected, IsHappy(input));
    }
  }
}
