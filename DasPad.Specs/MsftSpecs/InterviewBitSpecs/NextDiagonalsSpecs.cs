using System.Collections.Generic;
using System.Linq;
using Xunit;
using DasPad.Specs.Extensions;

namespace DasPad.Specs.MsftSpecs.InterviewBitSpecs
{
  public class NextDiagonalsSpecs
  {
    /*
     * https://www.interviewbit.com/problems/anti-diagonals/
     * Give a N*N square matrix, return an array of its anti-diagonals. Look at the example for more details.

      Example:

      Input:

      1 2 3
      4 5 6
      7 8 9

      Return the following :

      [
        [1],
        [2, 4],
        [3, 5, 7],
        [6, 8],
        [9]
      ]

      Input :
      1 2
      3 4

      Return the following  :

      [
        [1],
        [2, 3],
        [4]
      ]
     */

    public List<List<int>> diagonal(List<List<int>> lis)
    {
      List<List<int>> ar = new List<List<int>>();
      int row = 0;
      for (int i = 0; i < lis[0].Count; i++)
      {
        ar.Add(new List<int>());
        int x = 0, y = i;
        while (y >= 0 && x < lis.Count)
        {
          ar[row].Add(lis[x][y]);
          x++;
          y--;
        }
        row++;
      }
      for (int i = 1; i < lis.Count; i++)
      {
        ar.Add(new List<int>());
        int x = i, y = lis[0].Count - 1;
        while (y >= 0 && x < lis.Count)
        {
          ar[row].Add(lis[x][y]);
          x++;
          y--;
        }
        row++;
      }
      return ar;
    }
  }
}
