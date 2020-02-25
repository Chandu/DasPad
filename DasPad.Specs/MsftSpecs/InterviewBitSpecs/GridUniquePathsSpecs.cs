namespace DasPad.Specs.MsftSpecs.InterviewBitSpecs
{
  public class GridUniquePathsSpecs
  {
    /*
     * https://www.interviewbit.com/problems/grid-unique-paths/
     * A robot is located at the top-left corner of an A x B grid (marked ‘Start’ in the diagram below).

      Path Sum: Example 1

      The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked ‘Finish’ in the diagram below).

      How many possible unique paths are there?

      Note: A and B will be such that the resulting answer fits in a 32 bit signed integer.

      Example :

      Input : A = 2, B = 2
      Output : 2

      2 possible routes : (0, 0) -> (0, 1) -> (1, 1)
                    OR  : (0, 0) -> (1, 0) -> (1, 1)
     **/

    public int uniquePaths(int A, int B)
    {
      //Recurrence Relation:
      //P[i, j] = P[i-1, j] + P[i][j-1]
      var dp = new int[A, B];
      for (var i = 0; i < A; i++)
      {
        for (var j = 0; j < B; j++)
        {
          if (i == 0 || j == 0)
          {
            dp[i, j] = 1;
          }
          else
          {
            dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
          }
        }
      }
      return dp[A - 1, B - 1];
    }
  }
}
