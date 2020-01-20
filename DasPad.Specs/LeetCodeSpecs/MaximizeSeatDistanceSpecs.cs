using System;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class MaximizeSeatDistanceSpecs
  {
    /*
     * In a row of seats, 1 represents a person sitting in that seat, and 0 represents that the seat is empty.

      There is at least one empty seat, and at least one person sitting.

      Alex wants to sit in the seat such that the distance between him and the closest person to him is maximized.

      Return that maximum distance to closest person.

      Example 1:

      Input: [1,0,0,0,1,0,1]
      Output: 2
      Explanation:
      If Alex sits in the second open seat (seats[2]), then the closest person has distance 2.
      If Alex sits in any other open seat, the closest person has distance 1.
      Thus, the maximum distance to the closest person is 2.
      Example 2:

      Input: [1,0,0,0]
      Output: 3
      Explanation:
      If Alex sits in the last seat, the closest person is 3 seats away.
      This is the maximum distance possible, so the answer is 3.

      Note:

      1 <= seats.length <= 20000
      seats contains only 0s or 1s, at least one 0, and at least one 1.
     */

    public int MaxDistToClosest(int[] seats)
    {
      int left = -1;
      int maxDistance = 0;
      int n = seats.Length;
      for (int right = 0; right < n; right++)
      {
        if (seats[right] == 1)
        {
          if (left == -1)
          {
            //handles edge case when it leads with 0.
            maxDistance = right;
          }
          else
          {
            //when your seat is inbetween 1s, you need to find half point between the two so you divide by 2
            maxDistance = Math.Max(maxDistance, (right - left) / 2);
          }

          left = right;
        }
      }
      if (seats[n - 1] == 0)
      {
        //handles edge case when ends with 0.
        maxDistance = Math.Max(maxDistance, (n - 1 - left));
      }
      return maxDistance;
    }

    [Fact]
    public void CanMaxDistToClosest()
    {
      Assert.Equal(2, MaxDistToClosest(AsArray(1, 0, 0, 0, 1, 0, 1)));
      Assert.Equal(3, MaxDistToClosest(AsArray(1, 0, 0, 0)));
    }
  }
}
