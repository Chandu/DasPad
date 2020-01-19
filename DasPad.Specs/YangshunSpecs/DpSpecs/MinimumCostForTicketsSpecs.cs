using System.Collections.Generic;
using Xunit;
using System.Linq;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.YangshunSpecs.DpSpecs
{
  public class MinimumCostForTicketsSpecs
  {
    //TODO: (CV) https://leetcode.com/problems/minimum-cost-for-tickets/
    /*
     * In a country popular for train travel, you have planned some train travelling one year in advance.  The days of the year that you will travel is given as an array days.  Each day is an integer from 1 to 365.

      Train tickets are sold in 3 different ways:

      a 1-day pass is sold for costs[0] dollars;
      a 7-day pass is sold for costs[1] dollars;
      a 30-day pass is sold for costs[2] dollars.
      The passes allow that many days of consecutive travel.  For example, if we get a 7-day pass on day 2, then we can travel for 7 days: day 2, 3, 4, 5, 6, 7, and 8.

      Return the minimum number of dollars you need to travel every day in the given list of days.

      Example 1:

      Input: days = [1,4,6,7,8,20], costs = [2,7,15]
      Output: 11
      Explanation:
      For example, here is one way to buy passes that lets you travel your travel plan:
      On day 1, you bought a 1-day pass for costs[0] = $2, which covered day 1.
      On day 3, you bought a 7-day pass for costs[1] = $7, which covered days 3, 4, ..., 9.
      On day 20, you bought a 1-day pass for costs[0] = $2, which covered day 20.
      In total you spent $11 and covered all the days of your travel.
      Example 2:

      Input: days = [1,2,3,4,5,6,7,8,9,10,30,31], costs = [2,7,15]
      Output: 17
      Explanation:
      For example, here is one way to buy passes that lets you travel your travel plan:
      On day 1, you bought a 30-day pass for costs[2] = $15 which covered days 1, 2, ..., 30.
      On day 31, you bought a 1-day pass for costs[0] = $2 which covered day 31.
      In total you spent $17 and covered all the days of your travel.

      Note:

      1 <= days.length <= 365
      1 <= days[i] <= 365
      days is in strictly increasing order.
      costs.length == 3
      1 <= costs[i] <= 1000
     */

    /*
     * Intuition and Algorithm

      For each day, if you don't have to travel today, then it's strictly better to wait to buy a pass. If you have to travel today, you have up to 3 choices: you must buy either a 1-day, 7-day, or 30-day pass.

      We can express those choices as a recursion and use dynamic programming. Let's say dp(i) is the cost to fulfill your travel plan from day i to the end of the plan. Then, if you have to travel today, your cost is:

      dp(i)=min(dp(i+1)+costs[0],dp(i+7)+costs[1],dp(i+30)+costs[2])

      @user4638A Some problems (like this one) are easier to visualize/understand and solve using bottom-up DP. Some good ones:

      935. Knight Dialer
      576. Out of Boundary Paths
      For more complicated problems, however, I found it challenging to find the transition function right off the bat. Some people can do it better, and that's because they practice a lot. If I feel like it’s a DP problem and struggle, I use this pattern (sometimes referenced as top-down DP) to unblock myself:

      Implement brute-force recursive solution (DFS). This is usually too slow at is analyses every permutation.
      Add pruning (e.g. best solution so far) to not explore obvious dead ends.
      Add memoisation to cache interim computations.
      At this point, most of interviewers will be satisfied. However, by going through these steps, you may gather enough intuition to flip the solution into bottom-up DP. Then, you can often discover ways to optimize the memory usage. From the interview prospective, this is a home run!

      For additional explanation/example of this process, you can check out these articles:

      What is Dynamic Programming? - https://www.educative.io/courses/grokking-dynamic-programming-patterns-for-coding-interviews/m2G1pAq0OO0
      0/1 Knapsack - https://www.educative.io/courses/grokking-dynamic-programming-patterns-for-coding-interviews/RM1BDv71V60
      Now, to master the recursion I recommend solving related problems here on LeetCode:

      Trees
      DFS
     */

    public int MincostTickets(int[] days, int[] costs)
    {
      return 0;
    }

    [Fact]
    public void CanMincostTickets()
    {
      //Assert.Equal(11, MincostTickets(AsArray(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31), AsArray(2, 7, 15)));
    }
  }
}
