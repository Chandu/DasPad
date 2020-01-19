using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.YangshunSpecs.DpSpecs
{
  public class KnightDialerSpecs
  {
    //TODO: (CV) https://leetcode.com/problems/knight-dialer/description/
    /*
     * A chess knight can move as indicated in the chess diagram below:

      This time, we place our chess knight on any numbered key of a phone pad (indicated above), and the knight makes N-1 hops.  Each hop must be from one key to another numbered key.

      Each time it lands on a key (including the initial placement of the knight), it presses the number of that key, pressing N digits total.

      How many distinct numbers can you dial in this manner?

      Since the answer may be large, output the answer modulo 10^9 + 7.

      Example 1:
      Input: 1
      Output: 10

      Example 2:
      Input: 2
      Output: 20

      Example 3:
      Input: 3
      Output: 46
     */

    public static int MOD = 1000000007;
    public int KnightDialer(int input)
    {
      //int MOD = 1_000_000_007;
      var positions = GetNextPositions();
      var numbers = 0;
      var dp = new Dictionary<(int, int), int>();
      for(var i=0; i<=9; i++)
      {
        numbers = ( numbers + KnightDialerHelper(input, positions, i, dp)) % MOD;
      }
      return numbers;
    }

    private Dictionary<int, IEnumerable<int>> GetNextPositions()
    {
      return new Dictionary<int, IEnumerable<int>>()
      {
        { 0, new[]{ 4, 6 } },
        { 1, new[]{ 6, 8 } },
        { 2, new[]{ 7, 9 } },
        { 3, new[]{ 4, 8 } },
        { 4, new[]{ 3, 9, 0 } },
        { 5, Enumerable.Empty<int>()},
        { 6, new[]{ 1, 7, 0} },
        { 7, new[]{ 2, 6 } },
        { 8, new[]{ 1, 3 } },
        { 9, new[]{ 4, 2 } },
      };
    }

    /*
     * Recurrence Relation
     * T(P, N) = Sum(T(p, N-1))
     */

    private int KnightDialerHelper(int input, Dictionary<int, IEnumerable<int>> nextPositions,  int number, Dictionary<(int, int), int> dp)
    {
      if(input <= 0)
      {
        return 0;
      }
      if (input == 1)
      {
        return 1;
      }
      else
      {
        if(dp.ContainsKey((number, input)))
        {
          return dp[(number, input)];
        }
        var childSum = 0;
        foreach(var position in nextPositions[number])
        {
          childSum = (childSum + KnightDialerHelper(input - 1, nextPositions, position, dp)) % MOD;
        }
        dp[(number, input)] = childSum;
        return dp[(number, input)];
      }
    }

    [Theory]
    [InlineData(1, 10)]
    [InlineData(2, 20)]
    [InlineData(3, 46)]
    [InlineData(19, 25881088)]
    [InlineData(161, 533302150)]
    public void CanKnightDialer(int input, int expected)
    {
      Assert.Equal(expected, KnightDialer(input));
    }
  }
}
