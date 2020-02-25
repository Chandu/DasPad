using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DasPad.Specs.MsftSpecs.InterviewBitSpecs
{
  /*
   *
   * https://www.interviewbit.com/problems/sorted-permutation-rank/
   *
   * Given a string, find the rank of the string amongst its permutations sorted lexicographically.
      Assume that no characters are repeated.

      Example :

      Input : 'acb'
      Output : 2

      The order permutations with letters 'a', 'c', and 'b' :
      abc
      acb
      bac
      bca
      cab
      cba
*/
  //Notes:
  /*
    Let the given string be “STRING”. In the input string, ‘S’ is the first character.There are total 6 characters and 4 of them are smaller than ‘S’. So there can be 4 * 5! smaller strings where first character is smaller than ‘S’, like following

    R X X X X X
    I X X X X X
    N X X X X X
    G X X X X X

    Now let us Fix S’ and find the smaller strings starting with ‘S’.

    Repeat the same process for T, rank is 4*5! + 4*4! +…

    Now fix T and repeat the same process for R, rank is 4*5! + 4*4! + 3*3! +…

    Now fix R and repeat the same process for I, rank is 4*5! + 4*4! + 3*3! + 1*2! +…

    Now fix I and repeat the same process for N, rank is 4*5! + 4*4! + 3*3! + 1*2! + 1*1! +…

    Now fix N and repeat the same process for G, rank is 4*5! + 4*4! + 3*3! + 1*2! + 1*1! + 0*0!

    Rank = 4*5! + 4*4! + 3*3! + 1*2! + 1*1! + 0*0! = 597
   */
  /*
   * Lets start by looking at the first character.

  If the first character is X, all permutations which had the first character less than X would come before this permutation when sorted lexicographically.

  Number of permutation with a character C as the first character = number of permutation possible with remaining N-1 character = (N-1)!

  Then the problem reduces to finding the rank of the permutation after removing the first character from the set.

  Hence,

  rank = number of characters less than first character * (N-1)! + rank of permutation of string with the first character removed
  Example
  Lets say out string is “VIEW”.

  Character 1 : 'V'
  All permutations which start with 'I', 'E' would come before 'VIEW'.
  Number of such permutations = 3! * 2 = 12

  Lets now remove ‘V’ and look at the rank of the permutation ‘IEW’.

  Character 2 : ‘I’
  All permutations which start with ‘E’ will come before ‘IEW’
  Number of such permutation = 2! = 2.

  Now, we will limit ourself to the rank of ‘EW’.

  Character 3:
  ‘EW’ is the first permutation when the 2 permutations are arranged.

  So, we see that there are 12 + 2 = 14 permutations that would come before "VIEW".
  Hence, rank of permutation = 15.
   */

  public class SortedPermutationRankSpecs
  {
    private const int Mod = 1000003;

    public int findRank(string A)
    {
      if (A.Length < 1)
      {
        return 0;
      }

      var minSoFarArray = new int[A.Length];
      for (var i = 0; i < A.Length; i++)
      {
        var count = 0;
        for (var j = i + 1; j < A.Length; j++)
        {
          if (A[i] > A[j])
          {
            count++;
          }
        }
        minSoFarArray[i] = count;
      }
      var toReturn = 1;
      for (var i = 0; i < A.Length; i++)
      {
        var curMins = minSoFarArray[i];
        var factProd = curMins * Factorial(A.Length - (i + 1)) % Mod;
        toReturn = (toReturn + factProd) % Mod;
      }
      return toReturn;
    }

    public int Factorial(int n)
    {
      if (n < 1)
      {
        return 1;
      }
      return (n * Factorial(n - 1)) % Mod;
    }

    [Theory]
    [InlineData(2, "acb")]
    [InlineData(342501, "DTNGJPURFHYEW")]
    public void CanFindRank(int expected, string input)
    {
      Assert.Equal(expected, findRank(input));
    }
  }
}
